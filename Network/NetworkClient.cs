using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Lidgren.Network;
using Network.Extensions;
using Network.Messages;
using Network.Messages.Nova;

namespace Network
{
    public class NetworkClient : NetworkPeer
    {
        public NetworkClient()
            : base(NovaMessage.NovaProtocol)
        {
        }

        public NetConnection ServerConnection => Connections.FirstOrDefault();

        public NetConnectionStatus ConnectionStatus => ServerConnection?.Status ?? NetConnectionStatus.Disconnected;

        public void Disconnect()
        {
            if (IsConnected && ServerConnection != null)
            {
                ServerConnection.Disconnect(String.Empty);
            }
        }
    }
}