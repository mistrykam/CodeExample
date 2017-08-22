using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Logger
{
    static object syncObject = new object();

    StreamWriter sw;
    int logNumber = 0;
    static Logger myLogger = null;

    private Logger() // prevent the direct creation of this type
    {
    }

    public static Logger CreateInstance()
    {
        lock (syncObject)
        {
            if (myLogger == null)
                myLogger = new Logger();
        }

        return myLogger;
    }

    public void LoggerOpen()
    {
        sw = new StreamWriter(@"c:\temp\log.txt");
    }

    public void LogEntry(string message)
    {
        sw.WriteLine("Log {0} :: {1}", logNumber++, message);
    }

    public void LoggerClose()
    {
        sw.Close();
        sw = null;
    }
}


public class Example15
{
    public static void ExampleCode1()
    {
        Logger logger = Logger.CreateInstance();

        logger.LoggerOpen();
        logger.LogEntry("This is the first entry.");
        logger.LogEntry("This is the second entry.");
        logger.LoggerClose();
    }
}

