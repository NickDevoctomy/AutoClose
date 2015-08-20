using AutoClose.Extensions;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace AutoClose.Debugging
{

    ///TODO:  Make this class IDisposable

    /// <summary>
    /// A basic, fast text based logger
    /// </summary>
    public class BasicTextLogger 
    {

        #region public enums

        [Flags()]
        public enum MessageType
        {
            none = 0,
            debug = 1,
            info = 2,
            warn = 4,
            error = 8,
            critical = 16,
            all = 31
        }

        #endregion

        #region private objects

        private String cStrFullPath = String.Empty;
        private FileStream cFSmOutput;
        private StreamWriter cSWrOutput;
        private MessageType cMTeTypes;

        #endregion

        #region public properties

        /// <summary>
        /// Full path of the log file being written to
        /// </summary>
        public String FullPath
        {
            get { return (cStrFullPath); }
        }

        /// <summary>
        /// The type of messages to log, must be set on construction
        /// </summary>
        public MessageType Types
        {
            get { return (cMTeTypes); }
        }

        #endregion

        #region constructor / destructor

        /// <summary>
        /// Constructor, this constructor should be used to start a dummy logger that doesn't output anything
        /// </summary>
        private BasicTextLogger()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iFullPath">Full path of the log file to create.</param>
        /// <param name="iMessageTypes">The type of messages that you would like logged, anything else is ignored.</param>
        private BasicTextLogger(String iFullPath, MessageType iMessageTypes)
        {
            cStrFullPath = iFullPath;
            cFSmOutput = File.Open(iFullPath, FileMode.Append, FileAccess.Write, FileShare.Read);
            cSWrOutput = new StreamWriter(cFSmOutput);
            cSWrOutput.AutoFlush = true;
            cMTeTypes = iMessageTypes;

            WriteLine(MessageType.debug, "Debugger initialised to display '{0}' messages.", iMessageTypes.ToString());
        }

        #endregion

        #region public methods

        /// <summary>
        /// Create a debugger, initialises the file stream and stream writter ready for outputting to
        /// </summary>
        /// <param name="iOwnerApp">Owner App for this logger instance.  Set to null of no App is associated.</param>
        /// <param name="iFullPath">Full path of the log file to create.</param>
        /// <param name="iMessageTypes">The type of messages that you would like logged, anything else is ignored.</param>
        /// <returns></returns>
        public static BasicTextLogger Create(String iFullPath, MessageType iMessageTypes)
        {
            BasicTextLogger pBTLLogger = new BasicTextLogger(iFullPath, iMessageTypes);
            return (pBTLLogger);
        }

        /// <summary>
        /// Create an instance of a dummy logger that doesn't output anything
        /// </summary>
        /// <returns></returns>
        public static BasicTextLogger CreateDummy()
        {
            BasicTextLogger pBTLLogger = new BasicTextLogger();
            return (pBTLLogger);
        }

        /// <summary>
        /// Close the logger and clean up the disposable objects
        /// </summary>
        public void Close()
        {
            if(cSWrOutput != null)
            {
                cSWrOutput.Flush();
                cSWrOutput.Dispose();
                cSWrOutput = null;
            }
        }

        /// <summary>
        /// Output a message to the console and log file but after being passed through the configured
        /// message types filter
        /// </summary>
        /// <param name="iType">The type of the message to write to the log</param>
        /// <param name="iLine">The message to log</param>
        /// <param name="iArgs">The arguments to format into the message</param>
        public void WriteLine(MessageType iType, String iLine, params Object[] iArgs)
        {
            if(cSWrOutput != null)
            {
                if (cMTeTypes.HasFlag(iType))
                {
                    if (iArgs != null && iArgs.Length > 0)
                        iLine = String.Format(iLine, iArgs);
                    cSWrOutput.WriteLine(DateTime.UtcNow.ToString() + " :: " + iType.ToString().ToUpper() + " :: " + iLine);
                    Console.WriteLine(DateTime.UtcNow.ToString() + " :: " + iType.ToString().ToUpper() + " :: " + iLine);
                }
            }
        }

        public void WriteLineToSubLog(String iRelativePath, MessageType iType, String iLine, params Object[] iArgs)
        {
            if (cSWrOutput != null)
            {
                if (cMTeTypes.HasFlag(iType))
                {
                    Mutex pMutMutex = new Mutex(false, iRelativePath.EncodeHex());
                    try
                    {
                        pMutMutex.WaitOne();
                        if (iArgs != null && iArgs.Length > 0)
                            iLine = String.Format(iLine, iArgs);
                        cSWrOutput.WriteLine(DateTime.UtcNow.ToString() + " :: " + iType.ToString().ToUpper() + " :: " + iLine);
                        String pStrMessage = DateTime.UtcNow.ToString() + " :: " + iType.ToString().ToUpper() + " :: " + iLine;

                        String pStrPath = new FileInfo(FullPath).Directory.FullName;
                        if (!pStrPath.EndsWith("\\"))
                            pStrPath += "\\";
                        iRelativePath = iRelativePath.TrimStart(new Char[] { '\\' });
                        pStrPath += iRelativePath;
                        new FileInfo(pStrPath).Directory.Create();
                        File.AppendAllText(pStrPath, pStrMessage + "\r\n");
                    }
                    finally
                    {
                        pMutMutex.ReleaseMutex();
                        pMutMutex.Dispose();
                    }
                }
            }            
        }

        /// <summary>
        /// Write an exception message to the log, this is formatted differently to make it stand out
        /// </summary>
        /// <param name="iException">The exception to print to the log</param>
        public void WriteException(Exception iException)
        {
            if (cSWrOutput != null)
            {
                if (cMTeTypes.HasFlag(MessageType.debug))
                {
                    StringBuilder pSBrMessage = new StringBuilder();
                    pSBrMessage.AppendLine(new string('-', 64));
                    pSBrMessage.AppendLine(DateTime.UtcNow.ToString() + " :: EXCEPTION :: " + iException.ToString());
                    pSBrMessage.AppendLine(new string('-', 64));
                    cSWrOutput.WriteLine(pSBrMessage.ToString());
                    Console.WriteLine(pSBrMessage.ToString());
                    Console.WriteLine(DateTime.UtcNow.ToString() + " :: " + pSBrMessage.ToString());
                }
            }
        }

        #endregion

    }

}
