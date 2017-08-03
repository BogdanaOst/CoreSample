using BinaryCoreSample.Services;

namespace BinaryCoreSample.Models
{
    public class DbInitializer
    {
        IHouseService service;
        public DbInitializer(IHouseService _service)
        {
            service = _service;
        }
        public void Initialize()
        {
            if (service.GetAllAsync().Result.Count == 0)
            {
                {
                    service.AddAsync(new House
                    {
                        Adress = "Sumskaya38",
                        NumberOfHomemates = 20,
                        Floors = 5
                    });
                }
            }
        }
    }
}
