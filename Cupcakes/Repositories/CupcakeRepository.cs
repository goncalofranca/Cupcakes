using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Cupcakes.Data;
using Cupcakes.Models;
using Microsoft.EntityFrameworkCore;

namespace Cupcakes.Repositories
{
    public class CupcakeRepository : ICupcakeRepository
    {
        private CupcakeContext _context;
        public CupcakeRepository(CupcakeContext context)
        {
            _context = context;
        }

        public void CreateCupcake(Cupcake cupcake)
        {
            if(cupcake.PhotoAvatar is not null)
            {
                if(cupcake.PhotoAvatar.Length > 0)
                {
                    cupcake.ImageMimeType = cupcake.PhotoAvatar.ContentType;
                    cupcake.ImageName = Path.GetFileName(cupcake.PhotoAvatar.FileName);
                    using MemoryStream _ctxMemory = new();
                    cupcake.PhotoAvatar.CopyTo(_ctxMemory);
                    cupcake.PhotoFile = _ctxMemory.ToArray();
                }
            }
            _ = _context.Add(cupcake);
            _ = _context.SaveChanges();
        }

        public void DeleteCupcake(int id)
        {
            _ = _context.Remove(_context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id));
            _ = _context.SaveChanges();
        }
        public Cupcake GetCupcakeById(int id) => _context.Cupcakes.Include(b => b.Bakery).SingleOrDefault(c => c.CupcakeId == id);
        public IEnumerable<Cupcake> GetCupcakes()
        {
            return _context.Cupcakes.ToList();
        }
        public IQueryable<Bakery> PopulateBakeriesDropDownList()
        {
            var _ctxBakeriesQuery = from b in _context.Bakeries
                                orderby b.BakeryName
                                select b;
            return _ctxBakeriesQuery;

        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
