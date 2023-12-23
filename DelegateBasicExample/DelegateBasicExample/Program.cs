using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasicExample
{

    class Program
    {
        //delegate funciton that does not return value and has a string argument
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();

            LogDel logTextToScreen, logTextToFile;

            logTextToScreen = new LogDel(log.LogTextToScreen);
            logTextToFile = new LogDel(log.LogTextToFile);
            //combine two methods together for one variable 
            LogDel multiLogDel = logTextToFile + logTextToScreen;
            Console.WriteLine("please enter your name");
            var name = Console.ReadLine();

            LogText(logTextToFile, name);
            Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text) 
        {
            logDel(text);
        }
        
    }

    public class Log 
    {
        public void LogTextToScreen(string text)
        {
            //print the text and the time it is printed
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
