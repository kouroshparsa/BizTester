using BizTester.Libs;
using System.Threading;

namespace BizTester.Client
{
    internal class Sender
    {
        internal bool isListening = true;
        internal Thread listenThread;
        internal CustomLogger logger;

        public virtual void Start(string msg) { }
        public virtual void Stop()
        {
            if (listenThread != null && listenThread.IsAlive)
            {
                isListening = false;
            }
        }
    }
}
