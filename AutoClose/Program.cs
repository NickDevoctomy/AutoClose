using AutoClose.Debugging;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoClose
{
    static class Program
    {


        #region public properties

        public static String LogFile { get; private set; }

        public static BasicTextLogger Logger { get; private set; }

        public static Boolean cBlnIsLogging { get; private set; }

        public static Boolean AllowClose { get; set; }

        public static Boolean FirstRun { get; private set; }

        #endregion

        #region applicaton entry point

        [STAThread]
        static void Main()
        {
            String pStrAppDataPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            String pStrLogPath = String.Format(@"{0}Low\devoctomy\AutoClose\Log.txt", pStrAppDataPath);
            FileInfo pFIoLog = new FileInfo(pStrLogPath);
            pFIoLog.Directory.Create();
            LogFile = pFIoLog.FullName;

            StartLogging();

            FirstRun = Properties.Settings.Default.FirstRun;
            Properties.Settings.Default.FirstRun = false;
            Properties.Settings.Default.Save();

            if(FirstRun)
                Logger.WriteLine(BasicTextLogger.MessageType.info, "This is the first time this application has been launched, start hidden setting will be ignored.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            Logger.WriteLine(BasicTextLogger.MessageType.info, "AutoClose closing normally, your system will not be protected until started again.");
        }

        #endregion

        #region public methods

        public static void StartLogging()
        {
#if DEBUG
            if(!cBlnIsLogging)
            {
                if(Logger != null)
                    Logger.Close();
                Logger = BasicTextLogger.Create(LogFile, BasicTextLogger.MessageType.all);
                Logger.WriteLine(BasicTextLogger.MessageType.info, "AutoClose starting.");
                cBlnIsLogging = true;
                return;
            }

#else
            if (Properties.Settings.Default.Log)
            {
                if (!cBlnIsLogging)
                {
                    if (Logger != null)
                        Logger.Close();
                    Logger = BasicTextLogger.Create(LogFile, BasicTextLogger.MessageType.all);
                    Logger.WriteLine(BasicTextLogger.MessageType.info, "AutoClose starting.");
                    cBlnIsLogging = true;
                }
            }
            else
            {
                Logger = BasicTextLogger.CreateDummy();
                cBlnIsLogging = false;
            }
#endif
        }

        #endregion

    }
}
