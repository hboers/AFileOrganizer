using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Notify = System.Windows.Forms;
using System.Drawing;
using Business;


namespace AFileOrganizer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BFilesHandler _bfilesHandler; 
        private Thread thread;

        //This is using windows forms. I am going to use this to hide the application to the system tray.
        private Notify.NotifyIcon notifyIcon;

        public MainWindow()
        {
                InitializeComponent();
                
                //NotifyIcon Section.
                notifyIcon = new Notify.NotifyIcon();

                //Event for double click.
                notifyIcon.MouseDoubleClick += new Notify.MouseEventHandler(notifyIcon_DoubleClick);

                notifyIcon.BalloonTipText = "AFileOrganizer is still running!";
                notifyIcon.BalloonTipTitle = "AFileOrganizer";

                //Getting icon from this MainWindow.xaml
                notifyIcon.Icon = new Icon("Icono.ico");
                //End of notifyIcon Section.
                
                _bfilesHandler = new BFilesHandler();
                 thread = new Thread(new ThreadStart(_bfilesHandler.Begin));
                 this.thread.Start();
                 btnStart.Content = "Running";
        }

        //This event will handle the double click event on the notificationIcon when It is in the system tray.
        private void notifyIcon_DoubleClick(object sender, Notify.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.Show();
        }

        private void btnAssociation_Click(object sender, RoutedEventArgs e)
        {
            AssociationsManager _associationMananger = new AssociationsManager();
            _associationMananger.ShowDialog();
        }

        private void btnObserver_Click(object sender, RoutedEventArgs e)
        {
            FolderManager _folderMananger = new FolderManager();
            _folderMananger.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.thread.Abort();
        }


        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {

                this.notifyIcon.Visible = true;
                this.notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.notifyIcon.Visible = false;
            }
        }
    }
}
