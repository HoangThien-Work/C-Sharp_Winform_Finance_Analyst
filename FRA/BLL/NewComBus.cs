using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DTO;
using FRA.DAL;

namespace FRA.BLL
{
    class NewComBus
    {
        public bool AddCom(Company newCompany)
        {
            //call method insertCom from AddnewDAO class
            bool result = new NewComDAO().InsertCom(newCompany);
            return result;
        }
    }
}
