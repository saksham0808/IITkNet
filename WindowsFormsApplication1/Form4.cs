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
    public partial class Form4 : Form
    {
        List<string> _items1 = new List<string>();
        List<string> _items2 = new List<string>();
        List<string> _items3 = new List<string>();
        public Form4()
        {
            InitializeComponent();
            string[] data1 = System.IO.File.ReadAllLines(@"C:\IITkNet\pre1");
            _items1.Add(data1[0]);
            _items1.Add(data1[1]);
            _items1.Add(data1[2]);
            _items1.Add(data1[3]);

            string[] data2 = System.IO.File.ReadAllLines(@"C:\IITkNet\pre2");
            _items2.Add(data2[0]);
            _items2.Add(data2[1]);
            _items2.Add(data2[2]);
            _items2.Add(data2[3]);

            string[] data3 = System.IO.File.ReadAllLines(@"C:\IITkNet\pre3");
            _items3.Add(data3[0]);
            _items3.Add(data3[1]);
            _items3.Add(data3[2]);
            _items3.Add(data3[3]);

            listBox1.DataSource = _items1;
            listBox2.DataSource = _items2;
            listBox3.DataSource = _items3;
            
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
