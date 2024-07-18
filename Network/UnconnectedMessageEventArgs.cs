using System;
using System.Net;

namespace Network
{
    public class UnconnectedMessageEventArgs<T> : EventArgs
        where T : Message
    {
        public UnconnectedMessageEventArgs(IPEndPoint from, T message)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            Message = message;
        }

       
        public IPEndPoint From { get; }

        public T Message { get; }
    }

    /// <summary>
    /// Provides data for the <see cref="IConnectionProvider.ConnectionlessMessageReceived"/> event.
    /// </summary>
    public class UnconnectedMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnconnectedMessageEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message received connectionlessly.</param>
        /// <param name="from">Where the message came from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> or <paramref name="from"/> is <c>null</c>.</exception>
        public UnconnectedMessageEventArgs(Message message, IPEndPoint from)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            From = from ?? throw new ArgumentNullException(nameof(from));
        }

      
        public Message Message { get; }

       
        public IPEndPoint From { get; }
    }
}