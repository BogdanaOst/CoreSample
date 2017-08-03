using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaryCoreSample.Models;
using Microsoft.EntityFrameworkCore;

namespace BinaryCoreSample.Services
{
    public class HouseService : IHouseService
    {
        private HouseContext db;
        private bool dispose = false;
        public HouseService(HouseContext context)
        {
            db = context;
        }
        public async Task AddAsync(House house)
        {
            await db.Houses.AddAsync(house);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            House item = await db.Houses.FindAsync(id);
            if (item != null)
                db.Houses.Remove(item);
            await SaveAsync();
        }

        public async Task EditAsync(House house)
        {
            db.Entry(house).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task<List<House>> GetAllAsync()
        {
            return await db.Houses.ToListAsync();
        }

        public async Task<House> GetByIdAsync(int id)
        {
            return await db.Houses.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
