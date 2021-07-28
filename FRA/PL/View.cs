using FRA.PL.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FRA.DTO;
using FRA.DAL;
using FRA.BLL;
namespace FRA.PL
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();

        }
        private void View_Load(object sender, EventArgs e)
        {
            List<Company> companies = new ViewBUS().GetAll();
            dataGridView1.DataSource = companies;
            ShowData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bao_cao_chi_so dg = new Bao_cao_chi_so(textBox2.Text);
            dg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //AddNew addNew = new AddNew(textBox1.Text);
            //addNew.Show();
            //ReportTable1 reportTable1 = new ReportTable1(textBox1.Text);
            //reportTable1.Show();
            Add_Reports add_Reports = new Add_Reports(textBox1.Text);
            add_Reports.Show();
        }

        private void ShowData()
        {
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "CompanyID", true, DataSourceUpdateMode.Never));
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "CompanyName", true, DataSourceUpdateMode.Never));
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Address", true, DataSourceUpdateMode.Never));
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Phone", true, DataSourceUpdateMode.Never));
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Email", true, DataSourceUpdateMode.Never));
            textBox6.DataBindings.Clear();
            textBox6.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "MainJob", true, DataSourceUpdateMode.Never));
            textBox7.DataBindings.Clear();
            textBox7.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "CEO", true, DataSourceUpdateMode.Never));
            textBox8.DataBindings.Clear();
            textBox8.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "StockPrice", true, DataSourceUpdateMode.Never));
            textBox9.DataBindings.Clear();
            textBox9.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Amount", true, DataSourceUpdateMode.Never));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            List<Company> companies = new ViewBUS().SearchByKeyword(keyword);
            dataGridView1.DataSource = companies;
            ShowData();
        }
    }
}
