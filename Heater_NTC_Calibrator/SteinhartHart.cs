using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace Heater_NTC_Calibrator
{
    public class SteinhartHart
    {

        public int COEFF_CNT;

        

        public SteinhartHart(int temp)
        {
            setup();
            COEFF_CNT = temp;
        }

        private void setup()
        {
            
        }



        private void print_array(double[,] data)
        {

            string test="";

            for (int j = 0; j < COEFF_CNT; j++)
            {
                for (int i = 0; i < COEFF_CNT; i++)
                {
                    test = test + data[i, j].ToString() + "\t";
                }
                test = test + "\n";
            }

            MessageBox.Show(test);
            
                
        }


    

        public double [] SH_Compute(double[] R, double[] T)
        {

            double[] logR = new double[COEFF_CNT];
            double[] _T = new double[COEFF_CNT];
            double[] SH_C = new double[COEFF_CNT];
            double[,] matrix = new double[COEFF_CNT, COEFF_CNT];// i,j where i is R number and j is C number
            double[,] inv_matrix = new double[COEFF_CNT, COEFF_CNT];// i,j where i is R number and j is C number
            double det_matrix = 0;

            for (int i = 0; i < COEFF_CNT; i++)
                logR[i] = Math.Log(R[i]);



            for (int i = 0; i < COEFF_CNT; i++)
            {
                matrix[i,0] = 1;
                matrix[i,1] = logR[i];
                matrix[i,2] = logR[i] * logR[i] * logR[i];
                _T[i] = 1 / (T[i] + 273.15);
            }


            det_matrix = 0;

            for (int i = 0, j = 0; j < COEFF_CNT; j++)
                det_matrix = det_matrix + (matrix[i, j] * (matrix[((i + 1) % COEFF_CNT), ((j + 1) % COEFF_CNT)] * matrix[((i + 2) % COEFF_CNT), ((j + 2) % COEFF_CNT)] - matrix[((i + 1) % COEFF_CNT), ((j + 2) % COEFF_CNT)] * matrix[((i + 2) % COEFF_CNT), ((j + 1) % COEFF_CNT)]));


            for (int i = 0; i < COEFF_CNT; i++)
                for (int j = 0; j < COEFF_CNT; j++)
                {
                    inv_matrix[i, j] =(1/det_matrix)*(
                        matrix[((i + 1) % COEFF_CNT), ((j + 1) % COEFF_CNT)] * matrix[((i + 2) % COEFF_CNT), ((j + 2) % COEFF_CNT)] -
                        matrix[((i + 1) % COEFF_CNT), ((j + 2) % COEFF_CNT)] * matrix[((i + 2) % COEFF_CNT), ((j + 1) % COEFF_CNT)]);

                }

           

            for (int i = 0; i < COEFF_CNT; i++)
                SH_C[i] = 0;

            for (int i = 0; i < COEFF_CNT; i++)
                for (int j = 0; j < COEFF_CNT; j++)
                    SH_C[i] = SH_C[i] + _T[j] * inv_matrix[j, i];

/*
            MessageBox.Show(SH_C[0].ToString() + "\t" +
                SH_C[1].ToString() + "\t" +
                SH_C[2].ToString() + "\t"
                 );*/


            return (SH_C);
        }






    




    }
}
