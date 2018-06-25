using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Heater_NTC_Calibrator
{
    public class Thermometer
    {
        public SerialPort serialPort1 = new SerialPort();
        private string Data_read;
        public string Received="";




        public bool Send_Serial_cmd(string cmd)
        {
            string command = cmd + "\r\n";
            if (serialPort1.IsOpen)
            {
                foreach (char ch in command)
                {
                    serialPort1.Write(ch.ToString());
                    Thread.Sleep(10);
                }
                // Debug.WriteLine("Sent");
                // 
                return (true);
            }
            else
            {
                return (false);
            }

        }

        public bool Open_Port(string Com_Port)
        {
            serialPort1.PortName = Com_Port;
            serialPort1.BaudRate = 9600;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            serialPort1.ReadTimeout = 4000;
            serialPort1.Handshake = Handshake.None;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            serialPort1.Open();
            Thread.Sleep(1000);
            Send_Serial_cmd("SYSTEM:REMOTE");
            return (serialPort1.IsOpen);

            

        }

        public void Close_Port()
        {
            serialPort1.Close();
        }


        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Data_read = serialPort1.ReadExisting();
          //  this.Invoke(new EventHandler(DisplayText));
            Received = Received + Data_read;
          //  Debug.WriteLine("Data arrived");
        }

      

        public double Measure()
        {
            string temp;
            double val;
            Thread.Sleep(2000);
            Send_Serial_cmd("MEASURE:CHANNEL?1") ;
            Thread.Sleep(1000);
            try
            {
                temp = Received.Substring(2, 6);
                Received = "";
                val = Convert.ToDouble(temp);
            }
            catch (Exception e)
            {
                val = 0;
            }
            
            return (val);
        }

    }
}
