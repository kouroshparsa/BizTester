using BizTester.Libs;
using System.Collections.Generic;

namespace BizTester.Server
{
    class MLLP_Listener_Array: Listener
    {
        List<MLLP_Listener> listeners = new List<MLLP_Listener>();
        public MLLP_Listener_Array(string ports, bool sendAck, string ackCode, CustomLogger logger = null)
        {
            HashSet<string> used_ports = new HashSet<string>();
            foreach(string port_str in ports.Split(','))
            {
                if (!used_ports.Contains(port_str.Trim()))
                {
                    listeners.Add(new MLLP_Listener(port_str.Trim(), sendAck, ackCode, logger));
                }
            }
        }

        public override void Start() {
            foreach(MLLP_Listener listener in listeners)
            {
                listener.Start();
            }
        }
        public override void Stop()
        {
            foreach (MLLP_Listener listener in listeners)
            {
                listener.Stop();
            }
        }
    }
}
