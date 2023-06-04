using System.Globalization;
using System.Text.RegularExpressions;

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

        public DiseaseData() {}

        public DiseaseData(string continentName) {
            ContinentName = continentName;
        }
        
        public DiseaseData PrepareValues(string[] atributos, string continentName) {
            DiseaseData diseaseData = new DiseaseData(continentName);



            List<dynamic> newAtributos = new List<dynamic>();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ResetColor();

            diseaseData.ContinentName = atributos[0];
            diseaseData.Asmr1990 = float.Parse(RemoveContentInsideParentheses(atributos[1])[0]);
            diseaseData.Deaths1990 = float.Parse(RemoveContentInsideParentheses(atributos[2])[0]);
            diseaseData.Asmr2019 = float.Parse(RemoveContentInsideParentheses(atributos[3])[0]);
            diseaseData.Deaths2019 = float.Parse(RemoveContentInsideParentheses(atributos[4])[0]);

            if (RemoveContentInsideParentheses(atributos[5])[1]) {
                diseaseData.AsmrDiff1990_2019 = float.Parse(RemoveContentInsideParentheses(atributos[5])[0] * -1);
            }
            return diseaseData;
        }

        public static dynamic[] RemoveContentInsideParentheses(string value) {
            string pattern;
            bool temMenos = false;
            if (value.Count(x => x == '-') >= 1) {
                pattern = @"(?<!-)\([^()]*\)";
                temMenos = true;
            } else {
                pattern = @"\([^()]*\)";
            }
            string result = Regex.Replace(value, pattern, string.Empty);

            return new dynamic[] {result, temMenos};
        }
    }
}