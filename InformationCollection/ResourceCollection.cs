using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Collections;
using System.Management;
using Common;

namespace InformationCollection
{
    public class ResourceCollection
    {
        public string ReturnRegistryKey(string remoteName, string oneSubKey, string keyValue)
        {
            string resValue = String.Empty;
            try
            {
                RegistryKey environmentKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, remoteName).OpenSubKey(oneSubKey);

                if (environmentKey != null)
                {
                    foreach (string valueName in environmentKey.GetValueNames())
                    {
                        if (keyValue.CompareTo(valueName) == 0)
                        {
                            environmentKey.GetValue(valueName).ToString();
                        }
                    }
                }

                environmentKey.Close();


                return resValue;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ArrayList GetSystemInfo(string ipAddress, string userName, string password, ArrayList hostInfo, ArrayList cimList)
        {
            ConnectionOptions conn = new ConnectionOptions();
            ArrayList array = new ArrayList();
            ObjectQuery oq;
            string osType = string.Empty,oldCpuNum = string.Empty;
            int i = 0;
            try
            {
                conn.Username = userName;
                conn.Password = password;
                array.Add(ipAddress);
                string[] matchStr = (string[])hostInfo.ToArray(typeof(string));
                ManagementScope ms = new ManagementScope(@"\\" + ipAddress + @"\root\cimv2", conn);
                ms.Connect();
                if (hostInfo.Count > 0)
                {
                    foreach (string cim in cimList)
                    {
                        int numCpu = 0;
                        string cpuCores = string.Empty,driveName = string.Empty,driveSize = string.Empty,driveSzieValue = string.Empty;
                        string cpuSpeed = string.Empty;
                        switch (cim + matchStr[i])
                        {
                            case "Win32_ProcessorArchitecture":
                                oq = new ObjectQuery("Select * from " + cim + " where DeviceID = \"CPU0\"");
                                break;
                            case "Win32_ProcessorMaxClockSpeed":
                                oq = new ObjectQuery("Select * from " + cim + " where DeviceID = \"CPU0\"");
                                break;
                            case "Win32_LogicalDiskSize":
                                oq = new ObjectQuery("Select Name,Size from " + cim + " where DriveType = 3");
                                break;
                            case "Win32_LogicalDiskFreeSpace":
                                oq = new ObjectQuery("Select Name,FreeSpace from " + cim + " where DriveType = 3");
                                break;
                            default:
                                oq = new ObjectQuery("Select * from " + cim + "");
                                break;
                        }
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, oq);
                        ManagementObjectCollection collection = searcher.Get();
                        foreach (ManagementObject m in collection)
                        {
                            switch (cim + matchStr[i])
                            {
                                case "Win32_ComputerSystemTotalPhysicalMemory":
                                    array.Add(Convert.ToInt64(m[matchStr[i]]) / 1024 / 1024 + "MB");
                                    break;
                                case "CIM_OperatingSystemFreePhysicalMemory":
                                    array.Add(Convert.ToInt64(m[matchStr[i]]) / 1024 + "MB");
                                    break;
                                case "CIM_OperatingSystemTotalVirtualMemorySize":
                                    array.Add(Convert.ToInt64(m[matchStr[i]]) / 1024 + "MB");
                                    break;
                                case "CIM_OperatingSystemFreeVirtualMemory":
                                    array.Add(Convert.ToInt64(m[matchStr[i]]) / 1024 + "MB");
                                    break;
                                case "Win32_ComputerSystemNumberOfProcessors":
                                    array.Add(m[matchStr[i]]);
                                    oldCpuNum = m[matchStr[i]].ToString();
                                    break;
                                case "Win32_LogicalDiskSize":
                                    driveName = m["Name"].ToString();
                                    driveSize = string.Format("{0:F2}", Convert.ToDouble(m["Size"]) / 1024/1024/1024) + "G";
                                    driveSzieValue += driveName + driveSize + " ";
                                    break;
                                case "Win32_LogicalDiskFreeSpace":
                                    driveName = m["Name"].ToString();
                                    driveSize =  string.Format("{0:F2}",Convert.ToDouble(m["FreeSpace"]) / 1024 / 1024 / 1024) + "G";
                                    driveSzieValue += driveName + driveSize + " ";
                                    break;
                                case "Win32_OperatingSystemOSArchitecture":
                                    try
                                    {
                                        array.Add(m[matchStr[i]]);
                                    }
                                    catch
                                    {
                                        array.Add(osType); 
                                    }
                                    break;
                                case "Win32_ProcessorArchitecture":
                                    switch (Convert.ToInt16(m[matchStr[i]]))
                                    {
                                        case 0:
                                            array.Add("x86");
                                            osType = "32-bit";
                                            break;
                                        case 1:
                                            array.Add("MIPS");
                                            break;
                                        case 2:
                                            array.Add("Alpha");
                                            break;
                                        case 3:
                                            array.Add("PowerPC");
                                            break;
                                        case 6:
                                            array.Add("Intel Itanium Processor Family (IPF)");
                                            break;
                                        case 9:
                                            array.Add("x64");
                                            osType = "64-bit";
                                            break;
                                        default:
                                            array.Add("");
                                            break;
                                    }
                                    break;
                                case "Win32_ProcessorNumberOfCores":
                                    numCpu++;
                                    try
                                    {
                                        if (m[matchStr[i]] != null)
                                        {
                                            cpuCores = m[matchStr[i]].ToString();
                                        }
                                    }
                                    catch
                                    {
                                        cpuCores = string.Empty;
                                    }
                                    break;
                                default:
                                    array.Add(m[matchStr[i]]);
                                    break;
                            }
                        }
                        switch (cim + matchStr[i])
                        {
                            case "Win32_ProcessorNumberOfCores":
                                if (!string.IsNullOrEmpty(cpuCores))
                                {
                                    array.Add(numCpu + "X" + cpuCores + " " + (Convert.ToInt16(numCpu) * Convert.ToInt16(cpuCores)) + "C");
                                }
                                else
                                {
                                    array.Add(oldCpuNum + "C");
                                }
                                break;
                            case "Win32_LogicalDiskSize":
                                array.Add(driveSzieValue);
                                break;
                            case "Win32_LogicalDiskFreeSpace":
                                array.Add(driveSzieValue);
                                break;
                        }
                        i++;
                    }
                }

                return array;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn = null;
            }
        }
    }
}
