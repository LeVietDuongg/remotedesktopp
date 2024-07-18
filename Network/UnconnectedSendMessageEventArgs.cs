using System;
using System.Net;

namespace Network
{
    /// <summary>
    /// Provides data for the <see cref="IConnectionProvider.ConnectionlessMessageReceived"/> event.
    /// </summary>
    public class UnconnectedSendMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnconnectedSendMessageEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message received connectionlessly.</param>
        /// <param name="to">Where the message is to be sent.</param>
        /// <exception cref="ArgumentNullException"><paramref name="message"/> or <paramref name="to"/> is <c>null</c>.</exception>
        public UnconnectedSendMessageEventArgs(Message message, EndPoint to)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            To = to ?? throw new ArgumentNullException(nameof(to));
        }

     
        public Message Message { get; }

        public EndPoint To { get; }
    }
}