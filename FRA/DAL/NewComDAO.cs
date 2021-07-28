using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DTO;

namespace FRA.DAL
{
    class NewComDAO
    {
        //connect to DB
        FRA_DbDataContext db = new FRA_DbDataContext("SERVER=den1.mssql7.gear.host;DATABASE=fra;USER=fra;PASSWORD=Cz5CAf8?mv!x");

        public bool InsertCom(Company company)
        {
            try
            {
                db.Companies.InsertOnSubmit(company);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

