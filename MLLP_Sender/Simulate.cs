namespace BizTester
{
    internal class Simulate
    {
        const string sampleDataPath = "../../../sample_data.hl7v2";

        public void Send()
        {
            Console.Write("Enter Port:");
            string line;
            line = Console.ReadLine();
            int port;
            bool success = int.TryParse(line, out port);
            while (!success || port < 1)
            {
                Console.WriteLine("Invalid port.");
                Console.Write("Enter Port:");
                line = Console.ReadLine();
                success = int.TryParse(line, out port);
            }

            Client client = new Client();
            await client.SendAsync(port, sampleDataPath);
        }

    }
}
