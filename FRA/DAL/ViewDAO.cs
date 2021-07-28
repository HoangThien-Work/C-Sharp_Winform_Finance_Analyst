using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DTO;
using FRA.Data;

namespace FRA.DAL
{
    class ViewDAO
    {
        private const string strConn = DataString.conString;

        private FRA_DbDataContext db = new FRA_DbDataContext(strConn);
        public List<Company> GetAll()
        {
            List<Company> companies = db.Companies.ToList();
            return companies;
        }

        public List<Company> Search(string keyword)
        {
            List<Company> companies = db.Companies.Where(x => x.CompanyID.Contains(keyword)
                                                              || x.CompanyName.Contains(keyword)).ToList();
            return companies;
        }
        
    }
}
