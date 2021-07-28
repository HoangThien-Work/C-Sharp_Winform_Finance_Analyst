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
using FRA.DTO;

namespace FRA
{
    public partial class Chi_so_dinh_gia : Form
    {
        
        TextBox txt;
        Panel[] panels;
        List<int> year = null;
        List<string> type = null;
        public string ID { set; get; }
        public Chi_so_dinh_gia(string value)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            panels = new Panel[] { pnlTxT1, pnlTxT2, pnlTxT3, pnlTxT4, pnlTxT5, pnlTxT6 };
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
            cbYear.SelectedIndex = yearDefaul-2;
            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ID = new Chi_so_dinh_giaBUS().getCompanyID(value);         
        }

        private void Chi_so_dinh_gia_Load(object sender, EventArgs e)
        {
            labelName.Text = ID;
            ChangeLabel();
            for(int i=0;i<6;i++)
            {
                CreateTextbox(i);
            }
            changeResultEPS();
            changeResultBVPS();
            changeResultPriceToEarningratio();
            changePricetoBookRatio();
            changeResultPricetoSalesRatio();
            changeResultDY();
            ChangeLabel();            
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
                //txt.Text = new Chi_so_dinh_giaBUS().EPSByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                //txt.Text = Result;
                panels[j].Controls.Add(txt);
                oldtxt = txt;
            }
        }        
        public void changeResultEPS()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    int i = 0;
                    foreach (Control ctrl in panels[0].Controls)
                    {
                        ctrl.Text = new Chi_so_dinh_giaBUS().EPSByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                        i++;
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
        }       

        public void changeResultBVPS()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    int i = 0;
                    foreach (Control ctrl in panels[1].Controls)
                    {
                        ctrl.Text = new Chi_so_dinh_giaBUS().BVPSByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                        i++;
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
            
        }
        
        public void changeResultPriceToEarningratio()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    int i = 0;
                    foreach (Control ctrl in panels[2].Controls)
                    {
                        ctrl.Text = new Chi_so_dinh_giaBUS().PriceToEarningratioByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                        i++;
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
            
        }
        
        public void changePricetoBookRatio()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    int i = 0;
                    foreach (Control ctrl in panels[3].Controls)
                    {
                        ctrl.Text = new Chi_so_dinh_giaBUS().PricetoBookRatioByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                        i++;
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
            
        }
        
        public void changeResultPricetoSalesRatio()
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
                            ctrl.Text = new Chi_so_dinh_giaBUS().PricetoSalesRatioByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                            i++;
                        }
                    }
                    else
                    {
                        int i = 3;
                        foreach (Control ctrl in panels[4].Controls)
                        {
                            ctrl.Text = new Chi_so_dinh_giaBUS().PricetoSalesRatioByYear(ID, Convert.ToInt32(cbYear.Text) - i).ToString();
                            i--;
                        }
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
                        
        }
        
        public void changeResultDY()
        {
            //khởi tạo thread
            new Thread(
                () =>
                {
                    int i = 0;
                    foreach (Control ctrl in panels[5].Controls)
                    {
                        ctrl.Text = new Chi_so_dinh_giaBUS().DYByQuarter(ID, i + 1, Convert.ToInt32(cbYear.Text)).ToString();
                        i++;
                    }
                }
                )
            //khi tắt chương trình, thread sẽ tắt theo
            { IsBackground = true }.Start();
            
        }
        public void ChangeLabel()
        {
            if(cbType.SelectedIndex==0)
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
                lbHeader3.Text = (Convert.ToInt32(cbYear.Text) -1).ToString();
                lbHeader4.Text = cbYear.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            changeResultEPS();
            changeResultBVPS();
            changeResultPriceToEarningratio();
            changePricetoBookRatio();
            changeResultPricetoSalesRatio();
            changeResultDY();
            ChangeLabel();
        }

    }
}
