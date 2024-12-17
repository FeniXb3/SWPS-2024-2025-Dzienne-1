// See https://aka.ms/new-console-template for more information
Console.WriteLine("Jakie słowo ma być odgadnięte?");
string fullText = Console.ReadLine();

Console.WriteLine("Ile szans ma mieć osoba odgadująca?");
// int lives = int.Parse(Console.ReadLine());
// int lives = Convert.ToInt32(Console.ReadLine());
// int lives;
// int.TryParse(Console.ReadLine(), out lives);
if (!int.TryParse(Console.ReadLine(), out int lives))
{
    lives = 3;
    Console.WriteLine($"Niepoprawna wartość, ustalam liczbę szans na {lives}");
}


// Poniższa linijka wywali grę, jeśli uruchomi się ją w Debug Console, dlatego zakomentowałem
// Console.Clear();
string[] knownLetters = new string[fullText.Length];
Array.Fill(knownLetters, "-");

Random rng = new Random();
int index = rng.Next(fullText.Length);
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
    string letter = Console.ReadLine();

    if (fullText.Contains(letter))
    {
        for (int i = 0; i < knownLetters.Length; i++)
        {
            if (knownLetters[i] == "-")
            {
                if (fullText[i].ToString() == letter)
                {
                    Console.WriteLine("Tak, ta litera znajduje się w tekście!");
                    knownLetters[i] = letter;
                }
            }
        }
        knownText = string.Join(string.Empty, knownLetters);
    }
    else
    {
        Console.WriteLine("Litera, której szukasz jest w innym zamku");
        lives -= 1;
        //lives = lives - 1;
        // lives--;
    }

    // if (lives <= 0)
    // {
    //     break;
    // }
}

if (lives > 0)
{
    Console.WriteLine($"Tak, tekst to {knownText}");
}
else
{
    Console.WriteLine($"Starałeś się starałeś, a i tak przegrałeś. Poprawny tekst to {fullText}");
}