using HslCommunication.Profinet.Keyence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.BunifuTextBox.Transitions;
using Utilities.BunifuToolTip.Transitions;

namespace WY_App.Utility
{
    public class Parameter
    {
        /// <summary>
        /// 日志等级
        /// </summary>
        public enum LogLevelEnum
        {
            Debug = 0,
            Info = 1,
            Warn = 2,
            Error = 3,
            Fatal = 4
        }
        public struct specification
        {
            public double value;
            
            public double min;

            public double max;

            public double adjustZ;

            public double adjustF;

        }
        public class Specifications
        {
            public specification 总宽;
            public specification 总长;
            public specification 料宽;
            public specification 胶宽;
            public specification 长端;

            public specification 左短端;
            public specification 右短端;
            public specification 左肩宽;
            public specification 右肩宽;
            public specification 左肩高;
            public specification 右肩高;

            public Specifications()
            {
                总宽.value = 0;
                总宽.max = 0;
                总宽.min = 0;
                总宽.adjustZ = 0;
                总宽.adjustF = 0;

                总长.value = 0;
                总长.max = 0;
                总长.min = 0;
                总长.adjustZ = 0;
                总长.adjustF = 0;

                料宽.value = 0;
                料宽.max = 0;
                料宽.min = 0;
                料宽.adjustZ = 0;
                料宽.adjustF = 0;

                胶宽.value = 0;
                胶宽.max = 0;
                胶宽.min = 0;
                胶宽.adjustZ = 0;
                胶宽.adjustF = 0;

                长端.value = 0;
                长端.max = 0;
                长端.min = 0;
                长端.adjustZ = 0;
                长端.adjustF = 0;

                左短端.value = 0;
                左短端.max = 0;
                左短端.min = 0;
                左短端.adjustZ = 0;
                左短端.adjustF = 0;

                右短端.value = 0;
                右短端.max = 0;
                右短端.min = 0;
                右短端.adjustZ = 0;
                右短端.adjustF = 0;

                左肩宽.value = 0;
                左肩宽.max = 0;
                左肩宽.min = 0;
                左肩宽.adjustZ = 0;
                左肩宽.adjustF = 0;

                右肩宽.value = 0;
                右肩宽.max = 0;
                右肩宽.min = 0;
                右肩宽.adjustZ = 0;
                右肩宽.adjustF = 0;

                左肩高.value = 0;
                左肩高.max = 0;
                左肩高.min = 0;
                左肩高.adjustZ = 0;
                左肩高.adjustF = 0;

                右肩高.value = 0;
                右肩高.max = 0;
                右肩高.min = 0;
                右肩高.adjustZ = 0;
                右肩高.adjustF = 0;
            }
        }
        public static Specifications specifications = new Specifications();
        public class Commministion
        {
            /// <summary>
            /// 当前保存日志等级
            /// </summary>
            public LogLevelEnum LogLevel;

            /// <summary>
            /// 日志存放路径
            /// </summary>
            public string LogFilePath;

            /// <summary>
            /// 日志存放天数
            /// </summary>
            public int LogFileExistDay;

            /// <summary>
            /// plc启用标志
            /// </summary>
            public bool PlcEnable;

            /// <summary>
            /// plc型号
            /// </summary>
            public string PlcType;

            /// <summary>
            /// plc ip地址
            /// </summary>
            public string PlcIpAddress;

            /// <summary>
            /// plc ip端口号
            /// </summary>
            public int PlcIpPort;

            /// <summary>
            /// plc 站号/型号
            /// </summary>
            public string PlcDevice;

            /// <summary>
            /// Tcp客户端启用标志
            /// </summary>
            public bool TcpClientEnable;

            /// <summary>
            /// tcp ip地址
            /// </summary>
            public string TcpClientIpAddress;

            /// <summary>
            /// tcp ip端口号
            /// </summary>
            public int TcpClientIpPort;

            /// <summary>
            /// Tcp服务端启用标志
            /// </summary>
            public bool TcpServerEnable;

            /// <summary>
            /// tcp服务器 ip地址
            /// </summary>
            public string TcpServerIpAddress;

            /// <summary>
            /// tcp服务器 ip端口号
            /// </summary>
            public int TcpServerIpPort;


            /// <summary>
            /// 联机参数设置
            /// </summary>
            public Commministion()
            {
                //PLC启用标志
                PlcEnable = false;
                //--PLC参数设置--
                //--欧姆龙Omron.OmronFinsNet--
                //--西门子Siemens.SiemensS7Net--
                //--三菱Melsec.MelsecMcNet--
                //--汇川Inovance.InovanceSerialOverTcp--
                //--ModbusTcp

                //PLC 类型
                PlcType = "Omron.OmronFinsNet";
                //PLC 地址
                PlcIpAddress = "127.0.0.1";
                //PLC站号/型号
                PlcDevice = "200";
                //PLC 端口号
                PlcIpPort = 9600;

                //--TCP客户端参数设置--
                //Tcp客户端启用标志
                TcpClientEnable = true;
                //TCP 客户端 地址
                TcpClientIpAddress = "127.0.0.1";
                //TCP 客户端 端口号
                TcpClientIpPort = 9600;

                //--TCP服务器参数设置--
                //Tcp服务器启用标志
                TcpServerEnable = false;
                //TCP服务器 地址
                TcpServerIpAddress = "127.0.0.1";
                //TCP服务器 端口号
                TcpServerIpPort = 9600;
            }
        }

        public static Commministion commministion = new Commministion();

        public class PLCParams
        {
            public string Trigger_Detection;
            public string Completion;
            public string HeartBeatAdd;
            public string StartAdd;
           
            public PLCParams()
            {
                Trigger_Detection = "D100";
                Completion = "D100";
                HeartBeatAdd = "D102";
                HeartBeatAdd = "D104";                               
            }
        }

        public class Counts
        {
            public int Counts1;
            public int Counts2; 
            public int Counts3; 
            public int Counts4; 
            public int Counts5;
            public int Counts6;

            public int Counts21;
            public int Counts22;
            public int Counts23;
            public int Counts24;
            public int Counts25;
            public int Counts26;

            public Counts()
            {
                Counts1 = 0;
                Counts2 = 0;
                Counts3 = 0;
                Counts4 = 0;
                Counts5 = 0;
                Counts6 = 0;
                Counts21 = 0;
                Counts22 = 0;
                Counts23 = 0;
                Counts24 = 0;
                Counts25 = 0;
                Counts26 = 0;
            }
        }

        public static PLCParams plcParams = new PLCParams();
        public static Counts counts = new Counts();
    }
}