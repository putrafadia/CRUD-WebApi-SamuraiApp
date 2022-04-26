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
    public class PedangRepo : IPedang
    {
        private SamuraiContext _context;
        public PedangRepo(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deletePedang = await GetById(id);
                _context.pedangs.Remove(deletePedang);
                await _context.SaveChangesAsync();

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

        public async Task<IEnumerable<Pedang>> GetAll()
        {
            var results = await _context.pedangs.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Pedang> GetById(int id)
        {
            var result = await _context.pedangs.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Pedang id: {id} Tidak ditemukan");
            return result;
        }

        public async Task<Pedang> Insert(Pedang obj)
        {
            try
            {
                _context.pedangs.Add(obj);
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

        public async Task<Pedang> Update(int id, Pedang obj)
        {
            try
            {
                var updatePedang = await GetById(id);
                updatePedang.Name = obj.Name;
                updatePedang.Berat = obj.Berat; 
                updatePedang.Tahun = obj.Tahun;

                await _context.SaveChangesAsync();
                return updatePedang;
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

    }
}
