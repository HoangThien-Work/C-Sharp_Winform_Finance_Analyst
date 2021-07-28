using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRA.DTO;
using FRA.DAL;

namespace FRA.BLL
{
    class CategoryBus
    {
       public bool AddCate(Category newCategory)
        {
            //call method  from CategoryDAO class
            bool result = new CategoryDAO().InsertCate(newCategory);
            return result;
        }
    }
}
