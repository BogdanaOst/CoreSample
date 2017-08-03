using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryCoreSample.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public int NumberOfHomemates { get; set; }
        public int Floors { get; set; }
    }
}
