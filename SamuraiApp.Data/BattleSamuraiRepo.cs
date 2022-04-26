using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class BattleSamuraiRepo : IBattleSamurai
    {

        private SamuraiContext _context;
        public BattleSamuraiRepo(SamuraiContext context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.Include(p => p.Battles).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public Task<Samurai> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> Insert(Samurai obj)
        {
            throw new NotImplementedException();
        }

        public Task<Samurai> Update(int id, Samurai obj)
        {
            throw new NotImplementedException();
        }
    }
}