using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RemotePcControl.OwinService
{
    class ServiceInit
    {
        private static NotifyIcon TrayIcon;


        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static readonly IntPtr ThisConsole = GetConsoleWindow();


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static Int32 _showWindow = 0;

        private const string ApplicationText = "Service Running";


        static void Main(string[] args)
        {
            TryIconInit();

            var owinWebApiService = new OwinWebApiService("http://localhost:9961/");
            owinWebApiService.Start();

            Application.Run();
        }
        
        static void TryIconInit()
        {
            TrayIcon = new NotifyIcon();
            TrayIcon.Icon = new Icon("icon.ico");
            TrayIcon.MouseClick += TrayIconClick;
            TrayIcon.Visible = true;
            TrayIcon.BalloonTipText = ApplicationText;
            TrayIcon.Text = ApplicationText;
            TrayIcon.ShowBalloonTip(500);

            ShowWindow(ThisConsole, _showWindow);

            TrayIcon.ContextMenuStrip = new ContextMenuStrip();
            TrayIcon.ContextMenuStrip.Items.AddRange(new ToolStripItem[] { new ToolStripMenuItem() });
            TrayIcon.ContextMenuStrip.Items[0].Text = "Exit";
            TrayIcon.ContextMenuStrip.Items[0].Click += SmoothExit;

        }

        private static void TrayIconClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                _showWindow = ++_showWindow % 2;
                ShowWindow(ThisConsole, _showWindow);
            }
        }

        private static void SmoothExit(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            Application.Exit();
            Environment.Exit(1);
        }
    }
}