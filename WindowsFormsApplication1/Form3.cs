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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            string[] defData = System.IO.File.ReadAllLines(@"C:\IITkNet\hotspotdata");
            ssid.Text = defData[0];
            pswd.Text = defData[1];
        }

        private void update_Click(object sender, EventArgs e)
        {
            status.Text = "Updating WiFi hotspot settings.";
            String htsptCmd = "netsh wlan set hostednetwork mode=\"allow\" ssid=" + ssid.Text + " key=" + pswd.Text;

            string[] lines = { ssid.Text, pswd.Text };
            System.IO.File.WriteAllLines(@"C:\IITkNet\hotspotdata", lines);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + htsptCmd;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            status.Text = "WiFi hotspot settings updated.";
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.update.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
