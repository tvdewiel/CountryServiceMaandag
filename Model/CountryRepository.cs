namespace CountryServiceMaandag.Model
{
    public class CountryRepository : ICountryRepository
    {
        private Dictionary<int,Country> _countries=new Dictionary<int, Country>();

        public CountryRepository()
        {
            _countries.Add(1,new Country(1,"België","Brussel","Europa"));
            _countries.Add(2, new Country(2,"Peru", "Lima", "Zuid-Amerika"));
            _countries.Add(3, new Country(3,"Duitsland", "Berlijn", "Europa"));
            _countries.Add(4, new Country(4,"Zweden", "Stockholm", "Europa"));
            _countries.Add(5, new Country(5,"Noorwegen", "Oslo", "Europa"));
        }

        public void AddCountry(Country country)
        {
            if (!_countries.ContainsKey(country.Id))
                _countries.Add(country.Id, country);
            else
                throw new CountryException("country already exists");
        }

        public IEnumerable<Country> GetAll()
        {
            return _countries.Values;
        }

        public IEnumerable<Country> GetAll(string continent)
        {
            return _countries.Values.Where(x => x.Continent == continent);
        }
        public IEnumerable<Country> GetAll(string continent, string capital)
        {
            return _countries.Values.Where(x => x.Continent == continent && x.Capital==capital);
        }
        public Country GetCountry(int id)
        {

                if (_countries.ContainsKey(id))
                    return _countries[id];
                else
                    throw new CountryException("country does not exists");
   
        }
        public void RemoveCountry(Country country)
        {
            if (_countries.ContainsKey(country.Id))
                _countries.Remove(country.Id);
            else
                throw new CountryException("country does not exists");
        }
        public void UpdateCountry(Country country)
        {
            if (_countries.ContainsKey(country.Id))
                _countries[country.Id]= country;
            else
                throw new CountryException("country does not exists");
        }
        public bool ExistsCountry(int id)
        { return _countries.ContainsKey(id); }
    }
}
