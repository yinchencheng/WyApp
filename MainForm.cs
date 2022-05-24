using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using WY_App.Utility;

namespace WY_App
{
    public partial class MainForm : Form
    {
        //static ObservableCollection<double> _wetSlope = new ObservableCollection<double> { };
        
        public MainForm()
        {
            InitializeComponent();
            //string str = TcpClient.tcpClientSend("Tcp接入");
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
        }

        private void btn_Close_System_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定关闭程序吗？", "软件关闭提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LogHelper.Info("软件关闭。");
                notifyIcon1.Dispose();
                this.Close();
            }
        }

        private void btn_Minimizid_System_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            LogHelper.Info("窗体最小化。");

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();//隐藏主窗体  
                LogHelper.Info("主窗体隐藏。");
                this.WY_Software.Visible = true;//让notifyIcon1图标显示  
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//当鼠标点击为左键时  
            {
                this.Show();//显示主窗体  
                LogHelper.Info("主窗体恢复。");
                this.WindowState = FormWindowState.Maximized;//主窗体的大小为默认  
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string tcpReciveStr = TcpServer.tcp_Server_Send("S1");
            string[] a = tcpReciveStr.Split('+');
            var files = Directory.GetFiles(@"D:\SGVision\InspectImage", "*.*", SearchOption.AllDirectories); // 遍历所有文件
            var dirs = Directory.GetDirectories(@"D:\SGVision\InspectImage", "*", SearchOption.AllDirectories); //遍历所有文件夹
            var list = files.Union(dirs).OrderBy(s => s);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Parameter.commministion.PlcEnable)
            {
                HslCommunication HslCommunication = new HslCommunication();
            }
            else
            {

            }
            if (Parameter.commministion.TcpServerEnable)
            {
                TcpClient tcpClient = new TcpClient();
            }
            else
            {

            }

            if (Parameter.commministion.TcpServerEnable)
            {
                TcpServer tcpServer = new TcpServer();
            }
            else
            {

            }
            LogHelper.Info("初始化完成");
        }
    }
}
