using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DAL;
using FRA.DTO;

namespace FRA.BLL
{
    class Chi_so_tang_truongBUS
    {
        public string getCompanyID(string Name)
        {
            string ID = new OutputDAO().GetCompayID(Name);
            return ID;
        }

        //tính theo quý
        public double SalesGrowthRate(string companyID, int quarter,int year)
        {
            double startValue = new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", quarter, year - 1);
            double finalValue = new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", quarter, year);
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double GrossProfitGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().GetPrice(companyID, "LNGVBHVCCDV", quarter, year - 1);
            double finalValue = new OutputDAO().GetPrice(companyID, "LNGVBHVCCDV", quarter, year);
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double PreTaxProfitGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().GetPrice(companyID, "TLNKTTT", quarter, year - 1);
            double finalValue = new OutputDAO().GetPrice(companyID, "TLNKTTT", quarter, year);
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double AfterTaxProfitGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().GetPrice(companyID, "LNSTTNDN", quarter, year - 1);
            double finalValue = new OutputDAO().GetPrice(companyID, "LNSTTNDN", quarter, year);
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double TotalAssetGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().TotalPriceByST(companyID, quarter, year-1, 1, "TS");
            double finalValue = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "TS");
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double LongTermDebtGrouwth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().GetPrice(companyID, "DPPTDH", quarter, year - 1);
            double finalValue = new OutputDAO().GetPrice(companyID, "DPPTDH", quarter, year);
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double LiabilitiesGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().TotalPriceByST(companyID, quarter, year-1, 1, "N");
            double finalValue = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "N");
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double EquityGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().TotalPriceByST(companyID, quarter, year - 1, 1, "V");
            double finalValue = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "V");
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double CharterCapitalGrowth(string companyID, int quarter, int year)
        {
            double startValue = new OutputDAO().GetPrice(companyID, "VDTCSH", quarter, year - 1);
            double finalValue = new OutputDAO().GetPrice(companyID, "VDTCSH", quarter, year);
            try
            {
                double result = ((finalValue - startValue) / startValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }


        //tính theo năm
        public double SalesGrowthRateByYear(string companyID,  int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i=0;i<4;i++)
            {
                totalstartValue += new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", i+1, year - 1);
                totalfinalValue += new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", i + 1, year);
            }
            
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double GrossProfitGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().GetPrice(companyID, "LNGVBHVCCDV", i + 1, year - 1);
                totalfinalValue += new OutputDAO().GetPrice(companyID, "LNGVBHVCCDV", i + 1, year);
            }

            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double PreTaxProfitGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().GetPrice(companyID, "TLNKTTT", i + 1, year - 1);
                totalfinalValue += new OutputDAO().GetPrice(companyID, "TLNKTTT", i + 1, year);
            }

            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double AfterTaxProfitGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().GetPrice(companyID, "LNSTTNDN", i + 1, year - 1);
                totalfinalValue += new OutputDAO().GetPrice(companyID, "LNSTTNDN", i + 1, year);
            }
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double TotalAssetGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().TotalPriceByST(companyID, i+1, year - 1, 1, "TS");
                totalfinalValue += new OutputDAO().TotalPriceByST(companyID, i + 1, year, 1, "TS");
            }           
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
            
        }

        public double LongTermDebtGrouwthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().GetPrice(companyID, "DPPTDH", i+1, year - 1);
                totalfinalValue += new OutputDAO().GetPrice(companyID, "DPPTDH", i+1, year);
            }
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double LiabilitiesGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().TotalPriceByST(companyID, i+1, year - 1, 1, "N");
                totalfinalValue += new OutputDAO().TotalPriceByST(companyID, i+1, year, 1, "N");
            }
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double EquityGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue =0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().TotalPriceByST(companyID, i+1, year - 1, 1, "V");
                totalfinalValue += new OutputDAO().TotalPriceByST(companyID, i+1, year, 1, "V");
            }
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double CharterCapitalGrowthByYear(string companyID, int year)
        {
            double totalstartValue = 0;
            double totalfinalValue = 0;
            for (int i = 0; i < 4; i++)
            {
                totalstartValue += new OutputDAO().GetPrice(companyID, "VDTCSH", i+1, year - 1);
                totalfinalValue += new OutputDAO().GetPrice(companyID, "VDTCSH", i+1, year);
            }
            try
            {
                double result = ((totalfinalValue - totalstartValue) / totalstartValue) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
