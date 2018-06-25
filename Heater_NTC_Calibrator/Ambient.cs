using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;







public struct tAdcTemp
{

    public double RtR100;
    public double temp;
};





namespace Heater_NTC_Calibrator
{
    class Ambient
    {




        const double ADC_TEMPERATURE_VREF = 2.5;
        public tAdcTemp[] adcTempLookup;


        public Ambient()
        {
            adcTempLookup = new tAdcTemp[51];
            adcTempLookup[0].RtR100 = 3.5222; adcTempLookup[0].temp = 0;
            adcTempLookup[1].RtR100 = 3.3369; adcTempLookup[1].temp = 1;
            adcTempLookup[2].RtR100 = 3.1623; adcTempLookup[2].temp = 2;
            adcTempLookup[3].RtR100 = 2.9978; adcTempLookup[3].temp = 3;
            adcTempLookup[4].RtR100 = 2.8428; adcTempLookup[4].temp = 4;
            adcTempLookup[5].RtR100 = 2.6967; adcTempLookup[5].temp = 5;
            adcTempLookup[6].RtR100 = 2.5589; adcTempLookup[6].temp = 6;
            adcTempLookup[7].RtR100 = 2.4289; adcTempLookup[7].temp = 7;
            adcTempLookup[8].RtR100 = 2.3062; adcTempLookup[8].temp = 8;
            adcTempLookup[9].RtR100 = 2.1904; adcTempLookup[9].temp = 9;
            adcTempLookup[10].RtR100 = 2.0811; adcTempLookup[10].temp = 10;
            adcTempLookup[11].RtR100 = 1.9778; adcTempLookup[11].temp = 11;
            adcTempLookup[12].RtR100 = 1.8802; adcTempLookup[12].temp = 12;
            adcTempLookup[13].RtR100 = 1.788; adcTempLookup[13].temp = 13;
            adcTempLookup[14].RtR100 = 1.7008; adcTempLookup[14].temp = 14;
            adcTempLookup[15].RtR100 = 1.618; adcTempLookup[15].temp = 15;
            adcTempLookup[16].RtR100 = 1.540; adcTempLookup[16].temp = 16;
            adcTempLookup[17].RtR100 = 1.466; adcTempLookup[17].temp = 17;
            adcTempLookup[18].RtR100 = 1.397; adcTempLookup[18].temp = 18;
            adcTempLookup[19].RtR100 = 1.330; adcTempLookup[19].temp = 19;
            adcTempLookup[20].RtR100 = 1.268; adcTempLookup[20].temp = 20;
            adcTempLookup[21].RtR100 = 1.208; adcTempLookup[21].temp = 21;
            adcTempLookup[22].RtR100 = 1.152; adcTempLookup[22].temp = 22;
            adcTempLookup[23].RtR100 = 1.099; adcTempLookup[23].temp = 23;
            adcTempLookup[24].RtR100 = 1.048; adcTempLookup[24].temp = 24;
            adcTempLookup[25].RtR100 = 1.000; adcTempLookup[25].temp = 25;
            adcTempLookup[26].RtR100 = 0.9545; adcTempLookup[26].temp = 26;
            adcTempLookup[27].RtR100 = 0.9112; adcTempLookup[27].temp = 27;
            adcTempLookup[28].RtR100 = 0.8702; adcTempLookup[28].temp = 28;
            adcTempLookup[29].RtR100 = 0.8312; adcTempLookup[29].temp = 29;
            adcTempLookup[30].RtR100 = 0.7942; adcTempLookup[30].temp = 30;
            adcTempLookup[31].RtR100 = 0.7590; adcTempLookup[31].temp = 31;
            adcTempLookup[32].RtR100 = 0.7256; adcTempLookup[32].temp = 32;
            adcTempLookup[33].RtR100 = 0.6938; adcTempLookup[33].temp = 33;
            adcTempLookup[34].RtR100 = 0.6636; adcTempLookup[34].temp = 34;
            adcTempLookup[35].RtR100 = 0.6348; adcTempLookup[35].temp = 35;
            adcTempLookup[36].RtR100 = 0.6075; adcTempLookup[36].temp = 36;
            adcTempLookup[37].RtR100 = 0.5814; adcTempLookup[37].temp = 37;
            adcTempLookup[38].RtR100 = 0.5567; adcTempLookup[38].temp = 38;
            adcTempLookup[39].RtR100 = 0.5531; adcTempLookup[39].temp = 39;
            adcTempLookup[40].RtR100 = 0.5106; adcTempLookup[40].temp = 40;
            adcTempLookup[41].RtR100 = 0.4892; adcTempLookup[41].temp = 41;
            adcTempLookup[42].RtR100 = 0.4688; adcTempLookup[42].temp = 42;
            adcTempLookup[43].RtR100 = 0.4493; adcTempLookup[43].temp = 43;
            adcTempLookup[44].RtR100 = 0.4308; adcTempLookup[44].temp = 44;
            adcTempLookup[45].RtR100 = 0.4131; adcTempLookup[45].temp = 45;
            adcTempLookup[46].RtR100 = 0.3963; adcTempLookup[46].temp = 46;
            adcTempLookup[47].RtR100 = 0.3802; adcTempLookup[47].temp = 47;
            adcTempLookup[48].RtR100 = 0.3648; adcTempLookup[48].temp = 48;
            adcTempLookup[49].RtR100 = 0.3502; adcTempLookup[49].temp = 49;
            adcTempLookup[50].RtR100 = 0.3362; adcTempLookup[50].temp = 50;
        }





        public double AdcGetAmbientTemperature(double val)
        {
            int i;
            double coeff;    /* interpolation coefficient */
            double x0, x1;    /* Rt/R100 coordinates */

                
            /* determine Rt/R100 ratio */

            val = (2.5 * val) / (8*65535);
           // MessageBox.Show(val.ToString());
            val = ((ADC_TEMPERATURE_VREF / val) - 1 )/10;

            val = 1 / val;


            /* look up in table and interpolate */
            for (i = 0; i != adcTempLookup.Length; i++)
            {
                if (val >= adcTempLookup[i].RtR100) break;
            }

            /* return if value exceeds bounds */
            if ((i == 0) || (i == adcTempLookup.Length)) return 0;

            /* determine interpolation coefficient = (x-x0)/(x1-x0) */
            x0 = adcTempLookup[i-1].RtR100;
            x1 = adcTempLookup[i].RtR100;
            coeff = (val-x0)/(x1-x0);

            /* calculate linear interpolation: y = (1-coeff)y0 + coeff*y1 */
            val = (1-coeff)*adcTempLookup[i-1].temp + coeff*adcTempLookup[i].temp; //1.47999

            val = 1.0678*(val - 2.1722);

            return val;
        }




    }
}
