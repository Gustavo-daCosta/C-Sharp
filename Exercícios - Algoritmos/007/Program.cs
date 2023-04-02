Console.Write($"Digite um número: ");
float numero = float.Parse(Console.ReadLine()!);

Console.WriteLine(@$"
O dobro de {numero} é {numero * 2}
A terça parte de {numero} é {numero / 3}
");
