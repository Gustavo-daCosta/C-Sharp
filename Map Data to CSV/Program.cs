using Map_Data_to_CSV;

void AddCountriesToContinents() {
    List<Country> allCountries = Globals.AllCountries;
}

void InsertCountries(string PATH) {
    foreach (Continent continent in Globals.Continents) {
        List<string> linhas = new List<string>();
        
        foreach (Country country in continent.Countries) {
            country.Label = country.Name;
            string linha = $"{country.Name};{country.Value};{country.Group};{country.Coordinates};{country.Label}";
            linhas.Add(linha);
        }

        using (var stream = File.Open(continent.PATH, FileMode.Open, FileAccess.Write, FileShare.Read)) {
            if (File.ReadAllLines(PATH).Count() < 210) {
                File.AppendAllLines(PATH, linhas);
            }
            stream.Close();
        }
        
    }

}


void GetDiseasesData() {
    const string diseasesPath = "Data Model/Disease-Data.csv";
    const string finalDataPath = "Database/Final-Map-Data.csv";

    string[] linhas = File.ReadAllLines(diseasesPath);

    int i = 0;
    foreach (string linha in linhas) {
        i++;
        string[] atributos = linha.Split(",");

        // 0 - Continente
        // 1 - ASMR 1990
        // 2 - Mortes 1990
        // 3 - ASMR 2019
        // 4 - Mortes 2019
        // 5 - Diferença na taxa de ASMR entre 1990 e 2019
        // ASMR = Age-Standardized Mortality Rate

        if (i > 1) { // Pular label
            foreach (Continent continent in Globals.Continents) {
                DiseaseData diseaseData = new DiseaseData(continent.Name);
                List<float> valores = new List<float>();
                for (int c = 0; c < 4; c++) {
                    float valor = diseaseData.PrepareValue();
                    valores.Add(valor);
                }
            }
        }

        
    }

    using (StreamReader stream = new StreamReader(finalDataPath)) {

        stream.Close();
    }
}


const string PATH = "Database/Final-Map-Data.csv";


AddCountriesToContinents();
// InsertCountries(PATH);


// foreach (Continent continent in Globals.Continents) {
//     Console.WriteLine($"{continent.Name}: {continent.Countries.Count} countries");
// }
