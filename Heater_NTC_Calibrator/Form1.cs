
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
using System.IO.Ports;
using System.Diagnostics;
using System.Media;
using System.Drawing.Drawing2D;
using System.Globalization;

// sample rate 2.5 s

namespace Heater_NTC_Calibrator
{
    public partial class Heater_Calibrator : Form
    {
        bool complete_calibration, complete_flag;
        public const int J101 = 1;
        public const int SAMPLES = 16; //must be grater than 2
        public const int TIMEOUT = 180;
        public const int AVG_SAMPLES = 8;
        public const int MINMUM_COUNTS = 10;
        public const Double THRESH_HOLD_TopVsBottom = 0.3;
        public const Double THRESH_HOLD_Enviroment = 1.5;
        public const Double THRESH_HOLD_Stable= 0.15;
        public const Double SAMPLER_THERSH_HOLD = 0.15;
        public const int Therm_expiryDate = 168;//in days 6Monthes=24 weeks
        public const int PCBA_expiryDate = 168;//6Monthes=24 weeks
        public const int HeaterBath_expiryDate = 168;

        public string VER_NUMBER = "2.0";
        public const int SAMPLE_DELAY = 500;//+500 = 2 seconds
        public const int COEFF_CNT = 3;
        bool Cal_Sucess = false;        // true if all plugged heaters are calibrated
        bool TimeOut = false;           // true if timed out
        bool complete = false;          // true if completed calibration
        bool ref_therm_ok = false;
        int worker_counter = 0;
        Calibration Cal = new Calibration();
        


        SteinhartHart SH = new SteinhartHart(COEFF_CNT);
        double [] tempreature_fifo;
        double temp_avg;

        string datetimeReport;

        string datetime;

        // array to hold heater temperature 
        double[][] Data = new double[36][];
        double[][] DataR = new double[36][];

        // array to hold heater offsets 
        double[][] Offset = new double[36][];


        // status to indicate if a heater is connected
        bool[] Status = new bool[36];
       
        // buffer to record the previous state of status to indicate if a heater is connected
        bool[] Status_buffer = new bool[36];
        

        // status to indicate the offset is stabilised 
        bool[] Offset_Status = new bool[36];
   
       public  Tools tools;


        SoundPlayer Sound = new SoundPlayer(@"Sound.wav");
        CalibrationTime CalibrationTime;


        string l = Environment.NewLine;
        Bitmap bmp;



        public Settings_Form SettingsForm;

