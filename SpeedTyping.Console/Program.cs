void HandleLine(string line, ref bool exit)
{
    Console.Clear();
    string nextPhrase = line;
    string enteredLine = "";
    Console.WriteLine(nextPhrase);

    int enteredCharactersCount = 0;

    while (enteredCharactersCount != nextPhrase.Length)
    {
        enteredCharactersCount = enteredLine.Length;

        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Escape || (key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control))
        {
            exit = true;
            break;
        }

        if (key.Key == ConsoleKey.Backspace)
        {
            if (enteredLine.Length > 0)
            {
                enteredLine = enteredLine.Substring(0, enteredLine.Length - 1);
                enteredCharactersCount -= 1;
            }
            continue;
        }

        if (char.IsLetterOrDigit(key.KeyChar) || char.IsPunctuation(key.KeyChar) || char.IsWhiteSpace(key.KeyChar))
        {
            if (nextPhrase[enteredCharactersCount] != key.KeyChar)
            {
                Console.Beep();
            }
            else
            {
                enteredCharactersCount += 1;
                Console.ForegroundColor = ConsoleColor.Green;
                enteredLine += key.KeyChar;
                Console.Write(key.KeyChar);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

bool exit = false;
Console.TreatControlCAsInput = true;
string path = "Poems.txt";
var poem = File.ReadAllLines(path);
int count = 0;

while (count < poem.Length && !exit)
{
    var s = poem[count];
    HandleLine(s, ref exit);    
    count++;
}
