using BizTester.Helpers;
using System.Collections.Concurrent;
using System.Threading;

namespace BizTester.Server
{
    class Listener
    {
        internal bool isListening = false;
        internal Thread listenThread;
        internal CustomLogger logger;
        internal ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        internal string label = "inputs";
        public virtual void Start() { }
        public virtual void Stop()
        {
            if (listenThread != null && listenThread.IsAlive)
            {
                isListening = false;
            }
            logger.Info($"Stopped listening on {label}");
        }
        
    }
}
