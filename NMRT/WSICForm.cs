using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using InformationCollection;
using Common;
using XmlProcess;
using System.Threading;
using System.Net.Sockets;


namespace WSIC
{
    public partial class WSICForm : Form
    {

        private ResourceCollection resColl = new ResourceCollection();
        delegate void AddToDataGirdViewCallBack(ArrayList infoList);
        delegate void AddToOutputLogCallBack(String logStr);
        delegate void SetToolsStripButtonCallBack();
        private BackgroundWorker infoListBackgroundWorker;
        private IList<string> HostCheck = new List<string>();
        private static bool exitCtrl = false;
        private Thread getInfoThread;
        private ThreadStart getInfoEntryPoint;
        private WaitForm wf = new WaitForm();
        private int waitCount = 0;
        private IList<string> hostProperties;
        private IList<string> wmiProperties;
        private System.ComponentModel.IContainer components = null;


        public WSICForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void nmonRunToolStripButton_Click(object sender, EventArgs e)
        {
            string ipAddressValue = string.Empty;
            string userNameValue = string.Empty;
            string passwordValue = string.Empty;
            ArrayList matchValueArray = new ArrayList();
            ArrayList cimArray = new ArrayList();
            ArrayList resultArray = new ArrayList();
            ArrayList queryArray = new ArrayList();
            XmlConfigration configration = new XmlConfigration();
            string tempStr = String.Empty;
            this.WindowsToolStripButton.Enabled = false;
            this.logTextBox.Text = string.Empty;
            int i = 0;
            try
            {
                configration.Load(@"config\WinConfiguration.xml");
                hostProperties = configration.HostProperties;
                wmiProperties = configration.WMIParameterProperties;
                this.ResourceTabPage.Text = "Windows";
                this.POTabControl.SelectTab(this.ResourceTabPage);
                this.windowsDataGridView.Rows.Clear();
                if (wmiProperties.Count > 0)
                {
                    this.windowsDataGridView.ColumnCount = wmiProperties.Count + 1;
                    this.windowsDataGridView.Columns[i].Name = "IP地址";
                    foreach (string content in wmiProperties)
                    {
                        i++;
                        string[] contenetTitle = content.Split(',');
                        this.windowsDataGridView.Columns[i].Name = contenetTitle[1];
                        matchValueArray.Add(contenetTitle[2]);
                        cimArray.Add(contenetTitle[3]);
                    }
                }
                else
                {
                    throw new PerfOptimizeException("需要检查的参数个数：{0}", null, new object[] { wmiProperties.Count });
                }
                this.windowsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                this.windowsDataGridView.ReadOnly = true;
                this.windowsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.windowsDataGridView.ColumnHeadersVisible = true;
                //if (hostProperties.Count > 0)
                //{
                //     CheckHostConnection(hostProperties); 
                //}
                if (hostProperties.Count > 0)
                {
                    foreach (string host in hostProperties)
                    {
                        string[] hostValue = host.Split(',');
                        getInfoEntryPoint = delegate { LoadSystemInfo(hostValue[0], hostValue[2], hostValue[3], matchValueArray, cimArray); };
                        getInfoThread = new Thread(getInfoEntryPoint);
                        getInfoThread.Start();
                    }
                }
                //else if (this.CheckHostResult.Count > 0 && MessageBox.Show("部分服务器无法连接，是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                //    foreach (string host in this.CheckHostResult)
                //    {
                //        string[] hostValue = host.Split(',');
                //        getInfoEntryPoint = delegate { LoadSystemInfo(hostValue[0], hostValue[2], hostValue[3], matchValueArray, cimArray); };
                //        getInfoThread = new Thread(getInfoEntryPoint);
                //        getInfoThread.Start();
                //    }
                //}
                else
                {
                    this.WindowsToolStripButton.Enabled = true;
                }
                waitCount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认要退出程序吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (getInfoThread == null)
                {
                    base.OnFormClosing(e);
                }
                else if (getInfoThread != null && (getInfoThread.ThreadState == ThreadState.Running || getInfoThread.ThreadState == ThreadState.WaitSleepJoin))
                {
                    exitCtrl = true;
                    getInfoThread.Abort();
                    Thread.Sleep(1000);
                    base.OnFormClosing(e);
                }
                else
                {
                    base.OnFormClosing(e);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        public int CheckHostConnection(string hoststr)
        {
            HostCheck.Clear();
            this.OutputExecuteLog("服务器" + hoststr  + "开始检查连接情况");
            TcpClient client = new TcpClient();
            client.SendTimeout = 2000;
            try
            {
                client.Connect(hoststr, 139);
                this.OutputExecuteLog("Succ:服务器" + hoststr + "连接正常");
                //HostCheck.Add(hoststr);
                return 0;
            }
            catch
            {
                this.OutputExecuteLog("Error:服务器" + hoststr + "无法连接，请检查本地网络连接是否正常;配置文件(WinConfiguration.xml)里的IP地址配置是否正确;目标服务器Windows防火墙配置;目标服务器Computer Browser服务是否启动");
                return 1;
            }
            finally
            {
                client.Close();
            }
        }

        public void LoadSystemInfo(string tmpPfIPAddress, string tmpPfUserName, string tmpPfPassword, ArrayList tmpPfMatchValueArray, ArrayList tmpCim)
        {
            ArrayList queryArray = new ArrayList();
            try
            {
                if (this.CheckHostConnection(tmpPfIPAddress) == 0)
                {
                    this.OutputExecuteLog("服务器" + tmpPfIPAddress + "开始获取信息");
                    queryArray = this.resColl.GetSystemInfo(tmpPfIPAddress, tmpPfUserName, tmpPfPassword, tmpPfMatchValueArray, tmpCim);
                    if (queryArray == null)
                    {
                        this.OutputExecuteLog("Error:服务器" + tmpPfIPAddress + "部分配置的检查项目不被操作系统支持");
                    }
                    else
                    {
                        this.AddToDataGirdView(queryArray);
                        this.OutputExecuteLog("Succ:服务器" + tmpPfIPAddress + "获取信息完成");
                    }
                }
                else
                {
                    this.SetToolsStripButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddToDataGirdView(ArrayList infoList)
        {
            if (this.windowsDataGridView.InvokeRequired)
            {
                AddToDataGirdViewCallBack add = new AddToDataGirdViewCallBack(AddToDataGirdView);
                this.Invoke(add, new object[] { infoList });
            }
            else
            {
                waitCount++;
                if (!exitCtrl)
                    this.windowsDataGridView.Rows.Add(infoList.ToArray());
                if (waitCount == hostProperties.Count)
                {
                    this.WindowsToolStripButton.Enabled = true;
                }
            }
        }

        private void OutputExecuteLog(string logStr)
        {
            if (this.logTextBox.InvokeRequired)
            {
                AddToOutputLogCallBack add = new AddToOutputLogCallBack(OutputExecuteLog);
                this.Invoke(add, new object[] { logStr });
            }
            else
            {
                logTextBox.Text += "===>" + logStr + "\r\n"; 
            }
        }

        private void SetToolsStripButton()
        {
            if (this.nmrtStatusStrip.InvokeRequired)
            {
                SetToolsStripButtonCallBack add = new SetToolsStripButtonCallBack(SetToolsStripButton);
                this.Invoke(add, new object[] {});
            }
            else
            {
                this.WindowsToolStripButton.Enabled = true;
            }
        }

        public int PfWaitCount
        {
            get
            {
                return waitCount;
            }
            set
            {
                waitCount = value;
            }
        }

        public IList<string> CheckHostResult
        {
            get
            {
                return HostCheck;
            }
            set
            {
                HostCheck = value;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo oInfo = new System.Diagnostics.ProcessStartInfo();
            oInfo.FileName = "hh.exe";
            oInfo.Arguments = "perfoptimize.chm";
            System.Diagnostics.Process proc;
            try
            {
                proc = System.Diagnostics.Process.Start(oInfo);
                //proc.WaitForExit(300000);
                //if (proc.HasExited == false)
                //{
                //    proc.Kill();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