        public Heater_Calibrator()
        {
            try
            {
                string AduHid = File.ReadAllText(@"AduHid.dll", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("AduHid.dll is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            try
            {
                string ontrak_sn = File.ReadAllText(@"ontrak.ini", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ontrak.ini is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            try
            {
                string CalibrationExpiryDates = File.ReadAllText(@"CalibrationExpiryDates.ini", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("CalibrationExpiryDates.ini is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            try
            {
                string HeaterLookup = File.ReadAllText(@"Heater Lookup.ini", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Heater Lookup.ini is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            InitializeComponent();
            Cal.parent = this;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string ontrak_sn="N/A\nN/A";
            
            ontrak_sn = File.ReadAllText(@"ontrak.ini", Encoding.UTF8);


            Version_Number.Text = "Version " + VER_NUMBER;
            tools = new Tools();

            try
            {
                string[] sns = ontrak_sn.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                sns[0] = sns[0].Replace("\n", String.Empty);
                sns[0] = sns[0].Replace("\r", String.Empty);
                sns[0] = sns[0].Replace("\t", String.Empty);

                sns[1] = sns[1].Replace("\n", String.Empty);
                sns[1] = sns[1].Replace("\r", String.Empty);
                sns[1] = sns[1].Replace("\t", String.Empty);



                tools.Serial_number_device_A = sns[0];
                tools.Serial_number_device_B = sns[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with Ontrak.ini\n","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            CalibrationTime = new CalibrationTime();
           
            CalibrationTime.Timer();

            Kenny.Hide();
            fireworks.Hide();
            
            int i;
            
            
            getAvilablePort();
            tempreature_fifo = new double[SAMPLES];


            for (i = 0; i < 36; i++)
            {
                Data[i] = new double[SAMPLES];
                DataR[i] = new double[SAMPLES];
                Offset[i] = new double[SAMPLES];
            }
            
            SettingsForm = new Settings_Form(this);


            SettingsForm.Show();
            SettingsForm.Hide();


            for ( i = 0; i < 16; i++)
                HTR_RESUTLS.Rows.Add(i+1, 0,0);


          /*
            foreach (DataGridViewRow row in HTR_RESUTLS.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
           * */

            HTR_RESUTLS.AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            HTR_RESUTLS.ClearSelection();


            HTR_RESUTLS.AllowUserToAddRows = false;


            
            HTR1_Radio.Enabled = false;
            HTR2_Radio.Enabled = false;
            HTR3_Radio.Enabled = false;
            HTR4_Radio.Enabled = false;
            HTR5_Radio.Enabled = false;
            HTR6_Radio.Enabled = false;
            HTR7_Radio.Enabled = false;
            HTR8_Radio.Enabled = false;
            HTR9_Radio.Enabled = false;
            HTR10_Radio.Enabled = false;
            HTR11_Radio.Enabled = false;
            HTR12_Radio.Enabled = false;
            HTR13_Radio.Enabled = false;
            HTR14_Radio.Enabled = false;
            HTR15_Radio.Enabled = false;
            HTR16_Radio.Enabled = false;
            
            Print_PB.Enabled = false;

            Ontrak_SN.Text = "Ontrak SN: " + tools.Serial_number_device_A;
            Ontrak_SN.Update();
            
        }
        
        void getAvilablePort()  
        {
            string[] ports = SerialPort.GetPortNames();
        }
        


    int four_bit_fliprl(int val)
        {
            int results = 0;
            results = ((val << 3) & 0x8) | ((val << 1) & 0x4) | ((val >> 1) & 0x2) | ((val >> 3) & 0x1);
            return results;
        }



        double convert_data_to_R(double val,double Vref,double Res)
        {
            double v, r;
            v = (val * Vref) / (65535);
            r = (v * Res) / (Vref - v);
            return (r);
        }


       

      

        private void Pause_Click(object sender, EventArgs e)
        {
            if (Second_Worker.IsBusy) Second_Worker.CancelAsync();
        }

     

        private void Heater_Calibrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            tools.send_commnad("RK0", 0);
            //Motor.Enabled = true;
            tools.Close_Devices();
            SettingsForm.Close();
        }



      

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsForm.Show();
        }

       

        private void Heater_Calibrator_Shown(object sender, EventArgs e)
        {
            
        }
        
        private void Start_Cal_Htrs_Click(object sender, EventArgs e)
        {
            
        }
        

        private void Pause_Cal_Htrs_Click(object sender, EventArgs e)
        {
            if (Second_Worker.IsBusy) Second_Worker.CancelAsync();

        }
        

        double test;
        
        private void Second_Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            double THERM;
            double temp;
            string command;
            int index=0;
            double max_i=0;

            double[] temp_temps = new double[4];

            for (; ;)
            {
               // worker_counter++;
                if (Second_Worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                

                //_________________________________________Thermostat Reading___________________________________
                tools.send_commnad("SK0", 0);
                for (int k = 0; k < 4; k++)
                {
                    command = "SPA" + Convert.ToString(k, 2).PadLeft(4, '0'); ;
                    tools.send_commnad(command, 0);
                    Thread.Sleep(100);
                    DataR[k][worker_counter % SAMPLES] = convert_data_to_R(Convert.ToDouble(tools.read_command("RUC11", 0)), 1.25, 10000);
                    Data[k][worker_counter % SAMPLES] = SettingsForm.convert_R_to_T(DataR[k][worker_counter % SAMPLES], (k + 1));
                    Status[k] = (Data[k].Average() <= (37 + THRESH_HOLD_Enviroment)) && (Data[k].Average() >= (37 - THRESH_HOLD_Enviroment));
                  //  MessageBox.Show(Data[k][worker_counter % SAMPLES].ToString());
                }
                 temp_avg=((Data[0].Average() + Data[1].Average() + Data[2].Average() + Data[3].Average()) / 4);
                 tools.send_commnad("RK0", 0);
                //_______________________________________________________________________________________________
                
                 //_______________________________________________________________________________________________
                      

                //_________________________________________Heater Reading________________________________________
                int kflipr;
                int  kk = 0;
                int avg_cc = 0;
                double sum_calculator;

                double[] Sampler = new double[AVG_SAMPLES];
                for ( kk = 0; kk < 16; kk++)
                {
                   kflipr= four_bit_fliprl(kk);
                   for (int p = 0; p < AVG_SAMPLES; p++)
                   {

                        command = "SPA" + Convert.ToString(kflipr, 2).PadLeft(4, '0'); ;
                        MessageBox.Show(command);

                        tools.send_commnad(command, 0);
                       Thread.Sleep(40);
                      if(p==0) Sampler[p] = convert_data_to_T(Convert.ToDouble(tools.read_command("RUC02", 0)));
                      else Sampler[p] = convert_data_to_T(Convert.ToDouble(tools.read_command("RUC02", 0)));
                        
                   }
                 
                   sum_calculator = 0;
                   avg_cc=0;

                   for (int p = 0; p < AVG_SAMPLES; p++)
                   {
                       if (Sampler[p]>Sampler.Average())
                       {

                           sum_calculator += Sampler[p];
                           avg_cc++;
                       }
                      
                   }
                         
                   Data[kk + 4][worker_counter % SAMPLES] = sum_calculator / avg_cc;
                   Status[kk + 4] = (Data[kk + 4][worker_counter % SAMPLES]) > 20;
                   
                }
                //__________________________________________________________________________________________________

                
               
                  for (int k = 0; k < 16; k++)
                  {
                      
                      //_______________________________________offset calculations________________________________________
                      Offset[k + 4][worker_counter % SAMPLES] = (!Status[k + 4] || Offset_Status[k + 4]) ? Offset[k + 4][worker_counter % SAMPLES] : Data[k + 4][worker_counter % SAMPLES] - temp_avg;
                      //__________________________________________________________________________________________________

                      //_______________________________________detects if offset is stablised__________________________
                      double[] temps = { Data[0].Average(), Data[1].Average(), Data[2].Average(), Data[3].Average() };
                      Offset_Status[k + 4] = ((Math.Abs(Offset[k + 4].Max() - Offset[k + 4].Min())) <= THRESH_HOLD_Stable) && ref_therm_ok && (Offset[k + 4].Average()<3.5) && (Offset[k + 4].Average() > -3.5);




                      //_______________________________________Log Heater Data__________________________


                      File.AppendAllText(@"data\" + datetime + "_Offset.txt", Offset[k + 4][worker_counter % SAMPLES].ToString() + "\t");
                      File.AppendAllText(@"data\" + datetime + "_Data.txt", Data[k + 4][worker_counter % SAMPLES].ToString() + "\t");   
                         
                  }
                  File.AppendAllText(@"data\" + datetime + "_Offset.txt", Environment.NewLine);
                  File.AppendAllText(@"data\" + datetime + "_Data.txt", Environment.NewLine);

                  ref_therm_ok = Status[0] &&
                                    Status[1] &&
                                    Status[2] &&
                                    Status[3];

                  Cal_Sucess = true;
                  for (int row = 0; row < 16; row++)
                  {
                      Cal_Sucess = Cal_Sucess && (!(Status[row + 4] ^ Offset_Status[row + 4]));
                      //MessageBox.Show(Cal_Sucess.ToString() + "\t" + Status[row + 4].ToString() + "\t" + Offset_Status[row + 4]);
                  }

                  Cal_Sucess = Cal_Sucess && ref_therm_ok;

                  //Cal_Sucess = Cal_Sucess && 
                  TimeOut = worker_counter >= TIMEOUT;

                  if ((Cal_Sucess && worker_counter > MINMUM_COUNTS) || TimeOut) 
                  {
                      Sound.Play();
                      Second_Worker.CancelAsync();

                      while (!Second_Worker.CancellationPending)
                      {
                          System.Threading.Thread.Sleep(1000);
                      }
                        if (Second_Worker.CancellationPending) e.Cancel = true;

                      Connect2.Enabled = true;
                      Print_PB.Enabled = true;
                      Calibration_PB.Enabled = true;
                      LotNum.Enabled = true;
                      
                      for (int k = 0; k < 16; k++)
                      {
                          if (k == 0 && Status[k + 4]) HTR1_Radio.Enabled = true;
                          if (k == 1 && Status[k + 4]) HTR2_Radio.Enabled = true;
                          if (k == 2 && Status[k + 4]) HTR3_Radio.Enabled = true;
                          if (k == 3 && Status[k + 4]) HTR4_Radio.Enabled = true;
                          if (k == 4 && Status[k + 4]) HTR5_Radio.Enabled = true;
                          if (k == 5 && Status[k + 4]) HTR6_Radio.Enabled = true;
                          if (k == 6 && Status[k + 4]) HTR7_Radio.Enabled = true;
                          if (k == 7 && Status[k + 4]) HTR8_Radio.Enabled = true;
                          if (k == 8 && Status[k + 4]) HTR9_Radio.Enabled = true;
                          if (k == 9 && Status[k + 4]) HTR10_Radio.Enabled = true;
                          if (k == 10 && Status[k + 4]) HTR11_Radio.Enabled = true;
                          if (k == 11 && Status[k + 4]) HTR12_Radio.Enabled = true;
                          if (k == 12 && Status[k + 4]) HTR13_Radio.Enabled = true;
                          if (k == 13 && Status[k + 4]) HTR14_Radio.Enabled = true;
                          if (k == 14 && Status[k + 4]) HTR15_Radio.Enabled = true;
                          if (k == 15 && Status[k + 4]) HTR16_Radio.Enabled = true;
                      }
                      Kenny.Hide();
                      fireworks.Show();
                  }
                 worker_counter++;
                    Second_Worker.ReportProgress(0);
            }
        }





        void fill_array(double[] array, int length, double number)
        {
            for (int i = 0; i < length; i++)
                array[i] = number;
        }



        void array_printer(double[] array, int length)
        {
            string printed_string = "";
            int i;
            for ( i=0; i < length; i++)
                printed_string = printed_string + array[i].ToString() + "\n";

            MessageBox.Show(printed_string);
        }



        
        double convert_data_to_T(double val)
        {
            double v, t;
            v = val * (2.5/4)  / (65535);
            t =  (v*100) ;
            return (t);
        }







        private void Second_Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int row;
            double[] temps = { Data[0].Average(), Data[1].Average(), Data[2].Average(), Data[3].Average() };

            //_________________________________________Dsiplay heater tempreature in Label___________________

            J135_Therm.Text = "J100 Temperature:\t" + Math.Round(Data[0].Average(), 2).ToString() + " C";
            J134_Therm.Text = "J102 Temperature:\t" + Math.Round(Data[1].Average(), 2).ToString() + " C";
            J101_Therm.Text = "J101 Temperature:\t" + Math.Round(Data[2].Average(), 2).ToString() + " C";
            J100_Therm.Text = "J103 Temperature:\t" + Math.Round(Data[3].Average(), 2).ToString() + " C";


            for (row = 0; row < 16; row++)
            {
                HTR_RESUTLS.Rows[row].Cells[1].Value = (Status[row + 4] ? Math.Round(Offset[row + 4].Average(), 2).ToString("0.00") + " C" : "N/A");
                HTR_RESUTLS.Rows[row].Cells[2].Value = (Status[row + 4] ? Math.Round(Data[row + 4].Average(), 2).ToString("0.00") + " C" : "N/A");
                HTR_RESUTLS.Rows[row].Cells[1].Style.ForeColor = Offset_Status[row + 4] ? Color.Green : Color.Red;
                HTR_RESUTLS.Rows[row].Cells[2].Style.ForeColor = Offset_Status[row + 4] ? Color.Green : Color.Red;

                if ((Cal_Sucess && worker_counter > MINMUM_COUNTS) || TimeOut)
                {
                    if (Status[row + 4] && !Offset_Status[row + 4])
                    {
                        HTR_RESUTLS.Rows[row].Cells[1].Value = HTR_RESUTLS.Rows[row].Cells[1].Value + " Fail!";
                        HTR_RESUTLS.Rows[row].Cells[2].Value = HTR_RESUTLS.Rows[row].Cells[2].Value + " Fail!";
                    }
                    else if (Status[row + 4] && Offset_Status[row + 4])
                    {
                        HTR_RESUTLS.Rows[row].Cells[1].Value = HTR_RESUTLS.Rows[row].Cells[1].Value + " Ok";
                        HTR_RESUTLS.Rows[row].Cells[2].Value = HTR_RESUTLS.Rows[row].Cells[2].Value + " Ok";
                    }
                }


                
            }
            HTR_RESUTLS.Update(); 

            
            THERM_AVG.Text = "Average Temperature:\t" + Math.Round(temp_avg, 2).ToString() + " C";

            THERM_AVG.ForeColor = (((temps.Max() - temps.Min()) < THRESH_HOLD_TopVsBottom) && 
                                    Status[0] &&
                                    Status[1] &&
                                    Status[2] &&
                                    Status[3]  )
                                                 ? System.Drawing.Color.Green : System.Drawing.Color.Red;

   


            J135_Therm.ForeColor = Status[0] ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            J134_Therm.ForeColor = Status[1] ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            J101_Therm.ForeColor = Status[2] ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            J100_Therm.ForeColor = Status[3] ? System.Drawing.Color.Green : System.Drawing.Color.Red;


            J101_Therm.Update();
            J100_Therm.Update();
            J135_Therm.Update();
            J134_Therm.Update();
            THERM_AVG.Update();



            if ((Cal_Sucess && worker_counter > MINMUM_COUNTS) || TimeOut)
            {
                prepare_print();
                bmp.Save(@"data\" + datetime + ".bmp");
            }
            
              
           
        }
        public int Therm_exp => Heater_Calibrator.Therm_expiryDate;
        public int PCBA_exp => Heater_Calibrator.PCBA_expiryDate;
        public int HeaterBath_exp => Heater_Calibrator.HeaterBath_expiryDate;
        private bool[] EXP_Stat = new bool[6];
        private void Connect2_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            for (int i = 0; i < 6; i++) EXP_Stat[i] = CalibrationTime.check_stat(i);

             datetimeReport = DateTime.Now.ToString("dd-MMM-yyyy,hh:mm tt");

            if (!EXP_Stat[0]|| !EXP_Stat[1] || !EXP_Stat[2] || !EXP_Stat[3] || !EXP_Stat[4] || !EXP_Stat[5])
            {
                string temp = "";
                temp = (!EXP_Stat[0]) ? temp + "Thermistor 1 Calibration is Expired \n" : temp;
                temp = (!EXP_Stat[1]) ? temp + "Thermistor 2 Calibration is Expired \n" : temp;
                temp = (!EXP_Stat[2]) ? temp + "Thermistor 3 Calibration is Expired \n" : temp;
                temp = (!EXP_Stat[3]) ? temp + "Thermistor 4 Calibration is Expired \n" : temp;
                temp = (!EXP_Stat[4]) ? temp + "PCBA Calibration is Expired \n" : temp;
                temp = (!EXP_Stat[5]) ? temp + "Heater Bath Calibration is Expired \n" : temp;
                MessageBox.Show(temp);
            }
            else if (LotNum.Text == "") {
                MessageBox.Show("Lot Number Field is empty, Please Enter the Lot number");
            }
            else if (!tools.open_device(0))
            {
                MessageBox.Show("Failed to Connect to Ontrak");
            }
            else
            {
                fireworks.Hide();
                Kenny.Show();
                LotNum.Enabled = false;
                Calibration_PB.Enabled = false;
                datetime = DateTime.Now.ToString("ddMMMyyyyHHmm");
                Connect2.Enabled = false;
                complete_flag = false;
                complete_calibration = false;

                init_boards();

                for (int m = 0; m < 36; m++)
                {
                    Array.Clear(Data[m], 0, Data[m].Length);
                    fill_array(Offset[m], Offset[m].Length, 999);
                    Offset[m][0] = 0;
                    Status[m] = false;
                    Status_buffer[m] = false;
                    Offset_Status[m] = false;

                    worker_counter = 0;

                    HTR1_Radio.Enabled = false;
                    HTR2_Radio.Enabled = false;
                    HTR3_Radio.Enabled = false;
                    HTR4_Radio.Enabled = false;
                    HTR5_Radio.Enabled = false;
                    HTR6_Radio.Enabled = false;
                    HTR7_Radio.Enabled = false;
                    HTR8_Radio.Enabled = false;
                    HTR9_Radio.Enabled = false;
                    HTR10_Radio.Enabled = false;
                    HTR11_Radio.Enabled = false;
                    HTR12_Radio.Enabled = false;
                    HTR13_Radio.Enabled = false;
                    HTR14_Radio.Enabled = false;
                    HTR15_Radio.Enabled = false;
                    HTR16_Radio.Enabled = false;


                    HTR1_Radio.Checked = false;
                    HTR2_Radio.Checked = false;
                    HTR3_Radio.Checked = false;
                    HTR4_Radio.Checked = false;
                    HTR5_Radio.Checked = false;
                    HTR6_Radio.Checked = false;
                    HTR7_Radio.Checked = false;
                    HTR8_Radio.Checked = false;
                    HTR9_Radio.Checked = false;
                    HTR10_Radio.Checked = false;
                    HTR11_Radio.Checked = false;
                    HTR12_Radio.Checked = false;
                    HTR13_Radio.Checked = false;
                    HTR14_Radio.Checked = false;
                    HTR15_Radio.Checked = false;
                    HTR16_Radio.Checked = false;

                    if (!Second_Worker.IsBusy) Second_Worker.RunWorkerAsync();
                    Print_PB.Enabled = false;
                }
            }
        }
        
        private void Calibration_PB_Click(object sender, EventArgs e)
        {
            Cal.Show();
        }


        private void init_boards()
        {
            tools.send_commnad("CPA0000", 0);
            Thread.Sleep(1000);
           // tools.send_commnad("CPA0000", 1);
            int bits_o;
            string command;
            for (int i = 0; i < 16; i++)
            {
                bits_o = (four_bit_fliprl((i & 0xf) << 1));
                command = "SPA" + Convert.ToString(bits_o, 2).PadLeft(4, '0');
                tools.send_commnad(command, 0);
                Thread.Sleep(50);
            }

            
        }
        private void HTR1_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR1_Radio.Checked == true)
            {
                LED_On(0);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[0 + 4].Average(),2).ToString("0.00") + " C");
            }
                
        }

        private void HTR2_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR2_Radio.Checked == true)
            {
                LED_On(1);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[1 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR3_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR3_Radio.Checked == true)
            {
                LED_On(2);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[2 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR4_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR4_Radio.Checked == true)
            {
                LED_On(3);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[3 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR5_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR5_Radio.Checked == true)
            {
                LED_On(4);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[4 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR6_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR6_Radio.Checked == true)
            {
                LED_On(5);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[5 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR7_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR7_Radio.Checked == true)
            {
                LED_On(6);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[6 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR8_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR8_Radio.Checked == true)
            {
                LED_On(7);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[7 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR9_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR9_Radio.Checked == true)
            {
                LED_On(8);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[8 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR10_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR10_Radio.Checked == true)
            {
                LED_On(9);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[9 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR11_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR11_Radio.Checked == true)
            {
                LED_On(10);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[10 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR12_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR12_Radio.Checked == true)
            {
                LED_On(11);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[11 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR13_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR13_Radio.Checked == true)
            {
                LED_On(12);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[12 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR14_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR14_Radio.Checked == true)
            {
                LED_On(13);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[13 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR15_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR15_Radio.Checked == true)
            {
                LED_On(14);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[14 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }

        private void HTR16_Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (HTR16_Radio.Checked == true)
            {
                LED_On(15);
                MessageBox.Show("The Offset for the selected heater is: " + Math.Round(Offset[15 + 4].Average(), 2).ToString("0.00") + " C");
            }
        }


        private void LED_On(int i)
        {
            tools.send_commnad("SPA" + Convert.ToString((four_bit_fliprl((i & 0xf) )), 2).PadLeft(4, '0'), 0);
        }

        private void Print_PB_Click(object sender, EventArgs e)
        {
           // prepare_print();
           // bmp.Save(@"data\" + datetime + ".bmp");
            printDocument.Print();
        }


        public void prepare_print()
        {
            int height = HTR_RESUTLS.Height;
            HTR_RESUTLS.Height = HTR_RESUTLS.RowCount * HTR_RESUTLS.RowTemplate.Height * 2;
            bmp = new Bitmap(HTR_RESUTLS.Width + 500, HTR_RESUTLS.Height + 600);
            HTR_RESUTLS.DrawToBitmap(bmp, new Rectangle(150, 100, 300, 385));

            HTR_RESUTLS.Height = height;

            groupBox1.DrawToBitmap(bmp, new Rectangle(HTR_RESUTLS.Width+200, 100, groupBox1.Width, groupBox1.Height));




            RectangleF rectf = new RectangleF(10, 10, 1000, 100);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("Date,Time: " + datetimeReport, new Font("Arial", 18), Brushes.Black, rectf);

            g.Flush();


            rectf = new RectangleF(10, 50, 1000, 100);
            g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("Lot Number :\t" + LotNum.Text, new Font("Arial", 18), Brushes.Black, rectf);

            g.Flush();


            rectf = new RectangleF(10, 840, 1000, 100);
            g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("Operator :\t______________________________ ", new Font("Arial", 18), Brushes.Black, rectf);

            g.Flush();


            rectf = new RectangleF(10, 880, 1000, 100);
            g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("Signature :\t______________________________ ", new Font("Arial", 18), Brushes.Black, rectf);

            g.Flush();


            rectf = new RectangleF(10, 920, 1000, 100);
            g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString("Date :\t______________________________ ", new Font("Arial", 18), Brushes.Black, rectf);

            g.Flush();
        }
        
        private void printDocument_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

    }
}
