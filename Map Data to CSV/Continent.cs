// namespace Map_Data_to_CSV
// {
//     public class Continent
//     {
//         public List<Continent> Continents { get; set; } = new List<Continent>{
//             new Continent("Africa"),
//             new Continent("America"),
//             new Continent("Asia"),
//             new Continent("Europe"),
//             new Continent("Oceania")
//         };

//         public string Name { get; set; }
//         public string PATH { get; set; }

//         // public Continent() {}

//         public Continent(string nome) {
//             Name = nome;
//             PATH = $"Data Model/Regions/{nome}-Data.csv";
//         }

//         public bool ContinentContainsCountry(Continent continent, Country country) {
//             string[] linhas = File.ReadAllLines(continent.PATH);

//             foreach (string linha in linhas) {
//                 string[] atributos = linha.Split(",");

//                 if (!string.IsNullOrEmpty(country.Name)) {
//                     if (country.Name.ToLower() == atributos[1]) {
//                         return true;
//                     }
//                 }
//             }
//             return false;
//         }
//     }
// }