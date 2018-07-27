using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heater_NTC_Calibrator
{
    public partial class CalibrationTime : Form
    {
        Calibration parent;

        private bool[] stat = new bool [6];

        public CalibrationTime(Calibration parent)
        {

            stat[0] = true;
            stat[1] = true;
            stat[2] = true;
            stat[3] = true;
            stat[4] = true;
            stat[5] = true;
            this.parent = parent;
            InitializeComponent();
            Timer();

        }
        CultureInfo MyCultureInfo = new CultureInfo("en-US");


        public bool check_stat(int i)
        {
            return (stat[i]);
        }

        private void CalibrationTime_Load(object sender, EventArgs e)
        {
            String[] components = { "Thermostor1", "Thermostor2", "Thermostor3", "Thermostor4", "PCBA", "HeaterBath" };
 
                label1.Text = components[0] + " is calibrated at ";
                label2.Text = components[1] + " is calibrated at ";
                label3.Text = components[2] + " is calibrated at ";
                label4.Text = components[3] + " is calibrated at ";
                label5.Text = components[4] + " is calibrated at ";
                label6.Text = components[5] + " is calibrated at ";
        }
        public int Therm_exp => Heater_Calibrator.Therm_expiryDate;
        public int PCBA_exp => Heater_Calibrator.PCBA_expiryDate;
        public int HeaterBath_exp => Heater_Calibrator.HeaterBath_expiryDate;

        public void Timer()
        {
            
            String[] components = { "Thermostor1", "Thermostor2", "Thermostor3", "Thermostor4", "PCBA", "HeaterBath" };
            String[] _date;
            try
            {
                _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
                for (int j = 0; j < 6; j++)
                {
                    string a = _date[j];
                }
                int i = 0;
                while (i < 6)
                {
                    _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
                    DateTime StartDate = Convert.ToDateTime("01-Jan-2001");

                    try
                    {
                        StartDate = Convert.ToDateTime(_date[i]);
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }

                    var LastDate = StartDate.AddDays(Therm_exp);
                    int total = (int)(DateTime.Now - StartDate).TotalDays-1;
                    int totalDaysToCal = (int)(LastDate - DateTime.Now).TotalDays+1;


                    if (total >= Therm_exp - 1)
                    {
                        MessageBox.Show(components[i] + " calibration has been expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        stat[i] = false;
                    }
                    else if (totalDaysToCal < 14)
                    {
                        MessageBox.Show("You have " + totalDaysToCal + " days to calibrate " + components[i], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    i++;
                    if (i == 4)
                    {
                        StartDate = Convert.ToDateTime(_date[i]);
                        LastDate = StartDate.AddDays(PCBA_exp);
                        total = (int)(DateTime.Now - StartDate).TotalDays-1;
                        totalDaysToCal = (int)(LastDate - DateTime.Now).TotalDays+1;

                        if (total >= PCBA_exp - 1)
                        {
                            MessageBox.Show(components[i] + " calibration has been expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            stat[i] = false;
                        }
                        else if (totalDaysToCal < 14)
                        {
                            MessageBox.Show("You have " + totalDaysToCal + " days to calibrate " + components[i], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        i++;
                    }
                    else if (i == 5)
                    {
                        StartDate = Convert.ToDateTime(_date[i]);
                        LastDate = StartDate.AddDays(HeaterBath_exp);
                        total = (int)(DateTime.Now - StartDate).TotalDays-1;
                        totalDaysToCal = (int)(DateTime.Now - LastDate).TotalDays+1;
                        if (total >= HeaterBath_exp - 1)
                        {
                            MessageBox.Show(components[i] + " calibration has been expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            stat[i] = false;
                        }
                        else if (totalDaysToCal < 14)

                        {
                            MessageBox.Show("You have " + totalDaysToCal + " days to calibrate " + components[i], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        i++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error with CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String st = dateTimePicker1.Value.ToString("dd-MMM-yyyy");
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            _date[0] = st;
            File.WriteAllLines(@"CalibrationExpiryDates.ini", _date);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            String st = dateTimePicker2.Value.ToString("dd-MMM-yyyy");
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            _date[1] = st;
            File.WriteAllLines(@"CalibrationExpiryDates.ini", _date);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            String st = dateTimePicker3.Value.ToString("dd-MMM-yyyy");
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            _date[2] = st;
            File.WriteAllLines(@"CalibrationExpiryDates.ini", _date);
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            String st = dateTimePicker4.Value.ToString("dd-MMM-yyyy");
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            _date[3] = st;
            File.WriteAllLines(@"CalibrationExpiryDates.ini", _date);
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            String st = dateTimePicker5.Value.ToString("dd-MMM-yyyy");
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            _date[4] = st;
            File.WriteAllLines(@"CalibrationExpiryDates.ini", _date);
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            String st = dateTimePicker6.Value.ToString("dd-MMM-yyyy");
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            _date[5] = st;
            File.WriteAllLines(@"CalibrationExpiryDates.ini", _date);
        }

        private void dateTimePicker1_VisibleChanged(object sender, EventArgs e)
        {
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            try
            {
                dateTimePicker1.Value = Convert.ToDateTime(_date[0]);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MMM-yyyy";

        }
        private void dateTimePicker2_VisibleChanged(object sender, EventArgs e)
        {
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");

            try
            {
                dateTimePicker2.Value = Convert.ToDateTime(_date[1]);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
        }

        private void dateTimePicker3_VisibleChanged(object sender, EventArgs e)
        {
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            // DateTime StartDate = Convert.ToDateTime("01-Jan-2001");

            try
            {
                dateTimePicker3.Value = Convert.ToDateTime(_date[2]);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd-MMM-yyyy";
        }

        private void dateTimePicker4_VisibleChanged(object sender, EventArgs e)
        {
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");

            try
            {
                dateTimePicker4.Value = Convert.ToDateTime(_date[3]);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "dd-MMM-yyyy";
        }

        private void dateTimePicker5_VisibleChanged(object sender, EventArgs e)
        {
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            try
            {
                dateTimePicker5.Value = Convert.ToDateTime(_date[4]);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "dd-MMM-yyyy";
        }

        private void dateTimePicker6_VisibleChanged(object sender, EventArgs e)
        {
            var _date = File.ReadAllLines(@"CalibrationExpiryDates.ini");
            try
            {
                dateTimePicker6.Value = Convert.ToDateTime(_date[5]);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Invalid date format in CalibrationExpiryDates.ini\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            dateTimePicker6.Format = DateTimePickerFormat.Custom;
            dateTimePicker6.CustomFormat = "dd-MMM-yyyy";
        }
    }
}
