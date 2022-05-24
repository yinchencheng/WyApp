using System;
using System.Threading;
using HslCommunication;
using HslCommunication.Core.Net;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Omron;
using HslCommunication.Profinet.Siemens;
using HslCommunication.Profinet.Inovance;
using WY_App.Utility;
using HslCommunication.Core;
using System.IO;

namespace WY_App
{
    internal class HslCommunication
    {
        public static OperateResult plc_connect_result;
        public static NetworkDeviceBase _NetworkTcpDevice;       
        public HslCommunication()
        {
            try
            {
                Parameter.commministion = XMLHelper.BackSerialize<Parameter.Commministion>("systemconfig/commministion.xml");
            }
            catch
            {
                Parameter.commministion = new Parameter.Commministion();
                XMLHelper.serialize<Parameter.Commministion>(Parameter.commministion, "systemconfig/commministion.xml");
            }
            Thread th = new Thread(ini_PLC_Connect);
            th.IsBackground = true;
            th.Start();
        }
        public void ini_PLC_Connect()
        {
            if (!Authorization.SetAuthorizationCode("f562cc4c-4772-4b32-bdcd-f3e122c534e3"))
            {
                LogHelper.Error("HslCommunication 组件认证失败，组件只能使用8小时!");

            }
            while ( plc_connect_result == null || plc_connect_result.IsSuccess == false)
            {
                Thread.Sleep(1000);
                try
                {
                    //欧姆龙PLC OmronFinsNet通讯
                    if ("Omron.OmronFinsNet".Equals(Parameter.commministion.PlcType))
                    {
                        OmronFinsNet Client = new OmronFinsNet();
                        Client.IpAddress = Parameter.commministion.PlcIpAddress;
                        Client.Port = Parameter.commministion.PlcIpPort;
                        Client.SA1 = Convert.ToByte(Parameter.commministion.PlcDevice);
                        _NetworkTcpDevice = Client;
                        plc_connect_result = _NetworkTcpDevice.ConnectServer();
                    }
                    //三菱PLC Melsec.MelsecMcNet通讯
                    else if ("Melsec.MelsecMcNet".Equals(Parameter.commministion.PlcType))
                    {
                        MelsecMcNet Client = new MelsecMcNet();
                        Client.IpAddress = Parameter.commministion.PlcIpAddress;
                        Client.Port = Parameter.commministion.PlcIpPort;
                        _NetworkTcpDevice = Client;
                        plc_connect_result = _NetworkTcpDevice.ConnectServer();
                    }
                    //西门子PLC Siemens.SiemensS7Net通讯
                    else if ("Siemens.SiemensS7Net".Equals(Parameter.commministion.PlcType))
                    {
                        SiemensS7Net Client = new SiemensS7Net((SiemensPLCS)Parameter.commministion.PlcDevice, Parameter.commministion.PlcIpAddress);
                        Client.IpAddress = Parameter.commministion.PlcIpAddress;
                        Client.Port = Parameter.commministion.PlcIpPort;
                        _NetworkTcpDevice = Client;                      
                        plc_connect_result = _NetworkTcpDevice.ConnectServer();                        
                    }
                    //汇川PLC Inovance.InovanceSerialOverTcp通讯
                    else if ("Inovance.InovanceSerialOverTcp".Equals(Parameter.commministion.PlcType))
                    {
                        InovanceSerialOverTcp Client = new InovanceSerialOverTcp();
                        Client.IpAddress = Parameter.commministion.PlcIpAddress;
                        Client.Port = Parameter.commministion.PlcIpPort;
                        Client.DataFormat = DataFormat.ABCD;
                        _NetworkTcpDevice = Client;
                        plc_connect_result = _NetworkTcpDevice.ConnectServer();
                    }
                    //新增通讯添加else if判断创建连接

                    //Parameter.PlcType字符错误或未定义
                    else
                    {
                        LogHelper.Error("plc类型未定义：" + Parameter.commministion.PlcType);
                        
                    }

                    if (plc_connect_result.IsSuccess)
                    {
                        LogHelper.Info("plc连接成功:" + "IP" + Parameter.commministion.PlcIpAddress + "  Port:" + Parameter.commministion.PlcIpPort);                       
                    }
                    else
                    {
                        LogHelper.Warn("plc连接失败:" + "IP" + Parameter.commministion.PlcIpAddress + "  Port:" + Parameter.commministion.PlcIpPort);                       
                    }                    
                        
                }
                catch (Exception ex)
                {
                    LogHelper.Error("plc初始化失败：", ex);
                    
                }
            }
            while (plc_connect_result != null && plc_connect_result.IsSuccess == true)
            {
                try
                {
                    plc_connect_result = _NetworkTcpDevice.Write("M100", true);
                    Thread.Sleep(1000);
                    plc_connect_result = _NetworkTcpDevice.Write("M100", false);
                    Thread.Sleep(1000);
                }
                catch
                {
                    _NetworkTcpDevice.Dispose();
                    plc_connect_result.IsSuccess = false;
                }
            }
        }
    }
}
