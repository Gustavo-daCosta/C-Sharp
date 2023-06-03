using Map_Data_to_CSV;

List<Country> GetAllCountries() {
    List<Country> countries = new List<Country>();

    const string modelPath = "Data Model/DataModel.csv";
    string[] linhas = File.ReadAllLines(modelPath);

    int i = 0;
    foreach (string linha in linhas) {
        i++;
        string[] atributos = linha.Split(",");

        Country country = new Country();

        if (i > 1) {
            country.Name = atributos[0].Trim();
            country.Value = float.Parse(atributos[1].Trim());
            country.Group = atributos[2].Trim();
            country.Coordinates = atributos[3].Trim();
            country.Label = atributos[4].Trim();

            countries.Add(country);
        }
    }
    return countries;
}

// List<Country> GetCountriesFromContinent(Continent continentBase) {
//     List<Country> allCountries = GetAllCountries();
//     List<Country> continentCountries = new List<Country>();
//     Country countryBase = new Country();

//     foreach (Continent continent in continentBase.Continents) {
//         if (continent.ContinentContainsCountry(continent, countryBase)) {
//             countryBase.Continent = continent;
//         }
//     }
// }

// Continent FindCountryContinent(Country country) {
    
// }


const string PATH = "Database/Final-Map-Data.csv";

string folder = PATH.Split('/')[0];
if (!Directory.Exists(folder)) { Directory.CreateDirectory(folder); }
if (!File.Exists(PATH)) { File.Create(PATH); }


List<Country> countries = GetAllCountries();

foreach (Country country in countries) {
    Console.WriteLine($"País: {country.Name}        Grupo: {country.Group}");
    // Thread.Sleep(500);
}

// List<Country> africaCountries = GetCountriesFromContinent(new Continent("Africa"));
// // List<Country> 

// string regionsPath = "Data Model/Regions";

// for (int i = 0; i < Directory.GetFiles(regionsPath).Count(); i++) {
//     string modelPath = Path.Combine(regionsPath, Directory.GetFiles(regionsPath)[i]);
//     string[] linhas = File.ReadAllLines(modelPath);

//     foreach (string linha in linhas) {
//         string[] atributos = linha.Split(",");

//         Country country = new Country();

        
//     }
// }
