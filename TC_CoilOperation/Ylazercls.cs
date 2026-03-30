using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace TC_CoilOperation
{ 
    /// <summary>
  　/// 距離計からシリアルにて値を取得するクラス
  　/// </summary>
    class Ylazercls
    {
        static public SerialPort serialPort = new SerialPort();
        public string portname;//com番号
        public int baudrate;//ボーレート値
        public int ReadTimeout;//タイムアウト時間
        public string address;//IP


        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <returns>エラー判定値</returns>

        public bool init()
        {
            try
            {
                serialPort.PortName = portname;
                serialPort.BaudRate = baudrate;
                serialPort.ReadTimeout = ReadTimeout;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Openチェック
        /// </summary>
        /// <returns>エラー判定値</returns>
        public bool PortOpenCheck()
        {
            if (serialPort.IsOpen != true)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// ポートオープン
        /// </summary>
        /// <returns>エラー判定値</returns>
        public bool PortOpen()
        {


            try
            {
                serialPort.Open();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// ポートクローズ
        /// </summary>
        /// <returns>エラー判定値</returns>
        public bool PortClose()
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Ping確認処理
        /// </summary>
        /// <returns>エラー判定値</returns>
        public bool Ping()
        {
            return true;//テストプログラム
            for (; ; )
            {
                Ping sender = new Ping();

                PingReply reply = sender.Send(address);//送信モジュール
                if (reply.Status != IPStatus.Success)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 距離計の値取得
        /// </summary>
        /// <returns>距離計値</returns>
        public int lazer()
        {
            int Errcount = 0;//エラーカウント
            string serial = "";//電文
            double renge = 0;//距離計値
            for (; ; )
            {
                //電文取得処理
                try
                {
                    //本番用
                    serial = Convert.ToString(serialPort.ReadLine());
                    //-------------------------------------------------

                    //以下テストプログラム
                    //--------------------------------------------------------20240529山﨑


                    int plusIndex = serial.IndexOf('+');
                    if (plusIndex != -1)
                    {
                        serial = serial.Substring(plusIndex);
                    }
                
                   
                    //--------------------------------------------------------
                }
                catch (Exception ex)
                {

                    serialPort.Close();
                    return -99998;
                }
                //電文解析
                if (serial.Length == 15 && serial.IndexOf("+") == 0)
                {
                    renge = Convert.ToDouble(serial.Substring(1, 6));//距離計座標生値
                    if (renge != 0)
                    {
                        serialPort.DiscardInBuffer();
                        return Convert.ToInt32(renge);
                    }
                    else if (Errcount == 50)
                    {

                        return -99999;
                    }
                    else { Errcount++; }
                }
                //----------------------------
                //2026/3/13 morichika
                //else {}Errcount++;
                else
                {
                    if (Errcount == 100)
                    { return -99999; }
                    else { Errcount++; }
                }
                //----------------------------
            }
        }
    }

}
