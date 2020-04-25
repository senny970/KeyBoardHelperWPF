using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace KeyBoardHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.ComponentModel.IContainer components;
        double w = 0, h = 0;


        public MainWindow()
        {
            InitializeComponent();
            Stream iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/KeyBoardHelper;component/Icons/monitor.ico")).Stream;
            nIcon.Icon = new System.Drawing.Icon(iconStream);
            nIcon.Visible = true;
            //nIcon.ShowBalloonTip(5000, "Title", "Text", System.Windows.Forms.ToolTipIcon.Info);
            nIcon.MouseClick += nIcon_MouseClick;

            this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();

            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.menuItem1 });

            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Выход";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            nIcon.ContextMenu = this.contextMenu1;            

            nIcon.Text = "KeyBoardHelper";
            nIcon.Visible = true;
        }

        private void CloseButtonRectangle_Click(object sender, RoutedEventArgs e)
        {
            //Close();
            this.WindowState = WindowState.Minimized;
        }

        private void MinimizeButtonRectangle_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButtonRectangle_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                w = Width;
                h = Height;
                WindowState = WindowState.Maximized;
            }
            else
            {
                Width = w;
                Height = h;
                WindowState = WindowState.Normal;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();   
        }

        void nIcon_MouseClick(Object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Visibility = Visibility.Visible;
                WindowState = WindowState.Normal;
            }
        }

        private void menuItem1_Click(object Sender, EventArgs e)
        {
            this.Close();            
        }
    }
}
