using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Network.Extensions;
using Model.Nova;
using System.Net;
using Network.Messages;
using Network.Messages.Nova;
using System.Threading;
using System.Diagnostics;
using Network.Utilities;

namespace Network
{
    
    public class NetworkPeer : MessageHandler
    {
        private readonly NetPeer netPeer;
        private INetEncryption cryptoAlgorithm;
        private byte[] key;

        public NetPeerConfiguration Configuration { get; }
        public List<Protocol> Protocols { get; set; }
        public List<NetConnection> Connections { get; }
        public NetworkStatus Status { get; }
        public bool IsConnected { get; }
        public NetPeerStatistics Statistics { get; }
        public long UniqueIdentifier { get; }
        public int Port { get; }
        public byte[] Key
        {
            get { return key; }
            set
            {
                cryptoAlgorithm = new NetAESEncryption(value, ArrayUtil.GetSequence(value, 0, 16));
                key = value;
            }
        }
        public bool IsAuthenticated { get; set; }

        public event EventHandler<MessageEventArgs> OnMessageReceived;
        public event EventHandler<UnconnectedMessageEventArgs> OnUnconnectedMessageReceived;
        public event EventHandler<MessageEventArgs> OnConnectedMessageSent;
        public event EventHandler<UnconnectedSendMessageEventArgs> OnUnconnectedMessageSent;
        public event EventHandler<DisconnectedEventArgs> OnDisconnected;
        public event EventHandler<ConnectedEventArgs> OnConnected;
        public event EventHandler<NatTraversedEventArgs> OnNatTraversalSucceeded;
        public event EventHandler<DebugMessageEventArgs> OnDebugMessage;

        public NetworkPeer(int port, params Protocol[] protocols)
        {
            Protocols = new List<Protocol>(protocols);
            netPeer = new NetPeer(new NetPeerConfiguration("N/A").GetStandardConfiguration(port));
            netPeer.RegisterReceivedCallback(OnMessageReceivedCallback);
            Start();
        }

        public NetworkPeer(params Protocol[] protocols)
            : this(0, protocols)
        {
        }

        public void Start()
        {
            netPeer.Start();
        }

        public void Connect(IPEndPoint remoteEndPoint)
        {
            netPeer.Connect(remoteEndPoint);
        }

        public void Connect(IPEndPoint remoteEndPoint, NetOutgoingMessage hailMessage)
        {
            netPeer.Connect(remoteEndPoint, hailMessage);
        }

        public void Connect(string host, int port)
        {
            netPeer.Connect(host, port);
        }

        public void Connect(string host, int port, NetOutgoingMessage hailMessage)
        {
            netPeer.Connect(host, port, hailMessage);
        }

        public void SendMessage(Message message)
        {
            SendMessage(message, NetDeliveryMethod.ReliableOrdered, 0);
        }

        public void SendMessage(Message message, NetDeliveryMethod deliveryMethod)
        {
            SendMessage(message, deliveryMethod, 0);
        }

        public void SendMessage(Message message, NetDeliveryMethod deliveryMethod, int sequenceChannel)
        {
            var outgoingMessage = netPeer.CreateMessage();
            message.WritePayload(outgoingMessage);

            if (Key != null)
            {
                IsAuthenticated = true;
                //outgoingMessage.Encrypt(cryptoAlgorithm);
            }

            netPeer.SendMessage(outgoingMessage, Connections, deliveryMethod, sequenceChannel);

            if (OnConnectedMessageSent != null)
                OnConnectedMessageSent(this, new MessageEventArgs(this, message));
        }

        public void SendUnconnectedMessage(Message message, string host, int port)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (host == null)
                throw new ArgumentNullException("host");

            var outgoingMsg = netPeer.CreateMessage();
            message.WritePayload(outgoingMsg);

            netPeer.SendUnconnectedMessage(outgoingMsg, host, port);

            if (OnUnconnectedMessageSent != null)
                OnUnconnectedMessageSent(this, new UnconnectedSendMessageEventArgs(message, new DnsEndPoint(host, port)));
        }

        public void SendUnconnectedMessage(Message message, IPEndPoint endPoint)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (endPoint == null)
                throw new ArgumentNullException("endPoint");

            var outgoingMsg = netPeer.CreateMessage();
            message.WritePayload(outgoingMsg);

            netPeer.SendUnconnectedMessage(outgoingMsg, endPoint);

