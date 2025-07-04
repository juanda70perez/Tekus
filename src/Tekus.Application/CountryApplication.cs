using Tekus.Entities;

namespace Tekus.Application
{
    public class CountryApplication
    {
        private readonly List<Country> _countries = [
            new Country { CountryID = "CO", Name = "Colombia" },
            new Country { CountryID = "US", Name = "United States" },
            new Country { CountryID = "CA", Name = "Canada" },
            new Country { CountryID = "MX", Name = "Mexico" },
            new Country { CountryID = "GB", Name = "United Kingdom" },
            new Country { CountryID = "FR", Name = "France" },
            new Country { CountryID = "DE", Name = "Germany" },
            new Country { CountryID = "JP", Name = "Japan" },
            new Country { CountryID = "CN", Name = "China" },
            new Country { CountryID = "IN", Name = "India" },
            new Country { CountryID = "BR", Name = "Brazil" }
        ];

        public List<Country> GetAll()
        {
            return _countries;
        }

        public Country? GetByID(string id)
        {
            return _countries.FirstOrDefault(x => x.CountryID == id);
        }
    }
}