using System;
using System.Windows.Forms;
using SkylineProblemVisualizer.Controllers;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.Utilities;

namespace SkylineProblemVisualizer
{
    static class Program
    {
        private static IFormController controller;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(OnGuiUnhandedException);
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                controller = new MainFormController();
                using (var form = new MainForm(controller))
                {
                    Application.Run(form);
                }
            }
            catch (Exception e)
            {
                HandleUnhandledException(e);
            }
            finally
            {
                // Cleanup
            }
        }

        private static void HandleUnhandledException(Object o)
        {
            Exception e = o as Exception;
            if (e != null)
            {
                LogHelper.LogException(e);

                var result = ShowThreadExceptionDialog("An error has occurred", e);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    // Just continue on with application
                    // We've logged it.
                }
            }
        }

        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. \n\n" +
                              "Press 'Yes' to abort application.\n" +
                              "Press 'No' to ignore this error and continue.\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }


        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(e.ExceptionObject);
        }

        private static void OnGuiUnhandedException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception);
        }
    }
}


