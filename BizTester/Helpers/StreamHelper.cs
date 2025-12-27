using BizTester.Helpers;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BizTester.Helpers
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

        public static string ReadQueueStream(Stream stream)
        {
            // Rewind if needed
            if (stream.CanSeek)
                stream.Position = 0;

            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, leaveOpen: true))
            {
                return reader.ReadToEnd();
            }
        }


        public static string ReadMLLPStream(Stream stream, int timeoutMilliseconds=8000)
        {
            if (stream.CanTimeout)
            {// MSMQ stream cannot timeout
                stream.ReadTimeout = timeoutMilliseconds;
            }

            var messageBuffer = new MemoryStream();
            var buffer = new byte[1];

            bool insideMessage = false;

            while (true)
            {
                int bytesRead = stream.Read(buffer, 0, 1); // Read byte by byte
                if (bytesRead == 0)
                    break; // Connection closed

                byte b = buffer[0];

                if (b == HL7Helper.BEGIN_MSG_INT) // VT
                {
                    messageBuffer.SetLength(0);
                    insideMessage = true;
                    continue;
                }

                if (b == HL7Helper.END_MSG_INT) // FS
                {
                    // Expect next byte to be CR
                    int crByte = stream.ReadByte();
                    if (crByte == 0x0D) // CR
                    {
                        break; // End of message
                    }
                    else
                    {
                        throw new Exception("Malformed MLLP message: missing CR after FS");
                    }
                }

                if (insideMessage)
                {
                    messageBuffer.WriteByte(b);
                }
            }

            messageBuffer.Flush();
            messageBuffer.Position = 0;
            using (StreamReader reader = new StreamReader(messageBuffer, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
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
