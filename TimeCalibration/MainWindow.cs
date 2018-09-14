using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimeCalibration
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMiliseconds;
    }
    public class SetSystemDateTime
    {
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime sysTime);

        public static bool SetLocalTimeByStr(string timestr)
        {
            bool flag = false;
            SystemTime sysTime = new SystemTime();
            DateTime dt = Convert.ToDateTime(timestr);
            sysTime.wYear = Convert.ToUInt16(dt.Year);
            sysTime.wMonth = Convert.ToUInt16(dt.Month);
            sysTime.wDay = Convert.ToUInt16(dt.Day);
            sysTime.wHour = Convert.ToUInt16(dt.Hour);
            sysTime.wMinute = Convert.ToUInt16(dt.Minute);
            sysTime.wSecond = Convert.ToUInt16(dt.Second);
            try
            {
                flag = SetSystemDateTime.SetLocalTime(ref sysTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("SetSystemDateTime函数执行异常" + e.Message);
            }
            return flag;
        }
    }








    public partial class MainWindow : Form
    {
        public const string URL_TIME = "http://api.k780.com/?app=life.time&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=json";

        public const int STATE_IDLE = 0;
        public const int STATE_PROCESSING = 1;
        public const int STATE_FAIL = 2;
        public const int STATE_SUCCESS = 3;

        private int StateCurrent = STATE_IDLE;

        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         *  Win32 API
         */


        /**
         *  全局变量
         */
        private Timer MyTimer;
        private StringBuilder TextStringBuilder = new StringBuilder();
        private DateTime? MyLocalTime = null;
        private DateTime? MyNetworkTime = null;


        /*
         * 初始化
         */
   
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitLocalTime();
            InitNetworkTime();
            InitTimer();
        }

        private void InitLocalTime()
        {
            MyLocalTime = DateTime.Now;
        }

        private void InitNetworkTime()
        {
            StateCurrent = STATE_PROCESSING;
            this.buttonConfirm.Text = "正在获取时间";

            System.IO.Stream respStream = WebRequest.Create(URL_TIME).GetResponse().GetResponseStream();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.UTF8))
            {
                string resultString = reader.ReadToEnd();
                if(resultString.Length > 14)
                {
                    string tmpState = resultString.Substring(12, 1);
                    if(tmpState == "1")
                    {
                        string tmpUnixTimeStamp = resultString.Substring(38, 10);
                        MyNetworkTime = GetTime(tmpUnixTimeStamp);
                        Console.WriteLine(tmpUnixTimeStamp);
                        Console.WriteLine(MyNetworkTime);
                        StateCurrent = STATE_SUCCESS;
                        this.buttonConfirm.Text = "设置时间";
                    }
                    else
                    {
                        StateCurrent = STATE_FAIL;
                        this.buttonConfirm.Text = "获取网络时间返回失败，点击重试";
                        Console.WriteLine(tmpState);
                    }
                }
                else
                {
                    this.buttonConfirm.Text = "获取网络时间失败，点击重试";
                    StateCurrent = STATE_FAIL;
                }
            }
        }

        private void InitTimer()
        {
            MyTimer = new Timer();
            MyTimer.Interval = 100;
            MyTimer.Tick += new EventHandler((object obj, EventArgs eventArgs) => {
                if(MyLocalTime.HasValue)
                {
                    DateTime localTime = MyLocalTime.Value;
                    MyLocalTime = localTime.AddMilliseconds(100);
                    this.textLocalTime.Text = timeToString(localTime);
                }
                if(MyNetworkTime.HasValue)
                {
                    DateTime networkTime = MyNetworkTime.Value;
                    MyNetworkTime = networkTime.AddMilliseconds(MyTimer.Interval);
                    this.textNetworkTime.Text = timeToString(networkTime);
                }
                
            });
            MyTimer.Enabled = true;
            MyTimer.Start();
        }

        /*
         *  事件处理
         */
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            switch(StateCurrent)
            {
                case STATE_IDLE:
                    {
                        MessageBox.Show("应用程序尚未准备好，请稍等");
                        break;
                    }
                case STATE_PROCESSING:
                    {
                        MessageBox.Show("正在获取网络时间，请稍等");
                        break;
                    }
                case STATE_SUCCESS:
                    {
                        if (MyNetworkTime.HasValue)
                        {
                            int year = MyNetworkTime.Value.Year;
                            int month = MyNetworkTime.Value.Month;
                            int day = MyNetworkTime.Value.Day;
                            int hour = MyNetworkTime.Value.Hour;
                            int minute = MyNetworkTime.Value.Minute;
                            int second = MyNetworkTime.Value.Second;

                            SetSystemDateTime.SetLocalTimeByStr(MyNetworkTime.ToString());
                            Environment.Exit(0);
                        } 
                        else
                        {
                            MessageBox.Show("网络时间为空，请退出重试");
                        }
                        break;
                    }
                case STATE_FAIL:
                    {
                        InitNetworkTime();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("未知状态，请退出重试");
                        break;
                    }
            }
        }

        /*
         *  资源回收
         */
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // 释放Timer
            MyTimer.Dispose();
        }

        /*
         * 便捷方法
         */
        private string timeToString(DateTime dateTime)
        {
            TextStringBuilder.Clear();
            int tmpYear = dateTime.Year;
            int tmpMonth = dateTime.Month;
            int tmpDay = dateTime.Day;
            int tmpHour = dateTime.Hour;
            int tmpMinute = dateTime.Minute;
            int tmpSecond = dateTime.Second;
            TextStringBuilder.Append(tmpYear);
            TextStringBuilder.Append("-");
            if (tmpMonth < 10)
            {
                TextStringBuilder.Append("0");
            }
            TextStringBuilder.Append(tmpMonth);
            TextStringBuilder.Append("-");
            if (tmpDay < 10)
            {
                TextStringBuilder.Append("0");
            }
            TextStringBuilder.Append(tmpDay);
            TextStringBuilder.Append(" ");
            if (tmpHour < 10)
            {
                TextStringBuilder.Append("0");
            }
            TextStringBuilder.Append(tmpHour);
            TextStringBuilder.Append(":");
            if (tmpMinute < 10)
            {
                TextStringBuilder.Append("0");
            }
            TextStringBuilder.Append(tmpMinute);
            TextStringBuilder.Append(":");
            if (tmpSecond < 10)
            {
                TextStringBuilder.Append("0");
            }
            TextStringBuilder.Append(tmpSecond);
            return TextStringBuilder.ToString();
        }

        /// <summary>  
        /// 时间戳转为C#格式时间  
        /// </summary>  
        /// <param name="timeStamp">Unix时间戳格式</param>  
        /// <returns>C#格式时间</returns>  
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }


    }
}
