using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Lidgren.Network;
using Model.Nova;
using Network.Extensions;
using Network.Messages;
using Network.Messages.Nova;

namespace Network
{
    public class NetworkServer : NetworkPeer
    {
        public NetworkServer(int port)
            : base(port, NovaMessage.NovaProtocol)
        {
        }

       
        public NetConnection Connection => Connections[0];

        /// <summary>
        /// Disconnects the specified client.
        /// </summary>
        /// <param name="clientIndex">The index of the client you wish to disconnect from Connections.</param>
        public void Disconnect(int clientIndex)
        {
            Connections[clientIndex].Disconnect(string.Empty);
        }

     
        public void Disconnect()
        {
            foreach (var connection in Connections)
            {
                connection.Disconnect(string.Empty);
            }
        }
    }
}