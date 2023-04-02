Console.Write($"Digite a 1° nota do aluno: ");
float nota1 = float.Parse(Console.ReadLine()!);

Console.Write($"Digite a 2° nota do aluno: ");
float nota2 = float.Parse(Console.ReadLine()!);

float media = (nota1 + nota2) / 2;

Console.WriteLine($"A média entre {Math.Round(nota1, 2)} e {Math.Round(nota2, 1)} é igual a {Math.Round(media, 1)}");
