Console.Write($"Digite quanto dinheiro você tem na carteira: R$");
float dinheiroReais = float.Parse(Console.ReadLine()!);

float dinheiroDolares = (float)(dinheiroReais / 3.45);

Console.WriteLine($"Com R${dinheiroReais} na carteira, você pode comprar ${Math.Round(dinheiroDolares, 2)} dólares");
