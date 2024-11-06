using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BizTester.Libs
{
    class StreamHelper
    {
        public static void WriteToStream(Stream stream, string data)
        {
            //use UTF-8 and either 8-bit encoding due to MLLP-related recommendations
            var byteBuffer = Encoding.UTF8.GetBytes(data);

            //send a message through this connection using the IO stream
            stream.Write(byteBuffer, 0, byteBuffer.Length);
            stream.Flush();
        }

        public static string ReadStream(Stream stream)
        {
            string res;
            using(StreamReader reader = new StreamReader(stream))
            {
                res = reader.ReadToEnd();
            }
            return res;
        }

        public static async Task<string> AsyncReadStream(Stream stream, int timeout=4000)
        {
            byte[] buffer = new byte[1024];
            CancellationTokenSource cts = new CancellationTokenSource(timeout);
            Task<int> task = stream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                int readBytes = await task;
                string receivedData = Encoding.UTF8.GetString(buffer, 0, readBytes);
                return receivedData;
            }
            throw new TimeoutException();
        }
    }
}
