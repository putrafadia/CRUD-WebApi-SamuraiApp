using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiPedangElemenRepo : ISamuraiPedangElemen
    {
        private SamuraiContext _context;
        public SamuraiPedangElemenRepo(SamuraiContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.Include(p=>p.Pedangs).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Samurai> GetById(int id)
        {
            //var result = await _context.Samurais.Include(p => p.Pedangs).FirstOrDefaultAsync(s => s.Id == id);
            var result = await _context.Samurais.Include(p => p.Pedangs).ThenInclude(e=>e.elemens).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data samurai id: {id} Tidak ditemukan");
            return result;
        }

        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Samurai> Update(int id, Samurai obj)
        {
            throw new NotImplementedException();
        }
    }
}
