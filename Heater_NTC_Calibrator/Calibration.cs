using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Heater_NTC_Calibrator
{
    public partial class Calibration : Form
    {

        Tools tools;
        public Heater_Calibrator parent;
        Thermometer therm = new Thermometer();
        string input = "";
        
        public const int J101 = 1;
        public const int SAMPLES = 20;
        public const int TIMEOUT = 240;
        public const int AVG_SAMPLES = 10;
        public const int SAMPLE_DELAY = 50;//+500 = 2 seconds
        double[] R_J10x = new double[4];
        double[] R_J10x_q = new double[4];
        double temperature, temperature_q;


        private void Calibration_Load(object sender, EventArgs e)
        {
            tools = new Tools();
            Open_Port.Enabled = false;
            Close_Port.Enabled = false;
            Start_Cal.Enabled = false;
            Stop_Cal.Enabled = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                Com_Ports.Items.Add(s);
            }
            Contra_Gif.Visible = false;

            tools.Serial_number_device_B = parent.tools.Serial_number_device_B;

            Ontrak_SN.Text = "Ontrak SN: " + tools.Serial_number_device_B;
        }

        public Calibration()
        {
            InitializeComponent();
            
        }

        private void Open_Port_Click(object sender, EventArgs e)
        {
            therm.Open_Port(Com_Ports.SelectedItem.ToString());
            bool A=false, B=false;
            if (!tools.open_device(1))
            {
                MessageBox.Show("Ontrak failed to connect");
                therm.Close_Port();
                Close_Port.Enabled = false;
                Start_Cal.Enabled = false;
                Stop_Cal.Enabled = false;
            }
            else
            {
                A = true;
                Close_Port.Enabled = true;
            }

           



            Start_Cal.Enabled = A ;
            
            
        }

        private void Com_Ports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Com_Ports.SelectedItem.ToString() != "") Open_Port.Enabled = true;
        }

        private void Close_Port_Click(object sender, EventArgs e)
        {
            therm.Close_Port();
            Close_Port.Enabled = false;
            Start_Cal.Enabled = false;
            Stop_Cal.Enabled = false;
        }

        private void CalWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string command;
            



            for (; ; )
            {
                if (CalWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                
                ///////////


                for (int k = 0; k < 4; k++) R_J10x[k] = 0;
                temperature=0;
               

               // for (int p = 0; p < AVG_SAMPLES; p++)
               // {
                  //  MessageBox.Show(therm.Measure().ToString());
                    //Thread.Sleep(100);
                    temperature = therm.Measure();
               // }
               // temperature = temperature / AVG_SAMPLES;
               // MessageBox.Show(temperature.ToString());

               

                for (int k = 0; k < 4; k++)
                {
                    command = "SPA" + Convert.ToString(k*4, 2).PadLeft(4, '0'); ;
                   // MessageBox.Show(command);
                    tools.send_commnad(command, 1);
                    Thread.Sleep(SAMPLE_DELAY);
                    for (int p = 0; p < AVG_SAMPLES; p++)
                    {
                  //  MessageBox.Show(command + "\n" + tools.read_command("RUC01", 1));
                        R_J10x[k] += convert_data_to_R(Convert.ToDouble(tools.read_command("RUC01", 1)), 1.25, 10000);
                        //Thread.Sleep(SAMPLE_DELAY * 10);
                    }
                    R_J10x[k] = R_J10x[k] / AVG_SAMPLES;
                }
                
                for (int k = 0; k < 4; k++)
                {
                    R_J10x_q[k] = R_J10x[k];
                }
                temperature_q = temperature;

                CalWorker.ReportProgress(0);
                //Thread.Sleep(100);
                //////////
                
            }
        }

        private void CalWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Output_Data.Rows.Add(temperature_q, R_J10x_q[3], R_J10x_q[2], R_J10x_q[1], R_J10x_q[0]);
            Output_Data.FirstDisplayedScrollingRowIndex = Output_Data.RowCount - 1;
            Output_Data.Update();
        }

        private void Stop_Cal_Click(object sender, EventArgs e)
        {
            if (CalWorker.IsBusy) CalWorker.CancelAsync();
            Thread.Sleep(5000);

            Contra_Gif.Visible = false;
            Stop_Cal.Enabled = false;
            Start_Cal.Enabled = true;



          
            
        }

        private void Start_Cal_Click(object sender, EventArgs e)
        {
            tools.send_commnad("CPA0000", 1);
            if (!CalWorker.IsBusy) CalWorker.RunWorkerAsync();

            if (CalWorker.IsBusy)
            {
                Contra_Gif.Visible = true;
                Stop_Cal.Enabled = true;
                Start_Cal.Enabled = false;
            }

        }





        double convert_data_to_R(double val, double Vref, double Res)
        {
            double v, r;
            v = (val * Vref) / (65535);
            r = (v * Res) / (Vref - v);
            return (r);
        }




        private void Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (CalWorker.IsBusy)CalWorker.CancelAsync();

              /*
            while(CalWorker.IsBusy)
            {
                MessageBox.Show(CalWorker.IsBusy.ToString());
               // Thread.Sleep(500);
            }
                  */
          /*  therm.Close_Port();
            tools.Close_Devices();
            Contra_Gif.Visible = false;
            Close_Port.Enabled = false;
            Start_Cal.Enabled = false;
            Stop_Cal.Enabled = false;    */

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }  


        }

        private void CalibrationTime_Click(object sender, EventArgs e)
        {
            CalibrationTime calibrationtime = new CalibrationTime();
            calibrationtime.Show();
        }
        private void LookUpTable_Click(object sender, EventArgs e)
        {
            parent.SettingsForm.Show();
        }

      


       





    }
}
