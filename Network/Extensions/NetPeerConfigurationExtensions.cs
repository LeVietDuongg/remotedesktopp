using Lidgren.Network;

namespace Network.Extensions
{
    public static class NetPeerConfigurationExtensions
    {
        public static NetPeerConfiguration GetStandardConfiguration(this NetPeerConfiguration self)
        {
            var config = new NetPeerConfiguration("NovaRat")
            {
                AcceptIncomingConnections = true
            };

            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval);
            config.DisableMessageType(NetIncomingMessageType.ConnectionLatencyUpdated);
            config.DisableMessageType(NetIncomingMessageType.Data);
            config.DisableMessageType(NetIncomingMessageType.DebugMessage);
            config.DisableMessageType(NetIncomingMessageType.DiscoveryRequest);
            config.DisableMessageType(NetIncomingMessageType.DiscoveryResponse);
            config.DisableMessageType(NetIncomingMessageType.Error);
            config.DisableMessageType(NetIncomingMessageType.ErrorMessage);
            config.DisableMessageType(NetIncomingMessageType.NatIntroductionSuccess);
            config.DisableMessageType(NetIncomingMessageType.Receipt);
            config.DisableMessageType(NetIncomingMessageType.UnconnectedData);
            config.DisableMessageType(NetIncomingMessageType.VerboseDebugMessage);
            config.DisableMessageType(NetIncomingMessageType.WarningMessage);

           
            config.EnableMessageType(NetIncomingMessageType.UnconnectedData);
            config.EnableMessageType(NetIncomingMessageType.NatIntroductionSuccess);
            config.EnableMessageType(NetIncomingMessageType.StatusChanged);

            return config;
        }

        // Only for Introducer's NetworkServer
        public static NetPeerConfiguration GetStandardConfiguration(this NetPeerConfiguration self, int listeningPort)
        {
            var config = new NetPeerConfiguration("NovaRat")
            {
                AcceptIncomingConnections = true,
                Port = listeningPort
            };

           
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval);
            config.DisableMessageType(NetIncomingMessageType.ConnectionLatencyUpdated);
            config.DisableMessageType(NetIncomingMessageType.Data);
            config.DisableMessageType(NetIncomingMessageType.DebugMessage);
            config.DisableMessageType(NetIncomingMessageType.DiscoveryRequest);
            config.DisableMessageType(NetIncomingMessageType.DiscoveryResponse);
            config.DisableMessageType(NetIncomingMessageType.Error);
            config.DisableMessageType(NetIncomingMessageType.ErrorMessage);
            config.DisableMessageType(NetIncomingMessageType.NatIntroductionSuccess);
            config.DisableMessageType(NetIncomingMessageType.Receipt);
            config.DisableMessageType(NetIncomingMessageType.UnconnectedData);
            config.DisableMessageType(NetIncomingMessageType.VerboseDebugMessage);
            config.DisableMessageType(NetIncomingMessageType.WarningMessage);

         
            config.EnableMessageType(NetIncomingMessageType.UnconnectedData);
            config.EnableMessageType(NetIncomingMessageType.NatIntroductionSuccess);
            config.EnableMessageType(NetIncomingMessageType.StatusChanged);

            return config;
        }
    }
}