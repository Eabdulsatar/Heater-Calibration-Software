using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;




namespace Heater_NTC_Calibrator
{
    public partial class Settings_Form : Form
    {


        private Heater_Calibrator parent;


        const string filename = @"Heater Lookup.ini";


        public Settings_Form(Heater_Calibrator parent)
        {
          
            InitializeComponent();
            this.parent = parent;
            
           
        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {
            load_tables();
        }

        private void Settings_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

         private void Save_Data_Click(object sender, EventArgs e)
         {
            
         }

         private void Data_Grid_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }

         private void Paste1_Click(object sender, EventArgs e)
         {

             if (Heaters_thermosters.SelectedTab.Text == "Ref 1") Paste(Data_Grid_1);
             if (Heaters_thermosters.SelectedTab.Text == "Ref 2") Paste(Data_Grid_2);
             if (Heaters_thermosters.SelectedTab.Text == "Ref 3") Paste(Data_Grid_3);
             if (Heaters_thermosters.SelectedTab.Text == "Ref 4") Paste(Data_Grid_4);

            // MessageBox.Show(Data_Grid_1.Size.ToString());
             //MessageBox.Show(Data_Grid_1.RowCount.ToString());
            
         }


         private void Paste(DataGridView d)
         {
             DataObject o = (DataObject)Clipboard.GetDataObject();
             if (o.GetDataPresent(DataFormats.StringFormat))
             {
                 string[] pastedRows = Regex.Split(o.GetData(DataFormats.StringFormat).ToString().TrimEnd("\r\n".ToCharArray()), "\r");
                 int j = 0;
                 try { j = d.CurrentRow.Index; }
                 catch { }
                 foreach (string pastedRow in pastedRows)
                 {
                     DataGridViewRow r = new DataGridViewRow();
                     r.CreateCells(d, pastedRow.Split(new char[] { '\t' }));
                     d.Rows.Insert(j, r);
                     j++;
                 }
             }

          //   d.Rows.RemoveAt(d.RowCount - 2);

         }


        private void load_string_into_datagridview(DataGridView d,string o){
            string[] pastedRows = Regex.Split(o.ToString().TrimEnd("\r\n".ToCharArray()), "\n");
            int j = 0;
            try { j = d.CurrentRow.Index; }
            catch { }
            foreach (string pastedRow in pastedRows)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(d, pastedRow.Split(new char[] { '\t' }));
                d.Rows.Insert(j, r);
                d.Rows[j].Cells[0].Value = Convert.ToDouble(d.Rows[j].Cells[0].Value.ToString());
                d.Rows[j].Cells[1].Value = Convert.ToDouble(d.Rows[j].Cells[1].Value.ToString());
                j++;
            }
        }
        

         private void load_tables()
         {
             string text = Read_file();
             string ref1, ref2, ref3, ref4;
             string[] s = text.Split('-');

             ref1 = s[0];
             ref2 = s[1].Remove(0,1);
             ref3 = s[2].Remove(0, 1);
             ref4 = s[3].Remove(0, 1);

             load_string_into_datagridview(Data_Grid_1, ref1);
             load_string_into_datagridview(Data_Grid_2, ref2);
             load_string_into_datagridview(Data_Grid_3, ref3);
             load_string_into_datagridview(Data_Grid_4, ref4);


             sort(Data_Grid_1);
             sort(Data_Grid_2);
             sort(Data_Grid_3);
             sort(Data_Grid_4);
         }

