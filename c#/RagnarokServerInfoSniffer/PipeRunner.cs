
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using PipeEvent;

namespace PipeRunner
{
    class PipeRunner
    {
        // static Queue<string> inputQueue = new Queue<string>();
        static Queue<string> outputQueue = new Queue<string>();

        public PipeRunner()
        {
            Thread readThread = new Thread(ConsoleInputReader);
            Thread writeThread = new Thread(ConsoleOutputWriter);

            readThread.Start();
            writeThread.Start();

            readThread.Join();
            writeThread.Join();
        }

        static void ConsoleInputReader()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (PipeEventHelper.IsPipeEvent(input))
                {
                    Console.WriteLine("IsPipeEvent");
                }
                else
                {
                    Console.WriteLine("Not PipeEvent");
                }
            }
        }

        static string GetOutputToWrite()
        {
            // Check if there is any output in the output queue
            if (outputQueue.Count > 0)
            {
                // Dequeue and return the output
                return outputQueue.Dequeue();
            }

            // No output to write
            return null;
        }

        static void ConsoleOutputWriter()
        {
            while (true)
            {
                // Get the output to write
                string output = GetOutputToWrite();

                if (output != null)
                {
                    Console.WriteLine(output);
                }

                // Sleep for a while before checking for output again
                Thread.Sleep(1000);
            }
        }
    }
}

