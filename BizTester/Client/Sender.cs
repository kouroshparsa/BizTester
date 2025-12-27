using BizTester.Helpers;
using System.Threading;

namespace BizTester.Client
{
    internal class Sender
    {
        internal CustomLogger logger;
        public virtual void Send(string msg) { }
    }
}
