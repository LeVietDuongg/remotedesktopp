using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Network;
using Nini.Config;

namespace Providers
{
   
    public abstract class Provider
    {
       
        public NetworkPeer Network { get; private set; }

       
        public IConfig Config { get; private set; }

        protected Provider(NetworkPeer network)
        {
            Network = network;

            try
            {
                Config = new IniConfigSource(Path.Combine(Application.StartupPath, "config.ini")).Configs["NovaRat"];
            }
            catch (FileNotFoundException)
            {
                string defaultConfigText = "; Nova Remote Assistance Tool INI Configuration File" + Environment.NewLine +
                                                 "[NovaRat]" + Environment.NewLine +
                                                 "; Uncomment the line below for the public Introducer running on an Amazon EC2 server" + Environment.NewLine +
                                                 "; IntroducerEndPoint = 50.18.245.235:16168" + Environment.NewLine +
                                                 "; Comment the line below to stop using your own Introducer" + Environment.NewLine +
                                                 "IntroducerEndPoint = 127.0.0.1:16168" + Environment.NewLine +
                                                 "MaxNumConnectionAttemptsPerMachine = 3" + Environment.NewLine +
                                                 "BanTime = 60";

                File.WriteAllText(Path.Combine(Application.StartupPath, "config.ini"), defaultConfigText);

                Config = new IniConfigSource(Path.Combine(Application.StartupPath, "config.ini")).Configs["NovaRat"];
            }

            RegisterMessageHandlers();
        }

        public abstract void RegisterMessageHandlers();
    }
}
