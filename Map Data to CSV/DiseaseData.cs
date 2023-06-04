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

            // Console.WriteLine(atributos.Count());

            // for (int i = 0; i < atributos.Count(); i++) {
            //     Console.WriteLine($"i: {i}");
            //     if (i > 0) {

            //         dynamic[] retorno = RemoveContentInsideParentheses(atributos[i]);
            //         // Console.ForegroundColor = ConsoleColor.Blue;
            //         // foreach (var item in newAtributos) {
            //         //     Console.Write($"{item}      ");
            //         // }
            //         // Console.ResetColor();

            //         atributos[0] = retorno[0].Trim();
            //         foreach (string valor in atributos) {
            //             if (retorno[1] == true) {
            //                 // Console.WriteLine($"TEM MENOS (-)");
                            
            //                 try {
            //                     newAtributos.Add(float.Parse(valor) * -1);
                                
            //                 } catch (SystemException error) {
            //                     Console.ForegroundColor = ConsoleColor.Yellow;
            //                     Console.WriteLine($"{valor}");
            //                     Console.WriteLine(error.Message);
            //                     Console.ResetColor();
            //                 }
            //             } else {
            //                 newAtributos.Add(valor);
            //             }
            //         }

            //         Console.WriteLine(newAtributos.Count());

            //         // Console.ForegroundColor = ConsoleColor.Blue;
            //         // foreach (var item in newAtributos) {
            //         //     Console.Write($"{item}      ");
            //         // }
            //         // Console.ResetColor();
                    
                    
            //     } else {
            //         diseaseData.ContinentName = atributos[i];
            //     }
            // }

            Console.ForegroundColor = ConsoleColor.Blue;
            // foreach (var item in newAtributos) {
            //     Console.WriteLine($"{item}      ");
            // }
            Console.ResetColor();

            diseaseData.ContinentName = atributos[0];
            diseaseData.Asmr1990 = float.Parse(RemoveContentInsideParentheses(atributos[1])[0]);
            diseaseData.Deaths1990 = float.Parse(RemoveContentInsideParentheses(atributos[2])[0]);
            diseaseData.Asmr2019 = float.Parse(RemoveContentInsideParentheses(atributos[3])[0]);
            diseaseData.Deaths2019 = float.Parse(RemoveContentInsideParentheses(atributos[4])[0]);

            if (RemoveContentInsideParentheses(atributos[5])[1]) {
                diseaseData.AsmrDiff1990_2019 = float.Parse(RemoveContentInsideParentheses(atributos[5])[0] * -1);
            }
            

            // diseaseData.Asmr1990 = float.Parse(newAtributos[1]);
            // diseaseData.Deaths1990 = float.Parse(newAtributos[2]);
            // diseaseData.Asmr2019 = float.Parse(newAtributos[3]);
            // diseaseData.Deaths2019 = float.Parse(newAtributos[4]);
            // diseaseData.AsmrDiff1990_2019 = float.Parse(newAtributos[5]);
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
            // Console.ForegroundColor = ConsoleColor.Red;
            // Console.Write($"{value}       ");
            string result = Regex.Replace(value, pattern, string.Empty);
            // Console.ForegroundColor = ConsoleColor.Green;
            // Console.WriteLine($"{result}       ");
            // Console.ResetColor();

            return new dynamic[] {result, temMenos};
        }
    }
}