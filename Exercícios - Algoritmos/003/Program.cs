Console.Write($"Nome do funcionário: ");
string nome = Console.ReadLine()!;

Console.Write($"Salário do funcionário: R$");
float salario = float.Parse(Console.ReadLine()!);

Console.WriteLine($"O funcionário {nome} ganha um salário de R${Math.Round(salario, 2)}");
