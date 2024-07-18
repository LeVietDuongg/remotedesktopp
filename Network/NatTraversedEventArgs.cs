using System;
using System.Net;

namespace Network
{
    public class NatTraversedEventArgs : EventArgs
    {
        
        public IPEndPoint From { get; set; }
    }
}