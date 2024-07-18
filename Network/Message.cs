using System;
using Lidgren.Network;
using Network.Extensions;

namespace Network
{
   
    public abstract class Message
    {
        public ushort MessageType { get; private set; }
        public Protocol Protocol { get; private set; }

        protected Message(Protocol protocol, ushort messageType)
        {
            Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
            MessageType = messageType;
        }

        public virtual void WritePayload(NetOutgoingMessage message)
        {
            message.Write(Protocol);
            message.Write(MessageType);
        }

        public virtual void ReadPayload(NetIncomingMessage message)
        {
        }
    }
}