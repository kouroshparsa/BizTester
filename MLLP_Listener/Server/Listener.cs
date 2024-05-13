using BizTester.lib;

namespace BizTester.Server
{
    class Listener
    {
        internal bool isListening = true;
        internal Thread? listenThread;
        internal CustomLogger? logger;
        public virtual void Start() { }
        public virtual void Stop()
        {
            if (listenThread != null && listenThread.IsAlive)
            {
                isListening = false;
            }
        }
    }
}
