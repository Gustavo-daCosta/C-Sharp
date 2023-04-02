Console.Write($"Digite a altura da parede em metros: ");
float altura = float.Parse(Console.ReadLine()!);

Console.Write($"Digite a largura da parede em metros: ");
float largura = float.Parse(Console.ReadLine()!);

float area = (float)(altura * largura);
float quantTinta = area / 2;

Console.WriteLine($"Para pintar uma parede com {area}m² de área são necessários {quantTinta} litros de tinta");
