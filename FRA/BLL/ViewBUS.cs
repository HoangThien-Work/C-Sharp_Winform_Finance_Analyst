using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DAL;
using FRA.DTO;

namespace FRA.BLL
{
    class ViewBUS
    {
        public List<Company> GetAll()
        {
            List<Company> companies = new ViewDAO().GetAll();
            return companies;
        }

        public List<Company> SearchByKeyword(string keyword)
        {
            List<Company> companies = new ViewDAO().Search(keyword);
            return companies;
        }
    }
}
