using System.Net.Sockets;
using System.Text;

namespace MLLP_Sender
{
    internal class NetworkStreamReader
    {
        public async Task<string> ReadStringWithTimeout(NetworkStream networkStream, int timeoutMilliseconds)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(timeoutMilliseconds);

            var buffer = new byte[4096]; // Adjust buffer size as needed
            var stringBuilder = new StringBuilder();

            try
            {
                // Read from the network stream asynchronously
                using (var memoryStream = new MemoryStream())
                {
                    while (true)
                    {
                        var bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token);
                        if (bytesRead == 0)
                        {
                            // End of stream reached
                            break;
                        }

                        memoryStream.Write(buffer, 0, bytesRead);

                        // Check if a complete string is available
                        var data = memoryStream.ToArray();
                        var receivedString = Encoding.ASCII.GetString(data);
                        if (receivedString.Contains("\r\n"))
                        {
                            stringBuilder.Append(receivedString);
                            break;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Timeout occurred
                throw new TimeoutException("Timeout occurred while reading from the network stream.");
            }

            return stringBuilder.ToString();
        }
    }
}
