using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public int PlcDevice;

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

            public Commministion()
            {
                PlcEnable = false;
                //            < !--PLC参数设置-- >

                //    < !--欧姆龙Omron.OmronFinsNet-- >

                //    < !--西门子Siemens.SiemensS7Net-- >

                //    < !--三菱Melsec.MelsecMcNet-- >

                //    < !--汇川Inovance.InovanceSerialOverTcp-- >

                //< !--PLC启用标志-- >

                PlcType = "Siemens.SiemensS7Net";

                PlcIpAddress = "127.0.0.1";

                //< !--plc 站号 / 型号-- >

                PlcDevice = 1500;

                //< !--plc ip端口号-- >

                PlcIpPort = 9600;


                //TCP客户端参数设置


                //Tcp客户端启用标志

                TcpClientEnable = false;

                //< !--TCP ip地址-- >

                TcpClientIpAddress = "127.0.0.1";

                //< !--TCP ip端口号-- >

                TcpClientIpPort = 9600;


                //< !--TCP服务器参数设置-- >

                //< !--PLC类型-- >

                TcpServerEnable = false;

                //< !--TCP ip地址-- >

                TcpServerIpAddress = "127.0.0.1";
                //< !--TCP ip端口号-- >

                TcpServerIpPort = 9600;
            }
        }

        public static Commministion commministion = new Commministion();
    }
}