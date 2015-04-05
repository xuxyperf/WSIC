using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common;
using System.Xml;
using System.Collections;

namespace XmlProcess
{
    public class XmlConfigration
    {
        private string configurationFile;
        private IList<string> hostItems = new List<string>();
        private IList<string> wmiItems = new List<string>();
        public void Load(string configUrl)
        {
            this.configurationFile = configUrl;
            this.Load();
        }

        public void Load()
        {
            this.HostProperties.Clear();
            this.WMIParameterProperties.Clear();
            try
            {
                if (!File.Exists(this.configurationFile))
                {
                    throw new PerfOptimizeException("不存在配置文件：{0}",null, new object[] {  this.configurationFile  });
                }
                else
                {
                    using (FileStream xmlStream = new FileStream(this.configurationFile, FileMode.Open, FileAccess.Read))
                    {
                        XmlDocument confXml = new XmlDocument();
                        confXml.Load(xmlStream);
                        this.LoadHostProperties(confXml.DocumentElement);
                        this.LoadWMIProperties(confXml.DocumentElement);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PerfOptimizeException("读取配置失败: {0}", ex, new object[] { this.configurationFile });
            }
        }

        private void LoadHostProperties(XmlElement root)
        {
            StringBuilder sb = new StringBuilder(500);
            XmlNode node = root.SelectSingleNode("descendant::HostProperties");
            if (node == null)
            {
                throw new PerfOptimizeException("不存在 HostProperties 节点.");
            }
            foreach (XmlNode node2 in node.SelectNodes("HostConfiguration"))
            {
                //IPAddress
                XmlAttribute ipAddress = node2.Attributes["IPAddress"];
                if (ipAddress == null)
                {
                    throw new PerfOptimizeException("存在不具有 IPAddress 属性的 HostConfiguration 节点.");
                }
                string hostIPAddress = ipAddress.Value;
                if (string.IsNullOrEmpty(hostIPAddress.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 IPAddress 属性的 HostConfiguration 节点.");
                }
                //OsType
                XmlAttribute osType = node2.Attributes["OsType"];
                if (osType == null)
                {
                    throw new PerfOptimizeException("存在不具有 OsType 属性的 HostConfiguration 节点.");
                }
                string hostOSType = osType.Value;
                if (string.IsNullOrEmpty(hostOSType.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 OsType 属性的 HostConfiguration 节点.");
                }
                //UserName
                XmlAttribute userName = node2.Attributes["UserName"];
                if (userName == null)
                {
                    throw new PerfOptimizeException("存在不具有 UserName 属性的 HostConfiguration 节点.");
                }
                string hostUserName = userName.Value;
                if (string.IsNullOrEmpty(hostUserName.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 UserName 属性的 HostConfiguration 节点.");
                }
                //Password
                XmlAttribute password = node2.Attributes["Password"];
                if (password == null)
                {
                    throw new PerfOptimizeException("存在不具有 Password 属性的 HostConfiguration 节点.");
                }
                string hostPassword = password.Value;
                if (string.IsNullOrEmpty(hostPassword.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 Password 属性的 HostConfiguration 节点.");
                }

                sb.AppendFormat("{0},{1},{2},{3}", hostIPAddress, hostOSType, hostUserName, hostPassword);
                hostItems.Add(sb.ToString());
                sb.Remove(0,sb.Length);
            }
        }

        private void LoadWMIProperties(XmlElement root)
        {
            StringBuilder sb = new StringBuilder(500);
            XmlNode node = root.SelectSingleNode("descendant::ParameterWMI");
            if (node == null)
            {
                throw new PerfOptimizeException("不存在 ParameterWMI 节点.");
            }
            foreach (XmlNode node2 in node.SelectNodes("ParameterItem"))
            {
                //Type
                XmlAttribute type = node2.Attributes["Type"];
                if (type == null)
                {
                    throw new PerfOptimizeException("存在不具有 Type 属性的 ParameterItem 节点.");
                }
                string typePara = type.Value;
                if (string.IsNullOrEmpty(typePara.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 Type 属性的 ParameterItem 节点.");
                }
                //Name
                XmlAttribute name = node2.Attributes["Name"];
                if (name == null)
                {
                    throw new PerfOptimizeException("存在不具有 Name 属性的 ParameterItem 节点.");
                }
                string namePara = name.Value;
                if (string.IsNullOrEmpty(namePara.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 Name 属性的 ParameterItem 节点.");
                }
                //MatchValue
                XmlAttribute matchValue = node2.Attributes["MatchValue"];
                if (matchValue == null)
                {
                    throw new PerfOptimizeException("存在不具有 MatchValue 属性的 ParameterItem 节点.");
                }
                string matchValuePara = matchValue.Value;
                if (string.IsNullOrEmpty(matchValuePara.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 MatchValue 属性的 ParameterItem 节点.");
                }

                //CIM
                XmlAttribute cimValue = node2.Attributes["CIM"];
                if (cimValue == null)
                {
                    throw new PerfOptimizeException("存在不具有 CIM 属性的 ParameterItem 节点.");
                }
                string cimValuePara = cimValue.Value;
                if (string.IsNullOrEmpty(cimValuePara.Trim()))
                {
                    throw new PerfOptimizeException("存在具有非法 CIM 属性的 ParameterItem 节点.");
                }

                sb.AppendFormat("{0},{1},{2},{3}", typePara, namePara, matchValuePara,cimValuePara);
                wmiItems.Add(sb.ToString());
                sb.Remove(0, sb.Length);
            }
        }

        public IList<string> HostProperties
        {
            get
            {
                return this.hostItems;
            }
        }

        public IList<string> WMIParameterProperties
        {
            get
            {
                return this.wmiItems;
            }
        }
    }
}
