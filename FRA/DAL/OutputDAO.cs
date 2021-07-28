using System;
using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DTO;
using FRA.Data;

namespace FRA.DAL
{
    class OutputDAO
    {
        private FRA_DbDataContext db = new FRA_DbDataContext(DataString.conString);
        List<Category> categories = null;
        public List<Category> getAll()
        {
            categories = db.Categories.ToList();
            return categories;
        }
        public string GetCompayID(string companyName)
        {
            string id = db.Companies.Where(x => x.CompanyName == companyName).Select(x => x.CompanyID).SingleOrDefault();
            return id;
        }       
        public double GetPrice(string companyID,string categoryID, int quarter, int year)
        {
            try
            {                
                double price = (double)db.Categories.Where(x => x.CompanyID == companyID && x.CategoryID == categoryID && x.Quarter == quarter && x.Year == year).Select(x => x.Price).FirstOrDefault();
                if(double.IsNaN(price))
                {
                    return 0;
                }
                else
                {
                    return price;
                }                
            }
            catch
            {
                return 0;
            }
        }
        public double GetPriceStock(string companyID)
        {
            try
            {
                double result = (double)db.Companies.Where(x => x.CompanyID == companyID).Select(x => x.StockPrice).SingleOrDefault();
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double GetKLCP(string companyID)
        {
            try
            {
                double result = (double)db.Companies.Where(x => x.CompanyID == companyID).Select(x => x.Amount).SingleOrDefault();
                return result;
            }
            catch
            {
                return 0;
            }
        }
        public double TotalPriceByST(string companyID,int quarter, int year, int reportID, string typeID)
        {
            try
            {
                double result = 0;
                List<Category> all = db.Categories.Where(x => x.CompanyID == companyID && x.Quarter == quarter && x.Year == year && x.ReportID == reportID && x.TypeID==typeID).ToList();
                foreach (Category c in all)
                {
                    result +=(double)c.Price;
                }
                return result;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

    }
}
