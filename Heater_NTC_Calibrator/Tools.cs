
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;



namespace Heater_NTC_Calibrator
{
    public class Tools: Form
    {

        public string Serial_number_device_B ;//= "B02649";////<<<<<<<<< Serial Number for first ADU100
        public string Serial_number_device_A ;//= "B02650";////<<<<<<<<< Serial Number for second ADU100

        public IntPtr Device_A;
        public IntPtr Device_B;



        [DllImport("aduhid.dll")]
        public static extern IntPtr OpenAduDevice(UInt32 iTimeout);
        [DllImport("aduhid.dll")]
        public static extern IntPtr OpenAduDeviceBySerialNumber(string psSerialNumber, UInt32 iTimeout);

        [DllImport("aduhid.dll")]
        public static extern bool WriteAduDevice(IntPtr hFile,
            [MarshalAs(UnmanagedType.LPStr)]string lpBuffer,
            UInt32 nNumberOfBytesToWrite,
            out UInt32 lpNumberOfBytesWritten,
            UInt32 iTimeout);

        [DllImport("aduhid.dll")]
        public static extern bool ReadAduDevice(IntPtr hFile,
            StringBuilder lpBuffer,
            UInt32 nNumberOfBytesToRead,
            out UInt32 lpNumberOfBytesRead,
            UInt32 iTimeout);

        [DllImport("aduhid.dll")]
        public static extern void CloseAduDevice(IntPtr hFile);
        [STAThread]



        public bool open_device(int dev_num)
        {
            short status = 0;
            try
            {
                if (dev_num == 0)
                {
                    Device_A = OpenAduDeviceBySerialNumber(Serial_number_device_A, 0);
                    status = (short)Device_A;
                    Thread.Sleep(50);
                }
                if (dev_num == 1)
                {
                    Device_B = OpenAduDeviceBySerialNumber(Serial_number_device_B, 0);
                    status = (short)Device_B;
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AduHid.dll is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
            return (status > 0);
        }


        public void Close_Devices()
        {
            CloseAduDevice(Device_A);
            CloseAduDevice(Device_B);
        }

        public string read_command(string command, int dev_num)
        {
            string results = "";
            bool bRC = false;
            uint uiRead = 0;
            uint uiLength = 7;
            uint uiWritten = 0xdead;


            
            StringBuilder sBuffer = new StringBuilder(8);

            try
            {
                if (dev_num == 0)
                {
                    bRC = WriteAduDevice(Device_A, command, uiLength, out uiWritten, 500);
                     Thread.Sleep(50);
                    bRC = ReadAduDevice(Device_A, sBuffer, uiLength, out uiRead, 500);
                }
                if (dev_num == 1)
                {
                    bRC = WriteAduDevice(Device_B, command, uiLength, out uiWritten, 500);
                    Thread.Sleep(50);
                    bRC = ReadAduDevice(Device_B, sBuffer, uiLength, out uiRead, 500);
                }
               // Thread.Sleep(100);
                results = sBuffer.ToString();
                return results;
            } 
            catch(Exception e)
            {
                return ("-1");
            }

            

            
        }
        
        public void send_commnad(string command, int dev_num)
        {
            bool bRC = false;
            uint uiLength = 7;
            uint uiWritten = 0xdead;
            try
            {
                if (dev_num == 0) bRC = WriteAduDevice(Device_A, command, uiLength, out uiWritten, 500);
                if (dev_num == 1) bRC = WriteAduDevice(Device_B, command, uiLength, out uiWritten, 500);

               // MessageBox.Show(command);
            }
            catch (Exception e)
            {
              //  MessageBox.Show("error");

            }
            
            Thread.Sleep(50);
        }


     


    }
}