            if (OnUnconnectedMessageSent != null)
                OnUnconnectedMessageSent(this, new UnconnectedSendMessageEventArgs(message, endPoint));
        }

        public void Introduce(Machine clientMachine, Machine serverMachine)
        {
            if (clientMachine == null)
                throw new ArgumentNullException("clientMachine");
            if (serverMachine == null)
                throw new ArgumentNullException("serverMachine");

            netPeer.Introduce(clientMachine.PrivateEndPoint, clientMachine.PublicEndPoint, serverMachine.PrivateEndPoint,
            serverMachine.PublicEndPoint, String.Empty);
        }

        public void Shutdown()
        {
            netPeer.Shutdown(String.Empty);
        }

        public IPEndPoint GetInternalEndPoint()
        {
            IPAddress subnetMask;
            return new IPEndPoint(NetUtility.GetMyAddress(out subnetMask), netPeer.Port);
        }

        private void OnMessageReceivedCallback(object netPeerObject)
        {
            var incomingMessage = netPeer.ReadMessage();

            switch (incomingMessage.MessageType)
            {
                case NetIncomingMessageType.StatusChanged:
                    HandleStatusChangeMessage(incomingMessage);
                    break;
                case NetIncomingMessageType.UnconnectedData:
                    HandleUnconnectedDataMessage(incomingMessage);
                    break;
                case NetIncomingMessageType.NatIntroductionSuccess:
                    HandleNatIntroductionSuccessMessage(incomingMessage);
                    break;
                case NetIncomingMessageType.Data:
                    HandleDataMessage(incomingMessage);
                    break;
                case NetIncomingMessageType.DebugMessage:
                case NetIncomingMessageType.VerboseDebugMessage:
                case NetIncomingMessageType.WarningMessage:
                case NetIncomingMessageType.ErrorMessage:
                    HandleDebugMessage(incomingMessage);
                    break;
            }

            netPeer.Recycle(incomingMessage);
        }

        private void HandleDebugMessage(NetIncomingMessage message)
        {
            var msg = message.ReadString();

            System.Diagnostics.Trace.WriteLine("Debug Message:  " + msg);

            if (OnDebugMessage != null)
                OnDebugMessage(this, new DebugMessageEventArgs() { Message = msg });
        }

        private void HandleStatusChangeMessage(NetIncomingMessage message)
        {
            var newStatus = (NetConnectionStatus)(message.ReadByte());

            System.Diagnostics.Trace.WriteLine("New Status Message:  " + newStatus.ToString());

            switch (newStatus)
            {
                case NetConnectionStatus.Connected:
                    if (OnConnected != null)
                        OnConnected(this, new ConnectedEventArgs() { From = message.SenderEndpoint });
                    break;
                case NetConnectionStatus.Disconnected:
                    if (OnDisconnected != null)
                        OnDisconnected(this, new DisconnectedEventArgs(true));
                    break;
            }
        }

        private void HandleUnconnectedDataMessage(NetIncomingMessage message)
        {
            var p = message.ReadProtocol();
            ushort messageType = message.ReadUInt16();

            var protocol = Protocols.Where(x => x.Equals(p)).First();

            var mHandlers = GetUnconnectedHandlers(protocol, messageType);
            var customMessage = protocol.Create(messageType);
            customMessage.ReadPayload(message);

            if (OnUnconnectedMessageReceived != null)
                OnUnconnectedMessageReceived(null, new UnconnectedMessageEventArgs(customMessage, message.SenderEndpoint));

            if (mHandlers != null)
            {
                for (int n = 0; n < mHandlers.Count; ++n)
                    mHandlers[n](new UnconnectedMessageEventArgs(customMessage, message.SenderEndpoint));
            }
        }

        private void HandleNatIntroductionSuccessMessage(NetIncomingMessage message)
        {
            if (OnNatTraversalSucceeded != null)
                OnNatTraversalSucceeded(this, new NatTraversedEventArgs { From = message.SenderEndpoint });
        }

        private void HandleDataMessage(NetIncomingMessage incomingMessage)
        {
            if (IsAuthenticated)
            {
                //incomingMessage.Decrypt(cryptoAlgorithm);
            }

            var p = incomingMessage.ReadProtocol();
            ushort messageType = incomingMessage.ReadUInt16();

            var protocol = Protocols.Where(x => x.Equals(p)).First();

            var mHandlers = GetHandlers(protocol, messageType);
            var customMessage = protocol.Create(messageType);
            customMessage.ReadPayload(incomingMessage);

            if (OnMessageReceived != null)
                OnMessageReceived(this, new MessageEventArgs(this, customMessage));

            if (mHandlers != null)
            {
                for (int n = 0; n < mHandlers.Count; ++n)
                    mHandlers[n](new MessageEventArgs(this, customMessage));
            }
        }
    }
}
