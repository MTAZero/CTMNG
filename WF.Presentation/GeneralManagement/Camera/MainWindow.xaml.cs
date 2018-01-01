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
using NetSDKCS;
using System.Windows.Forms.Integration;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Xml;
using GeneralManagement.Common;
using System.Xml.Linq;

namespace GeneralManagement.Camera
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //device list for manage deivce.
        public List<Device> m_DeviceList = new List<Device>();
        //manage windowsForm control Host list.
        private List<WindowsFormsHost> m_WindowsFormsHostList = new List<WindowsFormsHost>();
        //manage monitor information.
        private Dictionary<int, Device> m_MonitorDic = new Dictionary<int, Device>();
        //manage savedata handel.
        private List<IntPtr> m_SaveDataHandleList = new List<IntPtr>();

        //call back for receive real data .
        private fRealDataCallBackEx m_RealDataCallBack;
        //call back for realplay disconnect.
        private fRealPlayDisConnectCallBack m_RealPlayDisConnectCallBack;
        //call back for reconnect to device.
        private fHaveReConnectCallBack m_ReConnectCallBack;
        //call back for capture image and save image.
        private fSnapRevCallBack m_SnapRevCallBack;

        //check is fullscreen.
        private bool m_IsFullModel = false;
        //monitor selected number.
        private int m_SelectedLayoutNumber = 0;
        //check is set capture callback.
        private bool m_IsSetCaptureCallBack = false;

        //monitor count.
        private const int MaxMonitorCount = 9;
        // wait time.
        private const uint TimeOut = 3000;
        // PTZ control speed.
        private const int SpeedValue = 1;

        private uint m_SnapSerialNum = 1000;

        //for stream type
        public struct ComboxItem
        {
            public int type;
            public string text;

            public ComboxItem(int _type, string _text)
            {
                type = _type;
                text = _text;
            }
            public override string ToString()
            {
                return text;
            }
        }
        string RoomName;
        public MainWindow(string _RoomName)
        {
            
         
            InitializeComponent();
            this.RoomName = _RoomName;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NETClient.Cleanup();
                
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            m_RealDataCallBack = new fRealDataCallBackEx(RealDataCallBack); //instance realdata callback.
            m_RealPlayDisConnectCallBack = new fRealPlayDisConnectCallBack(RealPlayDisConnectCallBack); //instance realplay disconnect callback.
            m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack); //instance reconnect callback.
            m_SnapRevCallBack = new fSnapRevCallBack(SnapRevCallBack); // instance capture callback.
            NETClient.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero); //set reconnect callback.
            ReadXmlConfig();
        }

        private void ReadXmlConfig()
        {

            if (File.Exists(Constant.PATH_CONFIG_CAM))
            {
                try
                {
                    XmlDocument xDoc = new XmlDocument();

                    using (XmlReader read = XmlReader.Create(Constant.PATH_CONFIG_CAM))
                    {
                        xDoc.Load(read);
                      
                        XmlNodeList xmlnodeList = xDoc.DocumentElement.SelectNodes("Phong");

                        List<CamConfig> camconfig = new List<CamConfig>();
                        foreach (XmlNode node in xmlnodeList)
                        {
                            string text = node.Attributes["ID"].Value;
                            if (text == RoomName)
                            {
                                CamConfig cam = new CamConfig();
                                cam.IP = node.SelectSingleNode("IP").InnerText;
                                cam.Port = node.SelectSingleNode("Port").InnerText;
                                cam.User = node.SelectSingleNode("User").InnerText;
                                cam.Pass = node.SelectSingleNode("PassWord").InnerText;
                                
                                NET_DEVICEINFO_Ex deviceInfo = new NET_DEVICEINFO_Ex();
                                int error = 0;
                                try
                                {
                                    //call login function.
                                    ushort dev_port = 0;
                                    try
                                    {
                                        dev_port = Convert.ToUInt16(cam.Port);
                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show("ID_PORTERROR");
                                        return;
                                    }
                                    IntPtr loginID = NETClient.Login(cam.IP, dev_port, cam.User, cam.Pass, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
                                    //  IntPtr loginID =(IntPtr) 0x000000cda2744cc0;

                                    if (loginID != IntPtr.Zero)
                                    {
                                        Device device = new Device();
                                        device.IP = cam.IP;
                                        device.LoginID = loginID;
                                        device.ChannelCount = deviceInfo.nChanNum;
                                        m_DeviceList.Add(device);
                                        TreeViewItem head = new TreeViewItem();
                                        head.Header = cam.IP + "(online)";
                                        head.Tag = device;
                                        //set double click event for head node.
                                        head.MouseDoubleClick += new MouseButtonEventHandler(head_MouseDoubleClick);
                                        for (int i = 0; i < deviceInfo.nChanNum; i++)
                                        {
                                            TreeViewItem child = new TreeViewItem();
                                            child.Header = "chanel " + i.ToString();
                                            child.Tag = i;
                                            //set double click event for child node.
                                            child.PreviewMouseDoubleClick += new MouseButtonEventHandler(child_PreviewMouseDoubleClick);
                                            head.Items.Add(child);
                                        }
                                        treeView.Items.Add(head);
                                    }
                                }
                                catch (Exception ex)
                                {

                                    if (ex is NETClientExcetion)
                                    {
                                        MessageBox.Show(this, (ex as NETClientExcetion).Message);
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, ex.Message);
                                    }
                                }
                            }
                        }
                        read.Close();
                        read.Dispose();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("Định dạng file cấu hình sai hoặc chưa cấu hình camera cho phòng thi");
                }
               
            }


            }

        //init UI
        private void Init()
        {
         
            InitComboxType();
            InitMonitorDic();
            InitHostList();
           
        }

        //init stream type
        public void InitComboxType()
        {
            ComboxItem mainItem = new ComboxItem((int)EM_RealPlayType.Realplay, "ID_MAINSTREAM");
            ComboxItem subItem = new ComboxItem((int)EM_RealPlayType.Realplay_1, "ID_SUBSTREAM");
            this.type_combox.Items.Add(mainItem);
            this.type_combox.Items.Add(subItem);
            this.type_combox.SelectedItem = mainItem;
        }

        //init monitor information.
        public void InitMonitorDic()
        {
         
            m_MonitorDic.Clear();
            for (int i = 0; i < MaxMonitorCount; i++)
            {
                m_MonitorDic.Add(i, null);
            }
           
        }

        // add all winform host to list.
        public void InitHostList()
        {
          
            m_WindowsFormsHostList.Clear();
            m_WindowsFormsHostList.Add(host0);
            m_WindowsFormsHostList.Add(host1);
            m_WindowsFormsHostList.Add(host2);
            m_WindowsFormsHostList.Add(host3);
            m_WindowsFormsHostList.Add(host4);
            m_WindowsFormsHostList.Add(host5);
            m_WindowsFormsHostList.Add(host6);
            m_WindowsFormsHostList.Add(host7);
            m_WindowsFormsHostList.Add(host8);
            
        }

        //refresh monitor by select number.
        public void Refresh(int index)
        {
           
            for (int i = 0; i < m_WindowsFormsHostList.Count; i++)
            {
                if (i == index)
                {
                    m_WindowsFormsHostList[i].Child.Refresh();
                    break;
                }
            }
            
        }

        //refresh all monitor.
        public void RefreshAll()
        {
            for (int i = 0; i < m_WindowsFormsHostList.Count; i++)
            {
                m_WindowsFormsHostList[i].Child.Refresh();
            }
          
        }

        //get control handle by select number.
        private IntPtr GetHandle(int key)
        {
           
            IntPtr handle = IntPtr.Zero;
            for (int i = 0; i < m_WindowsFormsHostList.Count; i++)
            {
                if (i == key)
                {
                    handle = m_WindowsFormsHostList[i].Child.Handle;
                    break;
                }
            }
           
            return handle;
        }

        //login device function.
        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            
            LoginWindow deviceLoginInformation = new LoginWindow();
            deviceLoginInformation.ShowDialog();
            if (deviceLoginInformation.isOk == true)
            {
                string ip = deviceLoginInformation.ip.Text.Trim();
                string port = deviceLoginInformation.port.Text.Trim();
                string userName = deviceLoginInformation.username.Text.Trim();
                string password = deviceLoginInformation.password.Password.Trim();

              
                //string ip = deviceLoginInformation.ip.Text.Trim();
                //string port = deviceLoginInformation.port.Text.Trim();
                //string userName = deviceLoginInformation.username.Text.Trim();
                //string password = deviceLoginInformation.password.Password.Trim();
                
                deviceLoginInformation.Close();
                NET_DEVICEINFO_Ex deviceInfo = new NET_DEVICEINFO_Ex();
                int error = 0;
                try
                {
                    //call login function.
                    ushort dev_port = 0;
                    try
                    {
                        dev_port = Convert.ToUInt16(port);
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show("ID_PORTERROR");
                        return;
                    }
                         IntPtr loginID = NETClient.Login(ip, dev_port, userName, password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref deviceInfo);
                    //  IntPtr loginID =(IntPtr) 0x000000cda2744cc0;
                  
                    if (loginID != IntPtr.Zero)
                    {
                        Device device = new Device();
                        device.IP = ip;
                        device.LoginID = loginID;
                        device.ChannelCount = deviceInfo.nChanNum;
                        m_DeviceList.Add(device);

                        TreeViewItem head = new TreeViewItem();
                        head.Header = ip + "(online)";
                        head.Tag = device;
                        //set double click event for head node.
                        head.MouseDoubleClick += new MouseButtonEventHandler(head_MouseDoubleClick);
                        for (int i = 0; i < deviceInfo.nChanNum; i++)
                        {
                            TreeViewItem child = new TreeViewItem();
                            child.Header = "chanel " + i.ToString();
                            child.Tag = i;
                            //set double click event for child node.
                            child.PreviewMouseDoubleClick += new MouseButtonEventHandler(child_PreviewMouseDoubleClick);
                            head.Items.Add(child);
                        }
                        treeView.Items.Add(head);
                        if (File.Exists(Constant.PATH_CONFIG_CAM))
                        {
                            try
                            {
                                XDocument xdoc = new XDocument();

                                using (FileStream read = new FileStream(Constant.PATH_CONFIG_CAM, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))/* XmlReader.Create(Constant.PATH_CONFIG_CAM))*/
                                {

                                    xdoc = XDocument.Load(read);
                                    XElement room = new XElement("Phong");
                                    room.Add(new XElement("IP", ip),
                                    new XElement("Port", port),
                                    new XElement("User", userName),
                                    new XElement("PassWord", password)
                                    );
                                    room.SetAttributeValue("ID", RoomName);
                                    xdoc.Element("Root").Add(room);
                                    xdoc.Save(Constant.PATH_CONFIG_CAM);
                                    read.Close();
                                    read.Dispose();
                                }
                            }
                            catch (Exception ex)
                            { }
                        }
                        else
                        {

                            XElement format = new XElement("Phong",
                            new XElement("IP", ip),
                            new XElement("Port", port),
                            new XElement("User", userName),
                            new XElement("PassWord", password)
                            );
                            format.SetAttributeValue("ID", RoomName);

                            XDocument xdoc = new XDocument(
                            new XElement("Root",
                            format
                                )
                             );
                            xdoc.Save(Constant.PATH_CONFIG_CAM);
                        }
                    }
                }
                catch (Exception ex)
                {
                 
                    if (ex is NETClientExcetion)
                    {
                        MessageBox.Show(this, (ex as NETClientExcetion).Message);
                    }
                    else
                    {
                          MessageBox.Show(this, ex.Message);
                    }
                }
              
            }
        }
        private void createNode(string RoomName ,string IP, string Port, string User, string Pass, XmlTextWriter writer)
        {
            writer.WriteStartElement("RoomName");
            writer.WriteString(RoomName);

            writer.WriteStartElement("IP");
            writer.WriteString(IP);
            writer.WriteEndElement();

            writer.WriteStartElement("Port");
            writer.WriteString(Port);
            writer.WriteEndElement();

            writer.WriteStartElement("UserName");
            writer.WriteString(User);
            writer.WriteEndElement();

            writer.WriteStartElement("PassWord");
            writer.WriteString(Pass);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        //double click in child node. first call stoprealplay function,then call starrealplay function.
        private void child_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {           
            try
            {
                int channelNum = (int)(sender as TreeViewItem).Tag;
                TreeViewItem head = (sender as TreeViewItem).Parent as TreeViewItem;
                var device = m_DeviceList.Find(p => p.LoginID == (head.Tag as Device).LoginID);
                Device dev = null;
                m_MonitorDic.TryGetValue(m_SelectedLayoutNumber, out dev);
                if (dev != null)
                {
                    NETClient.StopRealPlay(dev.RealHandle);//call stoprealplay function.
                    m_MonitorDic.Remove(m_SelectedLayoutNumber);
                    m_MonitorDic.Add(m_SelectedLayoutNumber, null);
                }
                bool ret = RealStart(device.LoginID, channelNum, m_SelectedLayoutNumber);
                if (!ret)
                {
                    Refresh(m_SelectedLayoutNumber);
                }
                e.Handled = true;
            }
            catch (Exception ex)
            {
                if (ex is NETClientExcetion)
                {
                    
                }
                else
                {
                     
                }
                e.Handled = true;
            }
             
        }

        //double click in head node to real 9 channels.first call stoprealplay function,then call starrealplay function.
        private void head_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var device = m_DeviceList.Find(p => p.LoginID == ((sender as TreeViewItem).Tag as Device).LoginID);
            int chanCount = device.ChannelCount;

            foreach (var item in m_MonitorDic.Values)
            {
                if (item != null)
                {
                    try
                    {
                        NETClient.StopRealPlay(item.RealHandle);//call stoprealplay function.
                    }
                    catch (Exception ex)
                    {
                        if (ex is NETClientExcetion)
                        {
                            
                        }
                        else
                        {
                             
                        }
                    }
                }
            }
            InitMonitorDic();
            RefreshAll();
            int count = chanCount > MaxMonitorCount ? MaxMonitorCount : chanCount;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    bool ret = RealStart(device.LoginID, i, i);
                }
                catch (Exception ex)
                {
                     
                }
            }
            e.Handled = true;
             
        }

        //call startrealplay function.
        private bool RealStart(IntPtr loginID, int channelNum, int handleNum)
        {
            
            try
            {
                ComboxItem item = (ComboxItem)this.type_combox.SelectedItem;
                //call startrealplay function.
                IntPtr realHandle = NETClient.StartRealPlay(loginID, channelNum, GetHandle(handleNum), (EM_RealPlayType)item.type, m_RealDataCallBack, m_RealPlayDisConnectCallBack, IntPtr.Zero, TimeOut);
                if (realHandle != IntPtr.Zero)
                {
                    Device dev = new Device();
                    Device res = m_DeviceList.Find(p => p.LoginID == loginID);
                    dev.LoginID = res.LoginID;
                    dev.IP = res.IP;
                    dev.ChannelCount = res.ChannelCount;
                    dev.RealHandle = realHandle;
                    dev.ChannelNum = channelNum;
                    m_MonitorDic.Remove(handleNum);
                    m_MonitorDic.Add(handleNum, dev);
                     
                    return true;
                }
                 
                return false;
            }
            catch (Exception ex)
            {
                 
                if (ex is NETClientExcetion)
                {
                    
                }
                 
                return false;
            }
        }

        //receive real data.
        private void RealDataCallBack(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, int param, IntPtr dwUser)
        {
            //LogHelper.WriteWithMethod("RealData");
        }

        //realplay disconnect callback function.
        private void RealPlayDisConnectCallBack(IntPtr lOperateHandle, EM_REALPLAY_DISCONNECT_EVENT_TYPE dwEventType, IntPtr param, IntPtr dwUser)
        {
            
            

            //try
            //{
            //    Device dev = null;
            //    int number = 0;
            //    for (int i = 0; i < MaxMonitorCount; i++)
            //    {
            //        dev=null;
            //        m_MonitorDic.TryGetValue(i, out dev);
            //        if (dev != null)
            //        {
            //            if (dev.RealHandle == lOperateHandle)
            //            {
            //                number = i;
            //                break;
            //            }
            //        }
            //    }
            //    if (dev != null)
            //    {
            //        NETClient.StopRealPlay(dev.RealHandle); //call stoprealplay function.
            //        m_MonitorDic.Remove(number);
            //        m_MonitorDic.Add(number, null);
            //        Refresh(number);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex is NETClientExcetion)
            //    {
            //        
            //    }
            //    else
            //    {
            //         
            //    }
            //}
             
        }

        //reconnect callback function.
        private void ReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            
            try
            {
                foreach (var item in m_DeviceList)
                {
                    if (lLoginID == item.LoginID)
                    {
                        Dispatcher.BeginInvoke((Action<IntPtr>)UpdateTreeViewItem, item.LoginID);//update UI
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
             
        }

        //update UI function.
        private void UpdateTreeViewItem(IntPtr value)
        {
            
            foreach (TreeViewItem treeItem in treeView.Items)
            {
                if ((treeItem.Tag as Device).LoginID == value)
                {
                    treeItem.Header = (treeItem.Tag as Device).IP + "online";
                    break;
                }
            }
             
        }

        //device logout function.
        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            
            if (treeView.SelectedItem == null)
            {
                return;
            }
            try
            {
                TreeViewItem item = treeView.SelectedItem as TreeViewItem;
                IntPtr loginID = IntPtr.Zero;
                if (item.Parent is TreeView)
                {
                    foreach (var device in m_DeviceList)
                    {
                        if (device.LoginID == (item.Tag as Device).LoginID)
                        {
                            loginID = device.LoginID;
                            NETClient.Logout(device.LoginID); //call logout function.
                            treeView.Items.Remove(item);
                            m_DeviceList.Remove(device);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var device in m_DeviceList)
                    {
                        if (device.LoginID == ((item.Parent as TreeViewItem).Tag as Device).LoginID)
                        {
                            loginID = device.LoginID;
                            NETClient.Logout(device.LoginID);
                            treeView.Items.Remove(item.Parent); //call logout function.
                            m_DeviceList.Remove(device);
                            break;
                        }
                    }
                }
                RefreshAll();
                for (int i = 0; i < MaxMonitorCount; i++)
                {
                    Device dev = null;
                    m_MonitorDic.TryGetValue(i, out dev);
                    if (dev != null)
                    {
                        if (dev.LoginID == loginID)
                        {
                            m_MonitorDic.Remove(i);
                            m_MonitorDic.Add(i, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
             
        }

        //set normal monitor to fullscreen,or fullscreen to normal function.
        private void realPlayLayout_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (m_IsFullModel == false)
                {
                    m_IsFullModel = true;
                    showPanel1.Visibility = Visibility.Collapsed;
                    showPanel2.Visibility = Visibility.Visible;
                    var pictureBox = sender as System.Windows.Forms.PictureBox;
                    pictureBox.Width = 718;
                    pictureBox.Height = 576;
                    winFormHost.Child = pictureBox;
                }
                else
                {
                    m_IsFullModel = false;
                    showPanel1.Visibility = Visibility.Visible;
                    showPanel2.Visibility = Visibility.Collapsed;
                    var item = m_WindowsFormsHostList.Find(p => p.Child.Handle == (sender as System.Windows.Forms.PictureBox).Handle);
                    var pictureBox = sender as System.Windows.Forms.PictureBox;
                    pictureBox.Width = 234;
                    pictureBox.Height = 187;
                    item.Child = pictureBox;
                }
            }
            catch (Exception ex)
            {
                 
                MessageBox.Show(this, ex.Message);
            }
             
        }

        //get current select 0monitor number.default is 0.
        private void Item_Selected(object sender, EventArgs e)
        {
            
            try
            {
                for (int i = 0; i < MaxMonitorCount; i++)
                {
                    (m_WindowsFormsHostList[i].Parent as Border).BorderBrush = new SolidColorBrush(Colors.Gray);
                }
                m_SelectedLayoutNumber = Convert.ToInt32((sender as System.Windows.Forms.PictureBox).Tag);
                var owner = m_WindowsFormsHostList[m_SelectedLayoutNumber].Parent;
                Border border = owner as Border;
                border.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            catch (Exception ex)
            {
                 
            }
             
        }

        //stop realplay by select monitor.
        private void StopReal_Clicked(object sender, RoutedEventArgs e)
        {
            
            Device dev = null;
            m_MonitorDic.TryGetValue(m_SelectedLayoutNumber, out dev);
            try
            {
                if (dev != null)
                {
                    NETClient.StopRealPlay(dev.RealHandle); //call stoprealplay function.
                    m_MonitorDic.Remove(m_SelectedLayoutNumber);
                    m_MonitorDic.Add(m_SelectedLayoutNumber, null);
                    Refresh(m_SelectedLayoutNumber);
                }
            }
            catch (Exception ex)
            {
                if (ex is NETClientExcetion)
                {
                    
                }
                else
                {
                     
                }
            }
             
        }

        //stop all realplay.
        private void StopAllReal_Clicked(object sender, RoutedEventArgs e)
        {
            
            foreach (var item in m_MonitorDic)
            {
                if (item.Value != null)
                {
                    try
                    {
                        NETClient.StopRealPlay(item.Value.RealHandle);//call stoprealplay function.
                    }
                    catch (Exception ex)
                    {
                       
                        if (ex is NETClientExcetion)
                        {
                            
                        }
                        else
                        {
                             
                        }
                    }
                }
            }
            InitMonitorDic();
            RefreshAll();
             
        }

        

        //save real data,will open save file dialog for set save information.
        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Device dev = null;
                m_MonitorDic.TryGetValue(m_SelectedLayoutNumber, out dev);
                if (dev != null)
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.FileName = "data";
                    saveFileDialog.Filter = "|*.dav";
                    string path = AppDomain.CurrentDomain.BaseDirectory + "savedata";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    saveFileDialog.InitialDirectory = path;
                    var res = saveFileDialog.ShowDialog();
                    if (res == System.Windows.Forms.DialogResult.OK)
                    {
                        bool ret = NETClient.SaveRealData(dev.RealHandle, saveFileDialog.FileName); //call saverealdata function.
                        if (ret)
                        {
                            m_SaveDataHandleList.Add(dev.RealHandle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
             
        }

        //stop save real data funtion by select monitor number.
        private void StopSave_Cliceked(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Device dev = null;
                m_MonitorDic.TryGetValue(m_SelectedLayoutNumber, out dev);
                var item = m_SaveDataHandleList.Find(p => p == dev.RealHandle);
                if (item != IntPtr.Zero)
                {
                    bool ret = NETClient.StopSaveRealData(item); //call stopsaverealdata function.
                    if (ret)
                    {
                        m_SaveDataHandleList.Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
                 
            }
             
        }

        //set capture information,then send capture request.
        private void Capture_Clicked(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Device dev = null;
                m_MonitorDic.TryGetValue(m_SelectedLayoutNumber, out dev);
                if (dev == null)
                {
                    return;
                }
                if (m_IsSetCaptureCallBack == false)
                {
                    NETClient.SetSnapRevCallBack(m_SnapRevCallBack, IntPtr.Zero);
                    m_IsSetCaptureCallBack = true;
                }
                NET_SNAP_PARAMS snap = new NET_SNAP_PARAMS();
                snap.Channel = (uint)dev.ChannelNum;
                snap.Quality = 6;
                snap.ImageSize = 2;
                snap.mode = 0;
                snap.InterSnap = 0;
                snap.CmdSerial = m_SnapSerialNum;
                bool ret = NETClient.SnapPictureEx(dev.LoginID, snap, IntPtr.Zero); //call capture function.
                if (ret)
                {
                    m_SnapSerialNum++;
                }
            }
            catch (Exception ex)
            {
                 
                if (ex is NETClientExcetion)
                {
                    MessageBox.Show(this, (ex as NETClientExcetion).Message);
                }
            }
             
        }

        //receive capture callback function.and save image by time file name.
        private void SnapRevCallBack(IntPtr lLoginID, IntPtr pBuf, uint RevLen, uint EncodeType, uint CmdSerial, IntPtr dwUser)
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory + "capture";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (EncodeType == 10) //.jpg
            {
                DateTime now = DateTime.Now;
                string fileName = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second) + ".jpg";
                string filePath = path + "\\" + fileName;
                byte[] data = new byte[RevLen];
                Marshal.Copy(pBuf, data, 0, (int)RevLen);
                using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    stream.Write(data, 0, (int)RevLen);
                    stream.Flush();
                    stream.Dispose();
                }
            }
             
        }

        //PTZcontrol function.
        private void PTZControl(EM_EXTPTZ_ControlType type, int param1, int param2, bool isStop)
        {
            
            Device dev = null;
            m_MonitorDic.TryGetValue(m_SelectedLayoutNumber, out dev);
            if (dev != null)
            {
                try
                {
                    NETClient.PTZControl(dev.LoginID, dev.ChannelNum, type, param1, param2, 0, isStop, IntPtr.Zero); //call PTZControl function.
                }
                catch (Exception ex)
                {
                     
                    if (ex is Exception)
                    {
                        MessageBox.Show(this, (ex as NETClientExcetion).Message);
                    }
                }
            }
             
        }

        //topleft down.
      

    }

    //device manage class.
    public class Device
    {
        public IntPtr LoginID { get; set; }
        public IntPtr RealHandle { get; set; }
        public string IP { get; set; }
        public int ChannelCount { get; set; }
        public int ChannelNum { get; set; }
    }
}
