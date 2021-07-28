using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRA
{
    public partial class Bao_cao_chi_so : Form
    {
        public Bao_cao_chi_so(string value)
        {
            InitializeComponent();
            this.Value = value;
        }
        public string Value { set; get; }
        private void Bao_cao_chi_so_Load(object sender, EventArgs e)
        {
            label1.Text = Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Chi_so_dinh_gia dg = new Chi_so_dinh_gia(label1.Text);
            dg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chi_so_sinh_loi sl = new Chi_so_sinh_loi(label1.Text);
            sl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chi_so_tang_truong tt = new Chi_so_tang_truong(label1.Text);
            tt.Show();
        }


    }
}
