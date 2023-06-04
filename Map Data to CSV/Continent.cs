namespace Map_Data_to_CSV
{
    public class Continent
    {
        public string Name { get; set; }
        public string PATH { get; set; }
        public List<Country> Countries { get; set; }

        public Continent() {}

        public Continent(string nome) {
            Name = nome;
            PATH = $"Data Model/Regions/{nome}-Data.csv";
            Countries = GetContinentCountries();
        }

        public bool ContinentContainsCountry(Continent continent, Country country) {
            string[] linhas;
            using (var stream = File.Open(continent.PATH, FileMode.Open, FileAccess.Write, FileShare.Read)) {
                linhas = File.ReadAllLines(continent.PATH);
                stream.Close();
            }

            foreach (string linha in linhas) {
                string[] atributos = linha.Split(",");

                if (!string.IsNullOrEmpty(country.Name)) {
                    if (country.Name.ToLower() == atributos[1]) {
                        return true;
                    }
                }
            }
            return false;
        }

        List<Country> GetContinentCountries() {
            List<Country> countries = new List<Country>();
            string[] linhas;
            using (StreamReader stream = new StreamReader(PATH)) {
                linhas = File.ReadAllLines(PATH);
                stream.Close();
            }

            foreach (Country country in Globals.AllCountries) {
                foreach (string linha in linhas) {
                    string[] atributos = linha.Split(',');
                    Country newCountry = country;
                    if (atributos[1] == country.Name) {
                        newCountry.Group = Name;
                    }
                    if (!countries.Contains(newCountry)) {
                        countries.Add(newCountry);
                    }
                }
            }
            return countries;
        }
    }
}