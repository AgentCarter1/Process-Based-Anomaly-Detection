using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Windows.Forms;
using static Sharp7.S7Client;
namespace PLC
{
    public static class BasicData
    {

        public static void AnomalyDetection(S7Client plc1,S7Client plc2, S7Client plc3,ListBox lstBox)
        {
            byte[] db1Buffer = new byte[18];
            byte[] db2Buffer = new byte[18];
            byte[] db3Buffer = new byte[18];
            int result1 = plc1.DBRead(1, 0, 18, db1Buffer);
            int result2 = plc2.DBRead(1, 0, 18, db2Buffer);
            int result3 = plc3.DBRead(1, 0, 18, db3Buffer);
            float currentlevel1 = 0, currentlevel2 = 0, currentlevel3 = 0;
            if (result1 != 0)
            {
                MessageBox.Show(plc1.ErrorText(result1), "Error", MessageBoxButtons.OK);
            }else
            {
                currentlevel1= S7.GetRealAt(db1Buffer, 2);
            }

            if (result2 != 0)
            {
                MessageBox.Show(plc2.ErrorText(result2), "Error", MessageBoxButtons.OK);
            }
            else
            {
                currentlevel2 = S7.GetRealAt(db2Buffer, 4);
            }

            if (result3 != 0)
            {
                MessageBox.Show(plc3.ErrorText(result3), "Error", MessageBoxButtons.OK);
            }
            else
            {
                currentlevel3 = S7.GetRealAt(db3Buffer, 4);
            }

            if (Convert.ToUInt32(currentlevel1) < 10 && (Convert.ToUInt32(currentlevel2) > 50))
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 20 && Convert.ToUInt32(currentlevel2) > 60)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 30 && Convert.ToUInt32(currentlevel2) > 70) {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 40 && Convert.ToUInt32(currentlevel2) > 80)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 10 && Convert.ToUInt32(currentlevel2) < 10)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 20 && Convert.ToUInt32(currentlevel2) < 20)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 30 && Convert.ToUInt32(currentlevel2) < 30)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel1) < 40 && Convert.ToUInt32(currentlevel2) < 40)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon1 ve İstasyon2'nin Su Seviyesini Kontrol Edin!");
            }


            else if (Convert.ToUInt32(currentlevel2) < 10 && Convert.ToUInt32(currentlevel3) > 50)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel2) < 20 && Convert.ToUInt32(currentlevel3) > 60)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel2) < 30 && Convert.ToUInt32(currentlevel3) > 70)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel2) > 40 && Convert.ToUInt32(currentlevel3) > 80)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }

            else if (Convert.ToUInt32(currentlevel2) < 10 && Convert.ToUInt32(currentlevel3) < 10)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel2) < 20 && Convert.ToUInt32(currentlevel3) < 20)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel2) < 30 && Convert.ToUInt32(currentlevel3) < 30)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
            else if (Convert.ToUInt32(currentlevel2) < 40 && Convert.ToUInt32(currentlevel3) < 40)
            {
                lstBox.Items.Add((DateTime.Now).ToString() + "İstasyon2 ve İstasyon3'ün Su Seviyesini Kontrol Edin!");
            }
        }

        public static void getData(S7Client plc,TextBox totalvolume,TextBox currentlevel,TextBox currentvolume,
            ProgressBar progressBar1, Label labelProportion,Label localLabel, int result,int secondDb,int totalVolumeOff,
            int currentVolumeOff,int currentLevelOff,int treatment,TextBox treatmentTextbox)
        {
            if (result == 0)
            {

                byte[] db1Buffer = new byte[18];
                result = plc.DBRead(1, 0, 18, db1Buffer);
                if (result != 0)
                {
                    MessageBox.Show(plc.ErrorText(result), "Error", MessageBoxButtons.OK);
                }

                float totalVolume = S7.GetRealAt(db1Buffer, totalVolumeOff);
                totalvolume.Text = totalVolume.ToString();

                float currentLevel = S7.GetRealAt(db1Buffer, currentLevelOff);
                currentlevel.Text = currentLevel.ToString();
                if(Convert.ToInt32(currentLevel)<0)
                    progressBar1.Value = (Convert.ToInt32(currentLevel))*(-1);
                else
                    progressBar1.Value = Convert.ToInt32(currentLevel);
                labelProportion.Text = "%" + progressBar1.Value.ToString();

                float currentVolume = S7.GetRealAt(db1Buffer, currentVolumeOff);
                currentvolume.Text = currentVolume.ToString();
               
                //for take data other table
                result = plc.DBRead(secondDb, 0, 18, db1Buffer);
                if (result != 0)
                {
                    MessageBox.Show(plc.ErrorText(result), "Error", MessageBoxButtons.OK);
                }
                bool local = S7.GetBitAt(db1Buffer, 0, 0);
                localLabel.Text = local.ToString();

                if(treatment != 0)
                {
                    int currentLvlToSend = S7.GetIntAt(db1Buffer, treatment);
                    treatmentTextbox.Text = currentLvlToSend.ToString();
                }
            }
            else
            {
                MessageBox.Show(plc.ErrorText(result), "Error", MessageBoxButtons.OK);
            }
        }


   

       
    }
}
