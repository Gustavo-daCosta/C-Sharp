Console.Write($"Digite uma distância em metros: ");
float metros = float.Parse(Console.ReadLine()!);

Console.WriteLine(@$"
A distância de {metros}m corresponde a:
{metros * 1000}Km
{metros * 100}Hm
{metros * 10}Dm
{metros / 10}dm
{metros / 100}cm
{metros / 1000}mm
");
