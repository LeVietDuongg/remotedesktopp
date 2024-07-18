using System;

namespace Network
{
    public class DisconnectedEventArgs : EventArgs
    {
        public DisconnectedEventArgs(bool forcedDisconnect)
        {
            Forced = forcedDisconnect;
        }

      
        public bool Forced { get; private set; }
    }
}