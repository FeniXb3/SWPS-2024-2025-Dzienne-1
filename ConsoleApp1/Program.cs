string[] defaultTexts = ["kotek", "Solid Snake", "SWPS"];

Console.WriteLine("Jakie słowo ma być odgadnięte?");
string fullText = Console.ReadLine() ?? string.Empty;

if (string.IsNullOrWhiteSpace(fullText))
{
    Console.WriteLine("Losuję słowo do odgadnięcia");
    int textIndex = Random.Shared.Next(defaultTexts.Length);
    fullText = defaultTexts[textIndex];
}

Console.WriteLine("Ile szans ma mieć osoba odgadująca?");

if (!int.TryParse(Console.ReadLine(), out int lives))
{
    lives = 3;
    Console.WriteLine($"Niepoprawna wartość, ustalam liczbę szans na {lives}");
}

// Poniższa linijka wywali grę, jeśli uruchomi się ją w Debug Console, dlatego zakomentowałem
// Console.Clear();
string[] knownLetters = new string[fullText.Length];
Array.Fill(knownLetters, "-");

int index = Random.Shared.Next(fullText.Length);
string preguestLetter = fullText[index].ToString();
int start = 0;
while (true)
{
    int i = fullText.IndexOf(preguestLetter, start);
    if (i == -1)
    {
        break;
    }

    knownLetters[i] = preguestLetter;
    start = i + 1;
}

string knownText = string.Join(string.Empty, knownLetters);

while (lives > 0 && knownText != fullText)
{
    Console.WriteLine($"Known text: {knownText}");
    Console.WriteLine("Guess a letter:");
    string letter = Console.ReadLine() ?? string.Empty;

    if (fullText.Contains(letter, StringComparison.CurrentCultureIgnoreCase))
    {
        for (int i = 0; i < knownLetters.Length; i++)
        {
            if (knownLetters[i] == "-")
            {
                if (string.Equals(fullText[i].ToString(), letter, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Tak, ta litera znajduje się w tekście!");
                    knownLetters[i] = fullText[i].ToString();
                }
            }
        }
        knownText = string.Join(string.Empty, knownLetters);
    }
    else
    {
        Console.WriteLine("Litera, której szukasz jest w innym zamku");
        lives -= 1;
    }
}

if (lives > 0)
{
    Console.WriteLine($"Tak, tekst to {knownText}");
}
else
{
    Console.WriteLine($"Starałeś się starałeś, a i tak przegrałeś. Poprawny tekst to {fullText}");
}