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
using FRA.BLL;

namespace FRA.PL.Input
{
    public partial class Add_Reports : Form
    {
        //get value Com ID from Home Forms.
        public string Value { set; get; }
        public Add_Reports(string value)
        {
            InitializeComponent();
            this.Value = value;
        }


        //only accept number in textbox input year
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtYear.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtYear.Text = txtYear.Text.Remove(txtYear.Text.Length - 1);
            }
        }

        //only accept number in textbox input Quater
        private void txtQuater_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuater.Text, "[^1-4]"))
            {
                MessageBox.Show("Please enter only numbers from 1 - 4");
                txtQuater.Text = txtQuater.Text.Remove(txtQuater.Text.Length - 1);
            }
        }



        private void Add_Reports_Load(object sender, EventArgs e)
        {
            //load Com ID for 3 report tab
            txtIdComCDKT.Text = Value;
            txtIdComKQHDKD.Text = Value;
            txtIdComLCTT.Text = Value;


            // TODO: This line of code loads data into the 'fraDataSet1.LCTT' table. You can move, or remove it, as needed.
            this.lCTTTableAdapter.Fill(this.fraDataSet1.LCTT);
            // TODO: This line of code loads data into the 'fraDataSet1.KQHDKD' table. You can move, or remove it, as needed.
            this.kQHDKDTableAdapter.Fill(this.fraDataSet1.KQHDKD);
            // TODO: This line of code loads data into the 'fraDataSet1.CDKT' table. You can move, or remove it, as needed.
            this.cDKTTableAdapter.Fill(this.fraDataSet1.CDKT);

        }

        private void btnSubmitRP_CDKT_Click(object sender, EventArgs e)
        {
            try
            {
                //1
                try
                {
                    Category newcategoryCKKD = new Category()
                    {

                        //CompanyID = txtIdCom.Text.Trim(),
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "CKKD",
                        CategoryName = "Chứng khoán kinh doanh",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[0].Cells[2].Value.ToString()),
                        //Price = int.Parse(txttienmat.Text.Trim()),
                        //Price = int.Parse(dataGridViewCDKT.Rows[1].Cells[3].Value.ToString()),
                        //Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        //Price = int.Parse("1"),
                        ReportID = int.Parse("1"),
                        TypeID="TS",
                    };
                    bool addComplete_CKKD = new CategoryBus().AddCate(newcategoryCKKD);
                }
                catch
                {
                    MessageBox.Show("add fail CKKD");
                }

                //2
                try
                {
                    Category newcategoryCPPTNG = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "CPPTNG",
                        CategoryName = "Chi phí phải trả ngắn hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[1].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_CPPTNG = new CategoryBus().AddCate(newcategoryCPPTNG);
                }
                catch
                {
                    MessageBox.Show("add fail CPPTNG");
                }

                //3
                try
                {
                    Category newcategoryCPQ = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "CPQ",
                        CategoryName = "Cổ phiếu quỹ",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[2].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "V",
                    };
                    bool addComplete_CPQ = new CategoryBus().AddCate(newcategoryCPQ);
                }
                catch
                {
                    MessageBox.Show("add fail CPQ");
                }

                //4
                try
                {
                    Category newcategoryCPTTDH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "CPTTDH",
                        CategoryName = "Chi phí trả trước dài hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[3].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_CPTTDH = new CategoryBus().AddCate(newcategoryCPTTDH);
                }
                catch
                {
                    MessageBox.Show("add fail CPTTDH");
                }

                //5
                try
                {
                    Category newcategoryCPXD = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "CPXD",
                        CategoryName = "Chi phí xây dựng cơ bản dở dang",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[4].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_CPXD = new CategoryBus().AddCate(newcategoryCPXD);
                }
                catch
                {
                    MessageBox.Show("add fail CPXD");
                }

                //6
                try
                {
                    Category newcategoryDPDTTCDH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DPDTTCDH",
                        CategoryName = "Dự phòng đầu tư tài chính dài hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[5].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_DPDTTCDH = new CategoryBus().AddCate(newcategoryDPDTTCDH);
                }
                catch
                {
                    MessageBox.Show("add fail DPDTTCDH");
                }

                //7
                try
                {
                    Category newcategoryDPGGCK = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DPGGCK",
                        CategoryName = "Dự phòng giảm giá chứng khoán kinh doanh",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[6].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_DPGGCK = new CategoryBus().AddCate(newcategoryDPGGCK);
                }
                catch
                {
                    MessageBox.Show("add fail DPGGCK");
                }

                //8
                try
                {
                    Category newcategoryDPGGHTK = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DPGGHTK",
                        CategoryName = "Dự phòng giảm giá hàng tồn kho",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[7].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_DPGGHTK = new CategoryBus().AddCate(newcategoryDPGGHTK);
                }
                catch
                {
                    MessageBox.Show("add fail Dự phòng giảm giá hàng tồn kho");
                }

                //9
                try
                {
                    Category newcategoryDPPTDH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DPPTDH",
                        CategoryName = "Dự phòng phải trả dài hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[8].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_DPPTDH = new CategoryBus().AddCate(newcategoryDPPTDH);
                }
                catch
                {
                    MessageBox.Show("add fail Dự phòng phải trả dài hạn");
                }

                //10
                try
                {
                    Category newcategoryDPTNHKD = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DPTNHKD",
                        CategoryName = "Dự phòng phải thu ngắn hạn khó đòi",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[9].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID="TS",
                    };
                    bool addComplete_DPTNHKD = new CategoryBus().AddCate(newcategoryDPTNHKD);
                }
                catch
                {
                    MessageBox.Show("add fail Dự phòng phải thu ngắn hạn khó đòi");
                }

                //11
                try
                {
                    Category newcategoryDTGV = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DTGV",
                        CategoryName = "Đầu tư góp vốn vào đơn vị khác",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[10].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_DTGV = new CategoryBus().AddCate(newcategoryDTGV);
                }
                catch
                {
                    MessageBox.Show(" add fail Đầu tư góp vốn vào đơn vị khác");
                }

                //12
                try
                {
                    Category newcategoryDTNGDNDH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DTNGDNDH",
                        CategoryName = "Đầu tư nắm giữ đến ngày đáo hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[11].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_DTNGDNDH = new CategoryBus().AddCate(newcategoryDTNGDNDH);
                }
                catch
                {
                    MessageBox.Show(" add fail Đầu tư nắm giữ đến ngày đáo hạn");
                }

                //13
                try
                {
                    Category newcategoryDTVCT = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "DTVCT",
                        CategoryName = "Đầu tư vào công ty liên doanh, liên kết",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[12].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_DTVCT = new CategoryBus().AddCate(newcategoryDTVCT);
                }
                catch
                {
                    MessageBox.Show(" add fail Đầu tư vào công ty liên doanh, liên kết");
                }

                //14
                try
                {
                    Category newcategoryHTK = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "HTK",
                        CategoryName = "Hàng tồn kho",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[13].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_HTK = new CategoryBus().AddCate(newcategoryHTK);
                }
                catch
                {
                    MessageBox.Show(" add fail Hàng tồn kho");
                }

                //15
                try
                {
                    Category newcategoryLNSTCPP = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "LNSTCPP",
                        CategoryName = "Lợi nhuận sau thuế chưa phân phối",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[14].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_LNSTCPP = new CategoryBus().AddCate(newcategoryLNSTCPP);
                }
                catch
                {
                    MessageBox.Show(" add fail Lợi nhuận sau thuế chưa phân phối");
                }

                //16
                try
                {
                    Category newcategoryNMTTNH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "NMTTNH",
                        CategoryName = "Người mua trả tiền trước ngắn hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[15].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_NMTTNH = new CategoryBus().AddCate(newcategoryNMTTNH);
                }
                catch
                {
                    MessageBox.Show(" add fail Người mua trả tiền trước ngắn hạn");
                }

                //17
                try
                {
                    Category newcategoryNPTNBNH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "NPTNBNH",
                        CategoryName = "Nợ phải trả người bán ngắn hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[16].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_NPTNBNH = new CategoryBus().AddCate(newcategoryNPTNBNH);
                }
                catch
                {
                    MessageBox.Show(" add fail Nợ phải trả người bán ngắn hạn");
                }

                //18
                try
                {
                    Category newcategoryPTNHK = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "PTNHK",
                        CategoryName = "Phải trả ngắn hạn khác",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[17].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_PTNHK = new CategoryBus().AddCate(newcategoryPTNHK);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải trả ngắn hạn khác");
                }

                //19
                try
                {
                    Category newcategoryQDTPT = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "QDTPT",
                        CategoryName = "Quỹ đầu tư phát triển",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[18].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_QDTPT = new CategoryBus().AddCate(newcategoryQDTPT);
                }
                catch
                {
                    MessageBox.Show(" add failQuỹ đầu tư phát triển");
                }

                //20
                try
                {
                    Category newcategoryQKT = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "QKT",
                        CategoryName = "Quỹ khen thưởng, phúc lợi",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[19].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_QKT = new CategoryBus().AddCate(newcategoryQKT);
                }
                catch
                {
                    MessageBox.Show(" add fail Quỹ khen thưởng, phúc lợi");
                }

                //21
                try
                {
                    Category newcategoryT = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "T",
                        CategoryName = "Tiền mặt",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[20].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_T = new CategoryBus().AddCate(newcategoryT);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền mặt");
                }

                //22
                try
                {
                    Category newcategoryTDHK = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TDHK",
                        CategoryName = "Phải thu dài hạn khác",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[21].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TDHK = new CategoryBus().AddCate(newcategoryTDHK);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải thu dài hạn khác");
                }

                //23
                try
                {
                    Category newcategoryTDT = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TDT",
                        CategoryName = "Các khoản tương đương tiền",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[22].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TDT = new CategoryBus().AddCate(newcategoryTDT);
                }
                catch
                {
                    MessageBox.Show(" add fail Các khoản tương đương tiền");
                }

                //24
                try
                {
                    Category newcategoryTDVCP = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TDVCP",
                        CategoryName = "Thặng dư vốn cổ phẩn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[23].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "V",
                    };
                    bool addComplete_TDVCP = new CategoryBus().AddCate(newcategoryTDVCP);
                }
                catch
                {
                    MessageBox.Show(" add fail Thặng dư vốn cổ phẩn");
                }

                //25
                try
                {
                    Category newcategoryTGTGT = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TGTGT",
                        CategoryName = "Thuế GTGT được khấu trừ",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[24].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TGTGT = new CategoryBus().AddCate(newcategoryTGTGT);
                }
                catch
                {
                    MessageBox.Show(" add fail Thuế GTGT được khấu trừ");
                }

                //26
                try
                {
                    Category newcategoryTNHK = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TNHK",
                        CategoryName = "Phải thu ngắn hạn khác",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[25].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TNHKT = new CategoryBus().AddCate(newcategoryTNHK);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải thu ngắn hạn khác");
                }

                //27
                try
                {
                    Category newcategoryTNHKH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TNHKH",
                        CategoryName = "Phải thu ngắn hạn của khách hàng",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[26].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TNHKH = new CategoryBus().AddCate(newcategoryTNHKH);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải thu ngắn hạn của khách hàng");
                }

                //28
                try
                {
                    Category newcategoryTNLD = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TNLD",
                        CategoryName = "Phải trả người lao động",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[27].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_TNLD = new CategoryBus().AddCate(newcategoryTNLD);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải trả người lao động");
                }

                //29
                try
                {
                    Category newcategoryTSHH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TSHH",
                        CategoryName = "Tài sản cố định hữu hình",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[28].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TSHH = new CategoryBus().AddCate(newcategoryTSHH);
                }
                catch
                {
                    MessageBox.Show(" add fail Tài sản cố định hữu hình");
                }

                //30
                try
                {
                    Category newcategoryTSVH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TSVH ",
                        CategoryName = "Tài sản cố định vô hình",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[29].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TSVH = new CategoryBus().AddCate(newcategoryTSVH);
                }
                catch
                {
                    MessageBox.Show(" add fail Tài sản cố định vô hình");
                }

                //31
                try
                {
                    Category newcategoryTTNBNH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TTNBNH ",
                        CategoryName = "Trả trước cho người bán ngắn hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[30].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TTNBNH = new CategoryBus().AddCate(newcategoryTTNBNH);
                }
                catch
                {
                    MessageBox.Show(" add fail Trả trước cho người bán ngắn hạn");
                }

                //32
                try
                {
                    Category newcategoryTVCKNNC = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TVCKNNC ",
                        CategoryName = "Thuế và các khoản phải nộp Nhà nước",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[31].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "N",
                    };
                    bool addComplete_TVCKNNC = new CategoryBus().AddCate(newcategoryTVCKNNC);
                }
                catch
                {
                    MessageBox.Show(" add fail Thuế và các khoản phải nộp Nhà nước");
                }

                //33
                try
                {
                    Category newcategoryTVCVDH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TVCVDH ",
                        CategoryName = "Phải thu về cho vay dài hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[32].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TVCVDH = new CategoryBus().AddCate(newcategoryTVCVDH);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải thu về cho vay dài hạn");
                }

                //34
                try
                {
                    Category newcategoryTVKTNC = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "TVKTNC ",
                        CategoryName = "Thuế và các khoản khác phải thu của Nhà nước",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[33].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID = "TS",
                    };
                    bool addComplete_TVKTNC = new CategoryBus().AddCate(newcategoryTVKTNC);
                }
                catch
                {
                    MessageBox.Show(" add fail Thuế và các khoản khác phải thu của Nhà nước");
                }

                //35
                try
                {
                    Category newcategoryVDTCSH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "VDTCSH ",
                        CategoryName = "Vốn đầu tư của chủ sở hữu",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[34].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID="V",
                    };
                    bool addComplete_VDTCSH = new CategoryBus().AddCate(newcategoryVDTCSH);
                }
                catch
                {
                    MessageBox.Show(" add fail Vốn đầu tư của chủ sở hữu");
                }


                //36
                try
                {
                    Category newcategoryVNH = new Category()
                    {
                        CompanyID = txtIdComCDKT.Text.Trim(),
                        CategoryID = "VNH ",
                        CategoryName = "Phải thu về cho vay ngắn hạn",
                        Quarter = int.Parse(txtQuater.Text.Trim()),
                        Year = int.Parse(txtYear.Text.Trim()),
                        Price = int.Parse(dataGridViewCDKT.Rows[35].Cells[2].Value.ToString()),
                        ReportID = int.Parse("1"),
                        TypeID="TS",
                    };
                    bool addComplete_VNH = new CategoryBus().AddCate(newcategoryVNH);
                }
                catch
                {
                    MessageBox.Show(" add fail Phải thu về cho vay ngắn hạn");
                }

                // add all done
                MessageBox.Show("Add Complete CDKT !!!");
            }
            catch
            {
                MessageBox.Show("Unknow Erro CDKT !!!");
            }

        }

        
        private void btnSubmitRP_KQHDKD_Click(object sender, EventArgs e)
        {
            try
            {
                //1
                try
                {
                    Category newcategoryCPBH = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "CPBH",
                        CategoryName = "Chi phí bán hàng",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[0].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_CPBH = new CategoryBus().AddCate(newcategoryCPBH);
                }
                catch
                {
                    MessageBox.Show(" add fail Chi phí bán hàng");
                }

                //2
                try
                {
                    Category newcategoryCPQLDN = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "CPQLDN",
                        CategoryName = "Chi phí quản lý doanh nghiệp",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[1].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_CPQLDN = new CategoryBus().AddCate(newcategoryCPQLDN);
                }
                catch
                {
                    MessageBox.Show(" add fail Chi phí quản lý doanh nghiệp");
                }

                //3
                try
                {
                    Category newcategoryCPTC = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "CPTC",
                        CategoryName = "Chi phí tài chính",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[2].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_CPTC = new CategoryBus().AddCate(newcategoryCPTC);
                }
                catch
                {
                    MessageBox.Show(" add fail Chi phí tài chính");
                }

                //4
                try
                {
                    Category newcategoryCPTTNDNHH = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "CPTTNDNHH",
                        CategoryName = "Chi phí thuế TNDN hiện hành",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[3].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_CPTTNDNHH = new CategoryBus().AddCate(newcategoryCPTTNDNHH);
                }
                catch
                {
                    MessageBox.Show(" add fail Chi phí thuế TNDN hiện hành");
                }

                //5
                try
                {
                    Category newcategoryDTBHVCCDV = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "DTBHVCCDV",
                        CategoryName = "Doanh thu bán hàng và cung cấp dịch vụ",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[4].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_DTBHVCCDV = new CategoryBus().AddCate(newcategoryDTBHVCCDV);
                }
                catch
                {
                    MessageBox.Show(" add fail Doanh thu bán hàng và cung cấp dịch vụ");
                }

                //6
                try
                {
                    Category newcategoryDTHDTC = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "DTHDTC",
                        CategoryName = "Doanh thu hoạt động tài chính",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[5].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_DTHDTC = new CategoryBus().AddCate(newcategoryDTHDTC);
                }
                catch
                {
                    MessageBox.Show(" add fail Doanh thu hoạt động tài chính");
                }

                //7
                try
                {
                    Category newcategoryDTTVBHVCCDV = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "DTTVBHVCCDV",
                        CategoryName = "Doanh thu thuần về bán hàng và cung cấp dịch vụ",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[6].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_DTTVBHVCCDV = new CategoryBus().AddCate(newcategoryDTTVBHVCCDV);
                }
                catch
                {
                    MessageBox.Show(" add fail Doanh thu thuần về bán hàng và cung cấp dịch vụ");
                }

                //8
                try
                {
                    Category newcategoryGVHB = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "GVHB",
                        CategoryName = "Giá vốn hàng bán",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[7].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_GVHB = new CategoryBus().AddCate(newcategoryGVHB);
                }
                catch
                {
                    MessageBox.Show(" add fail Giá vốn hàng bán");
                }

                //9
                try
                {
                    Category newcategoryLCBTCp = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "LCBTCp",
                        CategoryName = "Lãi cơ bản trên cổ phiếu",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[8].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_LCBTCp = new CategoryBus().AddCate(newcategoryLCBTCp);
                }
                catch
                {
                    MessageBox.Show(" add fail Lãi cơ bản trên cổ phiếu");
                }

                //10
                try
                {
                    Category newcategoryLNGVBHVCCDV = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "LNGVBHVCCDV",
                        CategoryName = "Lợi nhuận gộp về bán hàng và cung cấp dịch vụ",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[9].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_LNGVBHVCCDV = new CategoryBus().AddCate(newcategoryLNGVBHVCCDV);
                }
                catch
                {
                    MessageBox.Show(" add fail Lợi nhuận gộp về bán hàng và cung cấp dịch vụ");
                }

                //11
                try
                {
                    Category newcategoryLNK = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "LNK",
                        CategoryName = "Lợi nhuận khác",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[10].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_LNK = new CategoryBus().AddCate(newcategoryLNK);
                }
                catch
                {
                    MessageBox.Show(" add fail Lợi nhuận khác");
                }

                //12
                try
                {
                    Category newcategoryLNSTTNDN = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "LNSTTNDN",
                        CategoryName = "Lợi nhuận sau thuế thu thập doanh nghiệp",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[11].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_LNSTTNDN = new CategoryBus().AddCate(newcategoryLNSTTNDN);
                }
                catch
                {
                    MessageBox.Show(" add fail Lợi nhuận sau thuế thu thập doanh nghiệp");
                }

                //13
                try
                {
                    Category newcategoryLNTTHDKD = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "LNTTHDKD",
                        CategoryName = "Lợi nhuận thuần từ hoạt động kinh doanh",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[12].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_LNTTHDKD = new CategoryBus().AddCate(newcategoryLNTTHDKD);
                }
                catch
                {
                    MessageBox.Show(" add fail Lợi nhuận thuần từ hoạt động kinh doanh");
                }

                //14
                try
                {
                    Category newcategoryLSGTCP = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "LSGTCP",
                        CategoryName = "Lãi suy giảm trên cổ phiếu",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[13].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_LSGTCP = new CategoryBus().AddCate(newcategoryLSGTCP);
                }
                catch
                {
                    MessageBox.Show(" add fail Lãi suy giảm trên cổ phiếu");
                }

                //15
                try
                {
                    Category newcategoryTLNKTTT = new Category()
                    {
                        CompanyID = txtIdComKQHDKD.Text.Trim(),
                        CategoryID = "TLNKTTT",
                        CategoryName = "Tổng lợi nhuận kế toán trước thuế",
                        Quarter = int.Parse(txtQuaterKQHDKD.Text.Trim()),
                        Year = int.Parse(txtYearKQHDKD.Text.Trim()),
                        Price = int.Parse(dataGridViewKQHDKD.Rows[14].Cells[2].Value.ToString()),
                        ReportID = int.Parse("2"),
                    };
                    bool addComplete_TLNKTTT = new CategoryBus().AddCate(newcategoryTLNKTTT);
                }
                catch
                {
                    MessageBox.Show(" add fail Tổng lợi nhuận kế toán trước thuế");
                }

                // add all done
                MessageBox.Show("Add Complete KQHDKD !!!");
            }
            catch
            {
                MessageBox.Show("unknow Erro Report KQHDKD !!!");
            }
        }

        private void btnSubmitRP_LCTT_Click(object sender, EventArgs e)
        {
            try
            {
                //1
                try
                {
                    Category newcategoryKH = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "KH",
                        CategoryName = "Khấu hao TSCĐ và BĐSĐT",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[0].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_KH = new CategoryBus().AddCate(newcategoryKH);
                }
                catch
                {
                    MessageBox.Show(" add fail Khấu hao TSCĐ và BĐSĐT");
                }

                //2
                try
                {
                    Category newcategoryCKDP = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "CKDP",
                        CategoryName = "Các khoản dự phòng",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[1].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_CKDP = new CategoryBus().AddCate(newcategoryCKDP);
                }
                catch
                {
                    MessageBox.Show(" add fail Các khoản dự phòng");
                }

                //3
                try
                {
                    Category newcategoryLLHDDT = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "LLHDDT",
                        CategoryName = "Lãi, lỗ từ hoạt động đầu tư",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[2].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_LLHDDT = new CategoryBus().AddCate(newcategoryLLHDDT);
                }
                catch
                {
                    MessageBox.Show(" add fail - Lãi, lỗ từ hoạt động đầu tư");
                }

                //4
                try
                {
                    Category newcategoryDCKK = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "DCKK",
                        CategoryName = "Điều chỉnh cho các khoản khác",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[3].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_DCKK = new CategoryBus().AddCate(newcategoryDCKK);
                }
                catch
                {
                    MessageBox.Show(" add fail Điều chỉnh cho các khoản khác");
                }

                //5
                try
                {
                    Category newcategoryTGCKPT = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TGCKPT",
                        CategoryName = "Tăng, giảm các khoản phải thu",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[4].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TGCKPT = new CategoryBus().AddCate(newcategoryTGCKPT);
                }
                catch
                {
                    MessageBox.Show(" add fail Tăng, giảm các khoản phải thu");
                }

                //6
                try
                {
                    Category newcategoryTGHTK = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TGHTK",
                        CategoryName = "Tăng, giảm hàng tồn kho",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[5].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TGHTK = new CategoryBus().AddCate(newcategoryTGHTK);
                }
                catch
                {
                    MessageBox.Show(" add fail Tăng, giảm hàng tồn kho");
                }

                //7
                try
                {
                    Category newcategoryTGCKPt = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TGCKPt",
                        CategoryName = "Tăng, giảm các khoản phải trả",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[6].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TGCKPt = new CategoryBus().AddCate(newcategoryTGCKPt);
                }
                catch
                {
                    MessageBox.Show(" add fail Tăng, giảm các khoản phải trả");
                }

                //8
                try
                {
                    Category newcategoryTGCPTT = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TGCPTT",
                        CategoryName = "Tăng, giảm chi phí trả trước",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[7].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TGCPTT = new CategoryBus().AddCate(newcategoryTGCPTT);
                }
                catch
                {
                    MessageBox.Show(" add fail Tăng, giảm chi phí trả trước");
                }

                //9
                try
                {
                    Category newcategoryTGCKKD = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TGCKKD",
                        CategoryName = "Tăng, giảm chứng khoán kinh doanh",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[8].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TGCKKD = new CategoryBus().AddCate(newcategoryTGCKKD);
                }
                catch
                {
                    MessageBox.Show(" add fail Tăng, giảm chứng khoán kinh doanh");
                }

                //10
                try
                {
                    Category newcategoryTDN = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TDN",
                        CategoryName = "Thuế thu nhập doanh nghiệp đã nộp",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[9].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TDN = new CategoryBus().AddCate(newcategoryTDN);
                }
                catch
                {
                    MessageBox.Show(" add fail Thuế thu nhập doanh nghiệp đã nộp");
                }

                //11
                try
                {
                    Category newcategoryTTHDKD = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TTHDKD",
                        CategoryName = "Tiền thu khác từ hoạt động kinh doanh",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[10].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TTHDKD = new CategoryBus().AddCate(newcategoryTTHDKD);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền thu khác từ hoạt động kinh doanh");
                }

                //12
                try
                {
                    Category newcategoryTCHDKD = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TCHDKD",
                        CategoryName = "Tiền chi khác cho hoạt động kinh doanh",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[11].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TCHDKD = new CategoryBus().AddCate(newcategoryTCHDKD);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền chi khác cho hoạt động kinh doanh");
                }

                //13
                try
                {
                    Category newcategoryTMS = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TMS",
                        CategoryName = "Tiền chi để mua sắm, xây dựng TSCĐ và các tài sản dài hạn khác",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[12].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TMS = new CategoryBus().AddCate(newcategoryTMS);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền chi để mua sắm, xây dựng TSCĐ và các tài sản dài hạn khác");
                }

                //14
                try
                {
                    Category newcategoryTTTL = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TTTL",
                        CategoryName = "Tiền thu từ thanh lý, nhượng bán TSCĐ và các tài sản dài hạn khác",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[13].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TTTL = new CategoryBus().AddCate(newcategoryTTTL);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền thu từ thanh lý, nhượng bán TSCĐ và các tài sản dài hạn khác");
                }

                //15
                try
                {
                    Category newcategoryTCV = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TCV",
                        CategoryName = "Tiền chi cho vay, mua các công cụ nợ của đơn vị khác",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[14].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TCV = new CategoryBus().AddCate(newcategoryTCV);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền chi cho vay, mua các công cụ nợ của đơn vị khác");
                }

                //16
                try
                {
                    Category newcategoryTTCV = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TTCV",
                        CategoryName = "Tiền thu hồi cho vay, bán lại các công cụ nợ của đơn vị khác",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[15].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TTCV = new CategoryBus().AddCate(newcategoryTTCV);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền thu hồi cho vay, bán lại các công cụ nợ của đơn vị khác");
                }

                //17
                try
                {
                    Category newcategoryTTLCV = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TTLCV",
                        CategoryName = "Tiền thu lãi cho vay, cổ tức và lợi nhuận được chia",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[16].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TTLCV = new CategoryBus().AddCate(newcategoryTTLCV);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền thu lãi cho vay, cổ tức và lợi nhuận được chia");
                }

                //18
                try
                {
                    Category newcategoryLNTT = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "LNTT",
                        CategoryName = "Lợi nhuận trước thuế",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[17].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_LNTT = new CategoryBus().AddCate(newcategoryLNTT);
                }
                catch
                {
                    MessageBox.Show(" add fail Lợi nhuận trước thuế");
                }

                //19
                try
                {
                    Category newcategoryTCTVG = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TCTVG",
                        CategoryName = "Tiền chi trả vốn góp cho các chủ sở hữu, mua lại cổ phiếu của doanh nghiệp đã phát hành",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[18].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TCTVG = new CategoryBus().AddCate(newcategoryTCTVG);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền chi trả vốn góp cho các chủ sở hữu, mua lại cổ phiếu của doanh nghiệp đã phát hành");
                }

                //20
                try
                {
                    Category newcategoryCTLNDT = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "CTLNDT",
                        CategoryName = "Cổ tức, lợi nhuận đã trả cho chủ sở hữu",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[19].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_CTLNDT = new CategoryBus().AddCate(newcategoryCTLNDT);
                }
                catch
                {
                    MessageBox.Show(" add fail Cổ tức, lợi nhuận đã trả cho chủ sở hữu");
                }

                //21
                try
                {
                    Category newcategoryTVTDTDN = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TVTDTDN",
                        CategoryName = "Tiền và tương đương tiền đầu năm",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[20].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TVTDTDN = new CategoryBus().AddCate(newcategoryTVTDTDN);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền và tương đương tiền đầu năm");
                }

                //22
                try
                {
                    Category newcategoryTVTDTCN = new Category()
                    {
                        CompanyID = txtIdComLCTT.Text.Trim(),
                        CategoryID = "TVTDTCN",
                        CategoryName = "Tiền và tương đương tiền cuối năm",
                        Quarter = int.Parse(txtQuaterLCTT.Text.Trim()),
                        Year = int.Parse(txtYearLCTT.Text.Trim()),
                        Price = int.Parse(dataGridViewLCTT.Rows[21].Cells[2].Value.ToString()),
                        ReportID = int.Parse("3"),
                    };
                    bool addComplete_TVTDTCN = new CategoryBus().AddCate(newcategoryTVTDTCN);
                }
                catch
                {
                    MessageBox.Show(" add fail Tiền và tương đương tiền cuối năm");
                }


                //add all done
                MessageBox.Show("Add Complete LCTT !!!");
            }
            catch
            {
                MessageBox.Show("Unknow Erro LCTT !!!");
            }
        }
        private void tbtAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                Company newcompany = new Company()
                {
                    CompanyID = txtComID.Text.Trim(),
                    CompanyName = txtComName.Text.Trim(),
                    Address =  txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    MainJob = txtMainJob.Text.Trim(),
                    CEO = txtCEO.Text.Trim(),
                    StockPrice = int.Parse(txtStockPrice.Text.Trim()),
                    Amount = int.Parse(txtAmount.Text.Trim()),
                };
                DialogResult dialogResult = MessageBox.Show("Are You Want To Add ?","Add Company Message", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    new NewComBus().AddCom(newcompany);
                    //add done !
                    MessageBox.Show("Add New Company Complete !!!");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch
            {
                MessageBox.Show("Add Fail Company !!!");
            }
        }

      
    }
}
