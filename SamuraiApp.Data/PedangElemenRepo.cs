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
    public class PedangElemenRepo : IPedangElemen
    {
        private SamuraiContext _context;
        public PedangElemenRepo(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteElemen = await GetById(id);
                _context.pedangs.Remove(deleteElemen);
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
            var results = await _context.pedangs.Include(e => e.elemens).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Pedang> GetById(int id)
        {
            var result = await _context.pedangs.Include(e => e.elemens).FirstOrDefaultAsync(s => s.Id == id);
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
                var updatePedangElemen = await GetById(id);
                updatePedangElemen.Name = obj.Name;
                updatePedangElemen.Berat = obj.Berat;
                updatePedangElemen.Tahun = obj.Tahun;
                updatePedangElemen.elemens = obj.elemens;
                await _context.SaveChangesAsync();
                return updatePedangElemen;
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
