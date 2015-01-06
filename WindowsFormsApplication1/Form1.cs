using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int hall;
        int ip;
        int gate;       // 0 for i and 3 for f
        String adap;
        int setting = 1;
        String defPath;
        public Form1()
        {
            
            InitializeComponent();
            
            // Making labels transparent
            label1.Parent = pictureBox2;
            label2.Parent = pictureBox2;
            label3.Parent = pictureBox2;
            credits.Parent = pictureBox2;
            dhcpBu.Parent = pictureBox2;
            fortiBu.Parent = pictureBox2;
            ironBu.Parent = pictureBox2;
            pictureBox1.Parent = pictureBox2;
            pictureBox3.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            credits.BackColor = Color.Transparent;
            dhcpBu.BackColor = Color.Transparent;
            fortiBu.BackColor = Color.Transparent;
            ironBu.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;

            //Assigning images where required.
            pictureBox1.ImageLocation = @"C:\IITkNet\settings.svg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.ImageLocation = @"C:\IITkNet\help.svg";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;


            string[] defData = System.IO.File.ReadAllLines(@"C:\IITkNet\defs");
            defPath = defData[0];
            string[] lines = System.IO.File.ReadAllLines(@"C:\IITkNet\cur");
            hall = Convert.ToInt32(lines[0]);
            ip = Convert.ToInt32(lines[1]);
            gate = Convert.ToInt32(lines[2]);
            adap = lines[3];

            hallBox.Text = hall.ToString();
            ipBox.Text = ip.ToString();
            adapBox.Text = adap;

            if (gate == 0) {
                ironBu.Checked = true;
                fortiBu.Checked = false;
            }
            else if (gate == 3) {
                ironBu.Checked = false;
                fortiBu.Checked = true;
            }
            else if (gate == 1)
            {
                ironBu.Checked = false;
                fortiBu.Checked = false;
                dhcpBu.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hall = Convert.ToInt32(hallBox.Text);
            ip = Convert.ToInt32(ipBox.Text);
            adap = adapBox.Text;
            if (ironBu.Checked)
                gate = 0;
            else if (fortiBu.Checked)
                gate = 3;

            string[] constants = System.IO.File.ReadAllLines(@defPath + "hall" + hall);
            string iper = constants[0 + gate];
            string masker = constants[1 + gate];
            string gater = constants[2 + gate];

            statusBox.Text = "Your IP is " + ip + " and your hall is " + hall;
            String ipCmd = "netsh interface ip set address name=\"" + adap + "\" static " + iper + "." + ip + " " + masker + " " + gater;
            String dns1Cmd = "netsh interface ip set dns name=\"" + adap + "\" static 172.31.1.130";
            String dns2Cmd = "netsh interface ip add dns name=\"" + adap + "\" 172.31.1.1 index=2";
            String ipdhCmd = "netsh interface ip set address name=\"" + adap + "\" dhcp";
            String dnsdhCmd = "netsh interface ip set dnsservers name=\"" + adap + "\" source=dhcp";

            if (!dhcpBu.Checked)
            {
                statusBox.Text = "Setting IP";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C " + ipCmd;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                            statusBox.Text = "Setting DNS 1";
                            startInfo.Arguments = "/C" + dns1Cmd;
                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();

                            statusBox.Text = "Setting DNS 2";
                            startInfo.Arguments = "/C" + dns2Cmd;
                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();

                statusBox.Text = "All done ! :-)";
            }
            else
            {
                statusBox.Text = "Setting DHCP";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C " + ipdhCmd;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                statusBox.Text = "Setting DNS to DHCP";
                startInfo.Arguments = "/C" + dnsdhCmd;
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                statusBox.Text = "DHCP Done ! :-) ";
                //statusBox.Text = ipDH;
            }
            // Now updating the current info in the cur file for next startup
            if (dhcpBu.Checked)
            {
                string[] lines = { "2", "0", "1", adapBox.Text };
                System.IO.File.WriteAllLines(@"C:\IITkNet\cur", lines);
            }
            else
            {
                string[] lines = { hallBox.Text, ipBox.Text, gate == 0 ? "0" : "3", adapBox.Text };
                System.IO.File.WriteAllLines(@"C:\IITkNet\cur", lines);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setting = 1;
            string[] data = System.IO.File.ReadAllLines(@defPath + "pre1");
            hall = Convert.ToInt32(data[0]);
            ip = Convert.ToInt32(data[1]);
            gate = Convert.ToInt32(data[2]);
            adap = data[3];
            write.Text = "Write these settings to preset 1";
            hallBox.Text = hall.ToString();
            ipBox.Text = ip.ToString();
            adapBox.Text = adap;
            if (gate == 0)
            {
                ironBu.Checked = true;
                fortiBu.Checked = false;
            }
            else if (gate == 3)
            {
                ironBu.Checked = false;
                fortiBu.Checked = true;
            }
            else if (gate == 1)
            {
                ironBu.Checked = false;
                fortiBu.Checked = false;
                dhcpBu.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setting = 2;
            string[] data = System.IO.File.ReadAllLines(@defPath + "pre2");
            hall = Convert.ToInt32(data[0]);
            ip = Convert.ToInt32(data[1]);
            gate = Convert.ToInt32(data[2]);
            adap = data[3];
            write.Text = "Write these settings to preset 2";
            hallBox.Text = hall.ToString();
            ipBox.Text = ip.ToString();
            adapBox.Text = adap; 
            if (gate == 0)
            {
                ironBu.Checked = true;
                fortiBu.Checked = false;
            }
            else if (gate == 3)
            {
                ironBu.Checked = false;
                fortiBu.Checked = true;
            }
            else if (gate == 1)
            {
                ironBu.Checked = false;
                fortiBu.Checked = false;
                dhcpBu.Checked = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            setting = 3;
            string[] data = System.IO.File.ReadAllLines(@defPath + "pre3");
            hall = Convert.ToInt32(data[0]);
            ip = Convert.ToInt32(data[1]);
            gate = Convert.ToInt32(data[2]);
            adap = data[3];
            write.Text = "Write these settings to preset 3";
            hallBox.Text = hall.ToString();
            ipBox.Text = ip.ToString();
            adapBox.Text = adap;
            if (gate == 0)
            {
                ironBu.Checked = true;
                fortiBu.Checked = false;
            }
            else if (gate == 3)
            {
                ironBu.Checked = false;
                fortiBu.Checked = true;
            }
            else if (gate == 1)
            {
                ironBu.Checked = false;
                fortiBu.Checked = false;
                dhcpBu.Checked = true;
            }
        }

        private void write_Click_1(object sender, EventArgs e)
        {
            if (dhcpBu.Checked)
            {
                string[] lines = { "2", "0", "1", adapBox.Text };
                System.IO.File.WriteAllLines(@defPath + "pre" + setting, lines);
                statusBox.Text = "Wrote 0,0,1," + adapBox.Text + " to pre" + setting;
            }
            else
            {
                string[] lines = { hallBox.Text, ipBox.Text, gate == 0 ? "0" : "3", adapBox.Text };
                System.IO.File.WriteAllLines(@defPath + "pre" + setting, lines);
                statusBox.Text = "Wrote " + hallBox.Text + "," + ipBox.Text + "," + gate + "," + adapBox.Text + "  to pre" + setting;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.Show();
        }

        private void offer_Click(object sender, EventArgs e)
        {
            statusBox.Text = "Turning off hotspot";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan stop hostednetwork";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            statusBox.Text = "Hotspot off.";
        }

        private void oner_Click(object sender, EventArgs e)
        {
            statusBox.Text = "Turning on hotspot";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "netsh wlan start hostednetwork";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            statusBox.Text = "Hotspot on.";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
       }

        private void credits_Click(object sender, EventArgs e)
        {
            Form frm = new Form2();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Show();
        }
    }
}