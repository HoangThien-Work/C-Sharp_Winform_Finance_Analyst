using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FRA.BLL;

namespace FRA
{
    public partial class Chi_so_tang_truong : Form
    {
        TextBox txt;
        Panel[] panels;
        List<int> year = null;
        List<string> type = null;
        public string ID { set; get; }
        public Chi_so_tang_truong(string value)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            panels = new Panel[] { pnlTxT1, pnlTxT2, pnlTxT3, pnlTxT4, pnlTxT5, pnlTxT6, pnlTxT7, pnlTxT8, pnlTxT9 };
            type = new List<string>();
            type.Add("Quý");
            type.Add("Năm");
            cbType.DataSource = type;
            cbType.SelectedIndex = 0;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;

            //format combo box year
            year = Enumerable.Range(1999, DateTime.Now.Year - 1999 + 1).ToList();
            cbYear.DataSource = year;
            int yearDefaul = year.Count;
            cbYear.SelectedIndex = yearDefaul - 2;
            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ID = new Chi_so_tang_truongBUS().getCompanyID(value);
        }
        private void Chi_so_tang_truong_Load(object sender, EventArgs e)
        {
            labelName.Text = ID;
            ChangeLabel();
            for (int i = 0; i < 9; i++)
            {
                CreateTextbox(i);
            }
            changeResultSalesGrowthRate();
            changeResultGrossProfitGrowth();
            changeResultPreTaxProfitGrowth();
            changeResultAfterTaxProfitGrowth();
            changeResultTotalAssetGrowth();
            changeResultLongTermDebtGrouwth();
            changeResultLiabilitiesGrowth();
            changeResultEquityGrowth();
            changeResultCharterCapitalGrowth();
        }
        public void CreateTextbox(int j)
        {
            TextBox oldtxt = new TextBox() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i <= 4; i++)
            {
                txt = new TextBox()
                {
                    Width = 60,
                    Location = new Point(oldtxt.Location.X + oldtxt.Width + 20, oldtxt.Location.Y),
                };

                txt.Font = new Font("Microsoft Sans Serif", 14);
                txt.Enabled = false;
                panels[j].Controls.Add(txt);
                oldtxt = txt;
            }
        }

        public void changeResultSalesGrowthRate()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[0].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().SalesGrowthRate(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[0].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().SalesGrowthRateByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultGrossProfitGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[1].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().GrossProfitGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[1].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().GrossProfitGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultPreTaxProfitGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[2].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().PreTaxProfitGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[2].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().PreTaxProfitGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultAfterTaxProfitGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[3].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().AfterTaxProfitGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[3].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().AfterTaxProfitGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultTotalAssetGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[4].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().TotalAssetGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[4].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().TotalAssetGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultLongTermDebtGrouwth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[5].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().LongTermDebtGrouwth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[5].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().LongTermDebtGrouwthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultLiabilitiesGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[6].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().LiabilitiesGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[6].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().LiabilitiesGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultEquityGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[7].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().EquityGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[7].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().EquityGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }

        public void changeResultCharterCapitalGrowth()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    if (cbType.SelectedIndex == 0)
                    {
                        int i = 0;
                        foreach (Control ctrl in panels[8].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().CharterCapitalGrowth(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[8].Controls)
                        {
                            ctrl.Text = new Chi_so_tang_truongBUS().CharterCapitalGrowthByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }
        public void ChangeLabel()
        {
            if (cbType.SelectedIndex == 0)
            {
                lbHeader1.Text = "Quý 1";
                lbHeader2.Text = "Quý 2";
                lbHeader3.Text = "Quý 3";
                lbHeader4.Text = "Quý 4";
            }
            else
            {
                lbHeader1.Text = (Convert.ToInt32(cbYear.Text) - 3).ToString();
                lbHeader2.Text = (Convert.ToInt32(cbYear.Text) - 2).ToString();
                lbHeader3.Text = (Convert.ToInt32(cbYear.Text) - 1).ToString();
                lbHeader4.Text = cbYear.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            changeResultSalesGrowthRate();
            changeResultGrossProfitGrowth();
            changeResultPreTaxProfitGrowth();
            changeResultAfterTaxProfitGrowth();
            changeResultTotalAssetGrowth();
            changeResultLongTermDebtGrouwth();
            changeResultLiabilitiesGrowth();
            changeResultEquityGrowth();
            changeResultCharterCapitalGrowth();
            ChangeLabel();           
        }
    }
}
