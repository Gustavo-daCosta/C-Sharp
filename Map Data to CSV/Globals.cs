namespace Map_Data_to_CSV
{
    public class Globals
    {
        public static List<Country> AllCountries { get; set; } = GetAllCountries();
        public static List<Continent> Continents { get; set; } = new List<Continent>{
            new Continent("Africa"),
            new Continent("America"),
            new Continent("Asia"),
            new Continent("Europe"),
            new Continent("Oceania"),
        };

        public static List<DiseaseData> DiseaseDataPerContinent { get; set; } = new List<DiseaseData>{
            new DiseaseData("Africa"),
            new DiseaseData("America"),
            new DiseaseData("Asica"),
            new DiseaseData("Europe"),
            new DiseaseData("Oceania"),
        };


        private static List<Country> GetAllCountries() {
            List<Country> countries = new List<Country>();

            const string modelPath = "Data Model/DataModel.csv";
            string[] linhas;
            using (StreamReader streamReader = new StreamReader(modelPath)) {
                linhas = File.ReadAllLines(modelPath);
                streamReader.Close();
            }


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

        public static string[] ReadAllLines(string PATH) {
            string[] linhas;
            using (var stream = File.Open(PATH, FileMode.Open, FileAccess.Write, FileShare.Read)) {
                linhas = File.ReadAllLines(PATH);
                stream.Close();
            }
            return linhas;
        }
    }
}