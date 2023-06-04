namespace Map_Data_to_CSV
{
    public class DiseaseData
    {
        // 0 - Continente
        // 1 - ASMR 1990
        // 2 - Mortes 1990
        // 3 - ASMR 2019
        // 4 - Mortes 2019
        // 5 - Diferença na taxa de ASMR entre 1990 e 2019
        // ASMR = Age-Standardized Mortality Rate

        public string ContinentName { get; set; }
        public float Asmr1990 { get; set;}
        public float Deaths1990 { get; set;}
        public float Asmr2019 { get; set;}
        public float Deaths2019 { get; set;}
        public float AsmrDiff1990_2019 { get; set; }
        public string PATH { get; set; } = "Data Model/Disease-Data.csv";

        public DiseaseData(string continentName) {
            ContinentName = continentName;
        }

        public float PrepareValue() {
            using (StreamReader stream = new StreamReader(PATH)) {
                string[] linhas = File.ReadAllLines(PATH);
                stream.Close();
            }

            
        }
    }
}