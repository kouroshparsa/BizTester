using BizTester.Helpers;
using System.Threading;

namespace BizTester.Client
{
    internal class Sender
    {
        internal bool isCancelled = false;
        internal CustomLogger logger;
        public virtual void Send(string msg, string fileName) { }

        public virtual void Close() { }

        public void Cancel()
        {
            isCancelled = true;
        }
    }
}
