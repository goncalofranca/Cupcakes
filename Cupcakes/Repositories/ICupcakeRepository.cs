using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Cupcakes.Models;

namespace Cupcakes.Repositories
{
    interface ICupcakeRepository
    {
        public IEnumerable<Cupcake> GetCupcakes();
        public Cupcake GetCupcakeById(int id);
        public void CreateCupcake(Cupcake cupcake);
        public void DeleteCupcake(int id);
        public void SaveChanges();
        public IQueryable<Bakery> PopulateBakeriesDropDownList();
    }
}
