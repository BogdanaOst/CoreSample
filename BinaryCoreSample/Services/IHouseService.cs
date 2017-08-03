using BinaryCoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryCoreSample.Services
{
	public interface IHouseService
    {
        Task<List<House>> GetAllAsync();
        Task<House> GetByIdAsync(int id);
        Task AddAsync(House house);
        Task DeleteAsync(int id);
        Task EditAsync(House house);
        Task SaveAsync();
    }
}
