// See https://aka.ms/new-console-template for more information
const string firstAllowedSign = "fire";
const string secondAllowedSign = "water";
const string thirdAllowedSign = "grass";

string[] allowedSigns = ["fire", "water", "grass"];
int firstPlayerPoints = 0;
int secondPlayerPoints = 0;

while (true)
{
    // Console.WriteLine("Podaj znak, graczu 1 (" + firstAllowedSign + "/" + secondAllowedSign + "/" + thirdAllowedSign + ")");
    // Console.WriteLine($"Podaj znak, graczu 1 ({allowedSigns[0]}/{allowedSigns[1]}/{allowedSigns[2]})");
    Console.WriteLine($"Podaj znak, graczu 1 ({string.Join("/", allowedSigns)})");
    // typ nazwa; 
    // typ nazwa = wartość;

    // string firstSign = (Console.ReadLine() ?? string.Empty).ToLower();
    string firstSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    // firstSign = firstSign.ToLower();

    // while (firstSign != firstAllowedSign && firstSign != secondAllowedSign && firstSign != thirdAllowedSign)
    while (!allowedSigns.Contains(firstSign))
    {
        Console.WriteLine("Niepoprawny znak!");
        // Console.WriteLine($"Podaj POPRAWNY znak, graczu 1 ({firstAllowedSign}/{secondAllowedSign}/{thirdAllowedSign})");
        Console.WriteLine($"Podaj POPRAWNY znak, graczu 1 ({string.Join("/", allowedSigns)})");
        firstSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    }

    // Console.WriteLine($"Podaj znak, graczu 2 ({firstAllowedSign}/{secondAllowedSign}/{thirdAllowedSign})");
    Console.WriteLine($"Podaj znak, graczu 2 ({string.Join("/", allowedSigns)})");
    string secondSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;


    // while (secondSign != firstAllowedSign && secondSign != secondAllowedSign && secondSign != thirdAllowedSign)
    while (!allowedSigns.Contains(secondSign))
    {
        Console.WriteLine("Niepoprawny znak!");
        // Console.WriteLine($"Podaj POPRAWNY znak, graczu 2 ({firstAllowedSign}/{secondAllowedSign}/{thirdAllowedSign})");
        Console.WriteLine($"Podaj POPRAWNY znak, graczu 2 ({string.Join("/", allowedSigns)})");
        secondSign = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
    }

    // porównanie znaków - instrukcja warunkowa if
    if (firstSign == secondSign) // dlaczego tutaj nie ma średnika?!?!?!
    {
        Console.WriteLine("Remis!");
    }
    else if ((firstSign == firstAllowedSign && secondSign == thirdAllowedSign) || (firstSign == secondAllowedSign && secondSign == firstAllowedSign) || (firstSign == thirdAllowedSign && secondSign == secondAllowedSign))
    {
        Console.WriteLine("Gracz 1 MISZCZ!");
        // firstPlayerPoints = firstPlayerPoints + 1;
        firstPlayerPoints += 1;
    }
    else
    {
        Console.WriteLine("Gracz 2 MISZCZ!");
        // secondPlayerPoints = secondPlayerPoints + 1;
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