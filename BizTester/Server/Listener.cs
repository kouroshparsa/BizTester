using BizTester.Helpers;
using System.Collections.Concurrent;
using System.Threading;

namespace BizTester.Server
{
    class Listener
    {
        internal bool isListening = true;
        internal Thread listenThread;
        internal CustomLogger logger;
        internal ConcurrentQueue<string> messageQueue;

        public virtual void Start() { }
        public virtual void Stop()
        {
            if (listenThread != null && listenThread.IsAlive)
            {
                isListening = false;
            }
            logger.Info("Server is stopped.");
        }
        
    }
}
