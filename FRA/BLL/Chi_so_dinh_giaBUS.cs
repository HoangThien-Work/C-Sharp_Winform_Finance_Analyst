using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DTO;
using FRA.DAL;
using FRA.Data;

namespace FRA.BLL
{
    class Chi_so_dinh_giaBUS
    {
        public string getCompanyID(string Name)
        {
            string ID = new OutputDAO().GetCompayID(Name);
            return ID;
        }

        //Tính toán theo quý
        public double EPSByQuarter(string companyID, int quarter, int year)
        {
            double loi_nhuan_sau_thue = new OutputDAO().GetPrice(companyID, "LNSTCPP", quarter, year);
            double KLCP = new OutputDAO().GetKLCP(companyID);
            try
            {
                double result = (loi_nhuan_sau_thue / KLCP);
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double BVPSByQuarter(string companyID, int quarter, int year)
        {
            double totalprice = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "TS");
            double totalliabilities = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "N");
            double KLCP = new OutputDAO().GetKLCP(companyID);
            try
            {
                double result = (totalprice - totalliabilities) / KLCP;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double PriceToEarningratioByQuarter(string companyID, int quarter, int year)
        {
            double stock = new OutputDAO().GetPriceStock(companyID);
            double eps = EPSByQuarter(companyID, quarter, year);
            try
            {
                double result = (stock / eps) / 1000;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double PricetoBookRatioByQuarter(string companyID, int quarter, int year)
        {
            double stock = new OutputDAO().GetPriceStock(companyID);
            double bvps = BVPSByQuarter(companyID, quarter, year);
            try
            {
                double result = (stock / bvps) / 1000;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double PricetoSalesRatioByQuarter(string companyID, int quarter, int year)
        {
            double stock = new OutputDAO().GetPriceStock(companyID);
            double KLCP = new OutputDAO().GetKLCP(companyID);
            double LNT = new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", quarter, year);
            try
            {
                double result = ((stock * KLCP) / LNT) / 1000;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double DYByQuarter(string companyID, int quarter, int year)
        {
            double LNCT = 0;
            double stock = new OutputDAO().GetPriceStock(companyID);
            try
            {
                double result = LNCT / stock;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        //Tính toán theo năm
        public double PricetoSalesRatioByYear(string companyID, int year)
        {
            double stock = new OutputDAO().GetPriceStock(companyID);
            double KLCP = new OutputDAO().GetKLCP(companyID);
            double totalLNT = 0;
            for (int i = 0; i < 4; i++)
            {
                totalLNT += new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", i + 1, year);
            }
            try
            {
                double result = ((stock * KLCP) / totalLNT) / 1000;
                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
