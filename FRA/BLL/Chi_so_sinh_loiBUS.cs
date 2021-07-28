using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DAL;

namespace FRA.BLL
{
    class Chi_so_sinh_loiBUS
    {
        public string getCompanyID(string Name)
        {
            string ID = new OutputDAO().GetCompayID(Name);
            return ID;
        }

        //tính theo quý
        public double ROS(string companyID, int quarter, int year)
        {
            double LNST = new OutputDAO().GetPrice(companyID, "LNSTTNDN", quarter, year);
            double DTT = new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", quarter, year);
            try
            {

                double result = (LNST / DTT) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double ROEA(string companyID, int quarter, int year)
        {
            double LNST = new OutputDAO().GetPrice(companyID, "LNSTTNDN", quarter, year);
            double totalprice = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "TS");
            double totalliabilities = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "N");
            double V = totalprice - totalliabilities;
            try
            {

                double result = (LNST / V) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double ROCE(string companyID, int quarter, int year)
        {
            double EBIT = new OutputDAO().GetPrice(companyID, "TLNKTTT", quarter, year);
            double totalprice = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "TS");
            double totalliabilities = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "N");
            double V = totalprice - totalliabilities;
            try
            {

                double result = (EBIT / V) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        public double ROAA(string companyID, int quarter, int year)
        {
            double LNST = new OutputDAO().GetPrice(companyID, "LNSTTNDN", quarter, year);
            double totalprice = new OutputDAO().TotalPriceByST(companyID, quarter, year, 1, "TS");
            try
            {

                double result = (LNST / totalprice) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }

        //tính theo năm
        public double ROSByYear(string companyID, int year)
        {
            double totalLNST = 0;
            double totalDTT = 0;
            for (int i = 0; i < 4; i++)
            {
                totalLNST += new OutputDAO().GetPrice(companyID, "LNSTTNDN", i + 1, year);
                totalDTT += new OutputDAO().GetPrice(companyID, "DTTVBHVCCDV", i + 1, year);
            }
            try
            {

                double result = (totalLNST / totalDTT) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double ROEAByYear(string companyID, int year)
        {
            double toatlLNST = 0;
            double totalprice = 0;
            double totalliabilities = 0;

            for (int i = 0; i < 4; i++)
            {
                toatlLNST += new OutputDAO().GetPrice(companyID, "LNSTTNDN", i + 1, year);
                totalprice += new OutputDAO().TotalPriceByST(companyID, i + 1, year, 1, "TS");
                totalliabilities += new OutputDAO().TotalPriceByST(companyID, i + 1, year, 1, "N");
            }
            double V = totalprice - totalliabilities;
            try
            {

                double result = (toatlLNST / V) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double ROCEByYear(string companyID, int year)
        {
            double EBIT = 0;
            double totalprice = 0;
            double totalliabilities = 0;

            for (int i = 0; i < 4; i++)
            {
                EBIT += new OutputDAO().GetPrice(companyID, "TLNKTTT", i + 1, year);
                totalprice += new OutputDAO().TotalPriceByST(companyID, i + 1, year, 1, "TS");
                totalliabilities += new OutputDAO().TotalPriceByST(companyID, i + 1, year, 1, "N");
            }
            double V = totalprice - totalliabilities;
            try
            {

                double result = (EBIT / V) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double ROAAByYear(string companyID, int year)
        {
            double LNST = 0;
            double totalprice = 0;
            for (int i = 0; i < 4; i++)
            {
                LNST += new OutputDAO().GetPrice(companyID, "LNSTTNDN", i + 1, year);
                totalprice += new OutputDAO().TotalPriceByST(companyID, i + 1, year, 1, "TS");
            }
            try
            {
                double result = (LNST / totalprice) * 100;
                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
