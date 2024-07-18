using System;
using Lidgren.Network;

namespace Network
{
    /// <remarks>Copied from Eric Maupin's Tempest networking library</remarks>
    public class MessageEventArgs<T> : EventArgs
        where T : Message
    {
        public MessageEventArgs(NetworkPeer connection, T message)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        /// Gets the NetClient or NetServer for the event.
        /// </summary>
        public NetworkPeer Connection { get; }

        public T Message { get; }
    }

   
    public class MessageEventArgs : EventArgs
    {
       
        public MessageEventArgs(NetworkPeer connection, Message message)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

       
        public NetworkPeer Connection { get; }

       
        public Message Message { get; }
    }
}