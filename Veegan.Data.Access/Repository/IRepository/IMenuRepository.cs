using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Models;
using Vegan.Models.Model;

namespace Veegan.Data.Access.Repository.IRepository
{
     public interface IMenuItemRepository : IRepository<MenuItem>
    {

        //we add the interface of update in a new folder
        void Update(MenuItem obj);
      //  void Save();
      // We can't save or repos here we use a unit of work 
    }
}
