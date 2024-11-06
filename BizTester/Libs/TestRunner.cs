using BizTester.Client;
using BizTester.Models;
using BizTester.Server;
using BizTester.Simulation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTester.Libs
{
    public class TestRunner
    {
        private TestSpec testSpec;
        private CustomLogger logger;
        private const int LISTENER_TIMEOUT = 5;// seconds

        public TestRunner(TestSpec testSpec, DataGridView dataGridViewATLogs)
        {
            this.testSpec = testSpec;
            logger = new CustomLogger(dataGridViewATLogs);
        }

        internal void Run()
        {
            foreach(KeyValuePair<string, TestBase> kv in testSpec.tests)
            {
                string testName = kv.Key;
                TestBase tb = kv.Value;
                List<Listener> listeners = new List<Listener>();
                logger.Info($"Test Name: {testName} - Started");
                Dictionary<TestOutput, Listener> testOutputToListenerMap = new Dictionary<TestOutput, Listener>();

                foreach (KeyValuePair<string, TestOutput>entry in tb.outputs)
                {
                    TestOutput to = entry.Value;
                    Listener listener;
                    if(to.protocol == Protocol.File)
                    {
                        listener = new Folder_Listener(to.path);
                    }
                    else if (to.protocol == Protocol.MLLP)
                    {
                        listener = new MLLP_Listener(to.port, false, "AA");
                    }
                    else// if (to.protocol == Protocol.MSMQ)
                    {
                        listener = new MSMQ_Listener(to.queue);
                    }
                    listener.messageQueue = new ConcurrentQueue<string>();
                    testOutputToListenerMap.Add(to, listener);
                    listener.Start();
                    listeners.Add(listener);
                }
                
                foreach (var input in tb.inputs)
                {
                    if (!File.Exists(input.data_file))
                    {
                        logger.Error("Missing source file path. Skipping the test");
                        continue;
                    }
                    string data = HL7Helper.GetMessageFromFile(input.data_file);

                    if (input.protocol == Protocol.File)
                    {
                        File_Sender fs = new File_Sender(logger, input.path);
                        fs.Start(input.path);
                    }
                    else if (input.protocol == Protocol.MLLP) {
                        MLLP_Sender ms = new MLLP_Sender(logger, input.port, input.ip);
                        ms.Start(data);
                    }
                    else if (input.protocol == Protocol.MSMQ)
                    {
                        MSMQ_Sender ms = new MSMQ_Sender(logger, input.queue);
                        ms.Start(data);
                    }
                }
                
                int passedTests = 0;
                int failedTests = 0;
                foreach (KeyValuePair<string, TestOutput> entry in tb.outputs)
                {
                    TestOutput to = entry.Value;
                    Listener li = testOutputToListenerMap[to];
                    try {

                        int counter = 0;
                        while (li.messageQueue.Count < 1 && counter < LISTENER_TIMEOUT)
                        {
                            Thread.Sleep(1000);
                            counter += 1;
                        }

                        string[] results = li.messageQueue.ToArray();
                        
                        if(results.Length < 1)
                        {
                            logger.Info($"No data was received by the {li.GetType()} server.");
                        }

                        foreach (string data in results)
                        {
                            logger.Info("Received data to validate", data);
                            foreach(var val in to.validations)
                            {
                                try
                                {
                                    var tr = val.Validate(data);
                                    if (tr.passed)
                                    {
                                        logger.Info($"Validating {val.data_type} for {val.path} => {val.expectedResult} passed!");
                                        passedTests += 1;
                                    } else // failed
                                    {
                                        logger.Info($"Validating {val.data_type} for {val.path} Failed. Expected: {val.expectedResult} Actual: {tr.actualResult}");
                                        failedTests += 1;
                                    }
                                    
                                }
                                catch (Exception ex)
                                {
                                    logger.Info($"Validating {val.data_type} for {val.path}, Expected: {val.expectedResult} failed. {ex.Message}");
                                    failedTests += 1;
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERROR: {ex.Message}");
                    }
                    
                    
                }
                
                foreach (Listener listener in listeners)
                {
                    listener.Stop();
                }
                logger.Info($"Test Name: {testName} - {passedTests}/{passedTests+failedTests} validations passed.");
            }
        }
    }
}