         private string Read_file()
         {
             string file_Text = File.ReadAllText(filename);
            try
            {
                if (!File.Exists(filename))
                {
                    throw (new Exception("The file doesn't exist!"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ontrak.ini doesn't exist!\n" + ex.ToString());
            }

            if (file_Text == "")
             {
                 MessageBox.Show("The lookup Configuration File is empty");
                 return ("");
             }
             else
             {
                 return (file_Text);
             }
         }

         public void Save_file(string text)
         {
             System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
             file.WriteLine(text);
             file.Close();
         }



         private void Save1_Click(object sender, EventArgs e)
         {
             Save_file(combine_tables());

         }


         private string combine_tables()
         {

             string ref1_text = "", ref2_text = "", ref3_text = "", ref4_text = "";
             int ref1, ref2, ref3, ref4;

             string part1, part2;

             ref1 = Data_Grid_1.RowCount-1;
             ref2 = Data_Grid_2.RowCount-1;
             ref3 = Data_Grid_3.RowCount-1;
             ref4 = Data_Grid_4.RowCount-1;
            
             for (int i = 0; i < ref1; i++)
             {
                 part1 = Data_Grid_1.Rows[i].Cells[0].Value.ToString();
                 part2 = Data_Grid_1.Rows[i].Cells[1].Value.ToString();
                 part1 = part1.Replace("\n", String.Empty);
                 part1 = part1.Replace("\r", String.Empty);
                 part1 = part1.Replace("\t", String.Empty);
                 part2 = part2.Replace("\n", String.Empty);
                 part2 = part2.Replace("\r", String.Empty);
                 part2 = part2.Replace("\t", String.Empty);
                 ref1_text = ref1_text + part1 + "\t" + part2+"\n";
             }

             for (int i = 0; i < ref2; i++)
             {
                 part1 = Data_Grid_2.Rows[i].Cells[0].Value.ToString();
                 part2 = Data_Grid_2.Rows[i].Cells[1].Value.ToString();
                 part1 = part1.Replace("\n", String.Empty);
                 part1 = part1.Replace("\r", String.Empty);
                 part1 = part1.Replace("\t", String.Empty);
                 part2 = part2.Replace("\n", String.Empty);
                 part2 = part2.Replace("\r", String.Empty);
                 part2 = part2.Replace("\t", String.Empty);
                 ref2_text = ref2_text + part1 + "\t" + part2 + "\n";
             }

             for (int i = 0; i < ref3; i++)
             {
                 part1 = Data_Grid_3.Rows[i].Cells[0].Value.ToString();
                 part2 = Data_Grid_3.Rows[i].Cells[1].Value.ToString();
                 part1 = part1.Replace("\n", String.Empty);
                 part1 = part1.Replace("\r", String.Empty);
                 part1 = part1.Replace("\t", String.Empty);
                 part2 = part2.Replace("\n", String.Empty);
                 part2 = part2.Replace("\r", String.Empty);
                 part2 = part2.Replace("\t", String.Empty);
                 ref3_text = ref3_text + part1 + "\t" + part2 + "\n";
             }

             for (int i = 0; i < ref4; i++)
             {
                 part1 = Data_Grid_4.Rows[i].Cells[0].Value.ToString();
                 part2 = Data_Grid_4.Rows[i].Cells[1].Value.ToString();
                 part1 = part1.Replace("\n", String.Empty);
                 part1 = part1.Replace("\r", String.Empty);
                 part1 = part1.Replace("\t", String.Empty);
                 part2 = part2.Replace("\n", String.Empty);
                 part2 = part2.Replace("\r", String.Empty);
                 part2 = part2.Replace("\t", String.Empty);
                 ref4_text = ref4_text + part1 + "\t" + part2 + "\n";
             }
           
           

             return (ref1_text + "-\n" + ref2_text + "-\n" + ref3_text + "-\n" + ref4_text);
         }

         private void sort(DataGridView d)
         {
             
             d.Sort(d.Columns[1], ListSortDirection.Ascending);
         }






         public double convert_R_to_T(double R, Int32 refT)
         {
             double returned = -1;
             double upper,lower;
             int j;
             double[] columnData;
             DataGridView d;
             double A1, A2, B1, B2;

             if (refT == 1) d = Data_Grid_4;
             else if (refT == 2) d = Data_Grid_3;
             else if (refT == 3) d = Data_Grid_2;
             else d = Data_Grid_1;


           columnData = new double[d.RowCount-1];
             for (j = 0; j < (d.RowCount-1); j++) columnData[j] = Convert.ToDouble(d.Rows[j].Cells[1].Value.ToString());
             //MessageBox.Show(R.ToString() + "\n" + columnData.Max().ToString() + "\n" + columnData.Min().ToString());

             try
             {
                 if (R < columnData.Max() && R > columnData.Min())
                 {
                     for (j = 0; R > columnData[j]; j++) ;
                     upper = columnData[j];
                     lower = columnData[j - 1];
                     A1 = Convert.ToDouble(d.Rows[j].Cells[1].Value);
                     A2 = Convert.ToDouble(d.Rows[j - 1].Cells[1].Value);
                     B1 = Convert.ToDouble(d.Rows[j].Cells[0].Value);
                     B2 = Convert.ToDouble(d.Rows[j - 1].Cells[0].Value);
                     returned = linear_approx(A1, A2, B1, B2, R);
                 }
                 else returned = -1;
             }
             catch(Exception e) 
             {
                 MessageBox.Show(e.ToString() + "\n" + R + "\n" + columnData.Max() + "\n" + columnData.Min());
             }


             return (returned);

         }




         private double linear_approx(double A1, double A2, double B1, double B2, double R)
         {
             double ans = -1;
             double slope;
             slope = (B2 - B1) / (A2 - A1);
             ans = (slope * (R - A1)) + B1;
             return (ans);
         } 


      
       






        
    }
}
