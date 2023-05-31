using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharp7;
using static Sharp7.S7Client;
namespace PLC
{
    public partial class Form1 : Form
    {
        static S7Client plc1 = new S7Client();
        static S7Client plc2 = new S7Client();
        static S7Client plc3 = new S7Client();
        public int result1 = plc1.ConnectTo("192.168.41.10", 0, 1);
        public int result = plc2.ConnectTo("192.168.42.10", 0, 1);
        public int result3 = plc3.ConnectTo("192.168.43.10", 0, 1);
        
        int time = 3;
        public Form1()
        {
            InitializeComponent();
        }
        private void getPlc1Data(TextBox txt1,TextBox txt2,TextBox txt3,ProgressBar pgbar,Label lbl1,Label lbl2)
        {
            BasicData.getData(plc1, txt1, txt2, txt3, pgbar,
                       lbl1, lbl2, result1, 8, 6, 10, 2, 0, treatmentwaterevac);
            
        }
        private void getPlc2Data(TextBox txt1, TextBox txt2, TextBox txt3, ProgressBar pgbar, Label lbl1, Label lbl2)
        {
            BasicData.getData(plc2, txt1, txt2, txt3,
                        pgbar, lbl1, lbl2, result, 16, 8, 12, 4, 0, treatmentwaterevac);
        }
        private void getPlc3Data(TextBox txt1, TextBox txt2, TextBox txt3, ProgressBar pgbar, Label lbl1, Label lbl2,TextBox txt4)
        {
            BasicData.getData(plc3, txt1, txt2, txt3,
                    pgbar, lbl1, lbl2, result3,
                    8, 8, 12, 4, 2, txt4);
        }
        private void setProgressBar(ProgressBar pgbar, int min, int max)
        {
            pgbar.Maximum = max;
            pgbar.Minimum = min;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
           
            
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time == 0)
            {
                getPlc2Data(totalvolume, currentlevel, currentvolume,
                        progressBar1, label14, label13);
                time = 3;
            }
        }

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == promotion1)
            {
                if (result1 == 0)
                {
                    
                    promotion1timer.Start();
                    getPlc1Data(totalvolume1, currentlevel1, currentvolum1, progresspromotion2,
                       label15, label16);
                    setProgressBar(progresspromotion2, 0, 100);
                    pumpflowmeter1.Text = "0";
                }
                else
                {
                    MessageBox.Show(plc1.ErrorText(result1), "Error", MessageBoxButtons.OK);
                }
            }
            else if (tabControl1.SelectedTab == promotion2)
            {
                if (result == 0)
                {
                    
                    promotion2timer.Start();
                    getPlc2Data(totalvolume, currentlevel, currentvolume,
                        progressBar1, label14, label13);
                    
                    setProgressBar(progressBar1, 0, 100);
                    pumpvolume.Text = "0";
                }
                else
                {
                    MessageBox.Show(plc2.ErrorText(result), "Error", MessageBoxButtons.OK);
                }
            }
            else if (tabControl1.SelectedTab == treatment)
            {

                if (result3 == 0)
                {
                    treatmenttimer.Start();
                    getPlc3Data(treatmentTotalText, treatmentCurrentlvl, treatmentCurrentText,
                    progressBar3, label26, label29, treatmentwaterevac);
                    setProgressBar(progressBar3, 0, 100);
                    treatmentFlowmeterText.Text = "0";
                }
                else
                {
                    MessageBox.Show(plc3.ErrorText(result3), "Error", MessageBoxButtons.OK);
                }
            }
            else if (tabControl1.SelectedTab == alldata)
            {
                BasicData.AnomalyDetection(plc1, plc2, plc3,listBox1);
                if (result1 == 0)
                {
                    
                    allPro1.Start();
                    getPlc1Data(textBox13, textBox10, textBox12, progressBar2,
                       label43, label71);
                    setProgressBar(progresspromotion2, 0, 100);
                    pumpflowmeter1.Text = "0";
                }
                else
                {
                    MessageBox.Show(plc1.ErrorText(result1), "Error", MessageBoxButtons.OK);
                }
                if (result == 0)
                {
                    
                    allPro2.Start();
                    getPlc2Data(textBox4, textBox1, textBox3,
                        progressBar5, label81, label44);

                    setProgressBar(progressBar1, 0, 100);
                    pumpvolume.Text = "0";
                }
                else
                {
                    MessageBox.Show(plc2.ErrorText(result), "Error", MessageBoxButtons.OK);
                }
                if (result3 == 0)
                {
                    alltreatment.Start();
                    getPlc3Data(textBox9, textBox6, textBox8,
                    progressBar4, label70, label60, textBox5);
                    setProgressBar(progressBar3, 0, 100);
                    treatmentFlowmeterText.Text = "0";
                }
                else
                {
                    MessageBox.Show(plc3.ErrorText(result3), "Error", MessageBoxButtons.OK);
                }
            }                 
        }
        private void promotion1timer_Tick(object sender, EventArgs e)
        {
            time--;
            if (time == 0)
            {
                time = 3;
                getPlc1Data(totalvolume1, currentlevel1, currentvolum1, progresspromotion2,
                       label15, label16);
            }
        }

        private void treatmenttimer_Tick(object sender, EventArgs e)
        {
            time--;
            if(time == 0)
            {
                time = 3;
                getPlc3Data(treatmentTotalText, treatmentCurrentlvl, treatmentCurrentText,
                    progressBar3, label26, label29, treatmentwaterevac);
            }
        }

        private void allPro1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time == 0)
            {
                time = 3;
                getPlc1Data(textBox13, textBox10, textBox12, progressBar2,
                       label43, label71);
            }
        }

        private void allPro2_Tick(object sender, EventArgs e)
        {
            time--;
            if (time == 0)
            {
                time = 3;

                getPlc2Data(textBox4, textBox1, textBox3,
                    progressBar5, label81, label44);
            }
        }

        private void alltreatment_Tick(object sender, EventArgs e)
        {
            time--;
            if (time == 0)
            {
                time = 3;
                getPlc3Data(textBox9, textBox6, textBox8,
                    progressBar4, label70, label60, textBox5);
            }
            
        }

        private void promotion1_Click(object sender, EventArgs e)
        {

        }
    }
}
