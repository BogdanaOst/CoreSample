using BinaryCoreSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryCoreSample.Services
{
    public class CustomService
    {
        HouseContext context;
        public CustomService(HouseContext _context)
        {
            context = _context;
        }
        public List<House> GetHousesWithLessFloorsThenParam(int param)
        {
            var houses = (from n in context.Houses
                          where n.Floors < param
                          select n).ToList();
            return houses;
        }
    }
}
