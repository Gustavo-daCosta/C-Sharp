using Map_Data_to_CSV;

void AddCountriesToContinents() {
    List<Country> allCountries = Globals.AllCountries;
}

void InsertCountries(string PATH) {
    foreach (Continent continent in Globals.Continents) {
        List<string> linhas = new List<string>();
        
        foreach (Country country in continent.Countries) {
            country.Label = country.Name;
            string linha = $"{country.Name},{country.Value},{country.Group},{country.Coordinates},{country.Label}";
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


List<DiseaseData> GetDiseasesData() {
    const string diseasesPath = "Data Model/Disease-Data.csv";

    List<DiseaseData> databaseDiseases = new List<DiseaseData>();

    string[] linhas;
    using (StreamReader stream = new StreamReader(diseasesPath)) {
        linhas = File.ReadAllLines(diseasesPath);
        stream.Close();
    }

    foreach (string linha in linhas) {
        string[] atributos = linha.Split(",");

        // 0 - Continente
        // 1 - ASMR 1990
        // 2 - Mortes 1990
        // 3 - ASMR 2019
        // 4 - Mortes 2019
        // 5 - Diferença na taxa de ASMR entre 1990 e 2019
        // ASMR = Age-Standardized Mortality Rate

        foreach (Continent continent in Globals.Continents) {
            DiseaseData diseaseData = new DiseaseData(continent.Name);
            databaseDiseases.Add(diseaseData.PrepareValues(atributos, continent.Name));
        }
    }

    int i = 0;
    List<DiseaseData> continentsValues = new List<DiseaseData>();
    foreach (Continent continent in Globals.Continents) {
        DiseaseData valorFinalContinent = new DiseaseData();
        DiseaseData continentData = new DiseaseData();
        int continentCount = 0;
        
        foreach (DiseaseData diseaseData in databaseDiseases) {
            if (databaseDiseases[i].ContinentName.Contains(continent.Name)) {
                continentData.Asmr1990 += databaseDiseases[i].Asmr1990;
                continentData.Deaths1990 += databaseDiseases[i].Deaths1990;
                continentData.Asmr2019 += databaseDiseases[i].Asmr2019;
                continentData.Deaths2019 += databaseDiseases[i].Deaths2019;
                continentData.AsmrDiff1990_2019 += databaseDiseases[i].AsmrDiff1990_2019;
                continentCount++;
            }
        }
        valorFinalContinent.Asmr1990 = continentData.Asmr1990 / continentCount;
        valorFinalContinent.Deaths1990 = continentData.Deaths1990 / continentCount;
        valorFinalContinent.Asmr2019 = continentData.Asmr2019 / continentCount;
        valorFinalContinent.Deaths2019 = continentData.Deaths2019 / continentCount;
        valorFinalContinent.AsmrDiff1990_2019 = continentData.AsmrDiff1990_2019 / continentCount;
        continentsValues.Add(valorFinalContinent);
        i++;
    }


    for (int c = 0; c < Globals.Continents.Count; c++) {
        for (int x = 0; x < databaseDiseases.Count(); x++) {
            if (databaseDiseases[x].ContinentName.Contains(Globals.Continents[c].Name)) {
                foreach (Country country in Globals.Continents[c].Countries) {
                    country.Value = databaseDiseases[x].Asmr1990;
                }
            }
        }
    }

    return databaseDiseases;
}

void AlterarDadosFinalDiseases(string finalDataPath) {
    // ler
    // alterar valores
    // deletar dados
    // colocar os novos

    List<DiseaseData> databaseDiseases = GetDiseasesData();
    List<Country> listaPaisesFinal = new List<Country>();

    // ler e capturar dados
    List<Country> countries = LerDatabaseFinal(finalDataPath);

    // alterar valores
    foreach (DiseaseData diseaseData in databaseDiseases) {
        for (int i = 0; i < countries.Count(); i++) {
            if (countries[i].Group == diseaseData.ContinentName) {
                countries[i].Value = diseaseData.Asmr1990;
                countries.Add(countries[i]);
            }
        }
    }

    foreach (Country country in countries) {
        Console.WriteLine($"{country.Name} - {country.Value}");
    }
}

List<Country> LerDatabaseFinal(string finalDataPath) {
    string[] linhas;
    using (StreamReader stream = new StreamReader(finalDataPath)) {
        linhas = File.ReadAllLines(finalDataPath);
        stream.Close();
    }

    List<Country> paises = new List<Country>();
    foreach (string linha in linhas) {
        string[] atributos = linha.Split(",");
        Country country = new Country();

        country.Name = atributos[0];
        country.Value = float.Parse(atributos[1]);
        country.Group = atributos[2];
        country.Coordinates = atributos[3];
        country.Label = atributos[4];

        paises.Add(country);
    }
    return paises;
}


const string PATH = "Database/Final-Map-Data.csv";

AddCountriesToContinents();
GetDiseasesData();
AlterarDadosFinalDiseases(PATH);
// InsertCountries(PATH);
