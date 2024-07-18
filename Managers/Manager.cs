using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Providers;
using Network;
using Nini.Config;
using System.Threading.Tasks;
using Providers.Nova.Modules;
using Managers.Extensions;

namespace Managers
{
    
    public abstract class Manager<T>
        where T : Provider
    {
       
        public virtual T Provider { get; private set; }

        
        public NetworkPeer Network { get { return Provider.Network; } }

       
        public IConfig Config { get { return Provider.Config; } }

       
        public Manager(T provider)
        {
            Provider = provider;
            Provider.RegisterMessageHandlers();
        }

        public TaskCompletionSource<T> RegisterAsTask<T>(ref EventHandler<T> eventMethod)
            where T : EventArgs
        {
            TaskCompletionSource<T> tcs = null;
            try
            {
                
                tcs = new TaskCompletionSource<T>();

                
                EventHandler<T> eventHandler = null;
                eventHandler = (s, e) => tcs.TrySetResult(e);
                eventMethod += eventHandler;

                // Remove all completed event handlers
                Delegate[] delegates = eventMethod.GetInvocationList();

                if (delegates.Length > 1)
                {
                    for (int i = 0; i < delegates.Length; i++)
                    {
                        try
                        {
                            dynamic dynamicDelegateTarget = delegates[i].Target;
                            if (dynamicDelegateTarget.tcs.Task.Status == TaskStatus.RanToCompletion)
                            {
                                eventMethod -= (EventHandler<T>)delegates[i];
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch { }

           
            return tcs;
        }

        
    }
}
