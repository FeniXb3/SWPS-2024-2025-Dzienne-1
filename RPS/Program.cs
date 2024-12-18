const string firstAllowedSign = "fire";
const string secondAllowedSign = "water";
const string thirdAllowedSign = "grass";

string[] allowedSigns = ["fire", "water", "grass"];
int firstPlayerPoints = 0;
int secondPlayerPoints = 0;

while (true)
{
    Console.WriteLine($"Podaj znak, graczu 1 ({string.Join("/", allowedSigns)})");
    string firstSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;

    while (!allowedSigns.Contains(firstSign))
    {
        Console.WriteLine("Niepoprawny znak!");
        Console.WriteLine($"Podaj POPRAWNY znak, graczu 1 ({string.Join("/", allowedSigns)})");
        firstSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    }

    Console.WriteLine($"Podaj znak, graczu 2 ({string.Join("/", allowedSigns)})");
    string secondSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;


    while (!allowedSigns.Contains(secondSign))
    {
        Console.WriteLine("Niepoprawny znak!");
        Console.WriteLine($"Podaj POPRAWNY znak, graczu 2 ({string.Join("/", allowedSigns)})");
        secondSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    }

    if (firstSign == secondSign) // dlaczego tutaj nie ma średnika?!?!?!
    {
        Console.WriteLine("Remis!");
    }
    else if ((firstSign == firstAllowedSign && secondSign == thirdAllowedSign) || (firstSign == secondAllowedSign && secondSign == firstAllowedSign) || (firstSign == thirdAllowedSign && secondSign == secondAllowedSign))
    {
        Console.WriteLine("Gracz 1 MISZCZ!");
        firstPlayerPoints += 1;
    }
    else
    {
        Console.WriteLine("Gracz 2 MISZCZ!");
        secondPlayerPoints += 1;
    }

    Console.WriteLine($"Punkty gracza 1: {firstPlayerPoints}");
    Console.WriteLine($"Punkty gracza 2: {secondPlayerPoints}");

    Console.WriteLine("Czy kończymy na dziś?");
    string reply = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    if (reply == "tak")
    {
        break;
    }
}

Console.WriteLine("Dziękuję za grę!");