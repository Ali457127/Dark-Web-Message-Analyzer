List<string> bannedWords = new List<string>(5);
for (int i = 0; i < 5; i++)
{
    Console.Write("Enter a banned word: ");
    string word = (Console.ReadLine() ?? "").ToLower();
    if (string.IsNullOrWhiteSpace(word))
    {
        Console.WriteLine("Please enter a word...");
        i--;
        continue;
    }
    else
    {
        bannedWords.Add(word);
        Console.WriteLine("Word added...");
    }
}

Console.WriteLine("Please enter a long paragraph:");
string paragraph = Console.ReadLine() ?? "";

if (string.IsNullOrEmpty(paragraph)) 
{
    Console.WriteLine("We said a paragraph though :(");
}
else
{
    int shiftKey;
    string cleanParagraph = CleanData(paragraph);
    RiskAnalysis(cleanParagraph, bannedWords);
    
    Console.Write("Enter a shift value: ");
    if (int.TryParse(Console.ReadLine(), out shiftKey))
        EncryptText(cleanParagraph, shiftKey);
    else 
        Console.WriteLine("Please enter a valid value...");
}

// Clean Data
static string CleanData(string text)
{
    string clean = "";
    foreach (char item in text)
    {
        if (char.IsLetter(item) || item == ' ')
        {
            clean += item;
        }
    }
    return clean;
}

// Risk Analysis
static void RiskAnalysis(string text, List<string> list)
{
    int risk = 0;
    string[] totalWords = text.Split(' ');
    foreach (string word in list)
    {
        if (text.Contains(word))
        {
            Console.WriteLine($"Banned Word Found: {word}");
            risk++;
            if ((risk * 100) / totalWords.Length > 20)
                Console.WriteLine("High Risk...");
        }
    }
}

// Encrypt Text
static void EncryptText(string text, int key)
{
    string encryptedText = "";
    char shiftedChar = ' ';
    foreach (char item in text)
    {
        if (char.IsLetter(item) && char.IsUpper(item))
        {
            shiftedChar = (char)(((int)item - 65 + key) % 26 + 65);
            encryptedText += shiftedChar;
        }
        else if (char.IsLower(item))
        {
            shiftedChar = (char)(((int)item - 97 + key) % 26 + 97);
            encryptedText += shiftedChar;
        }
        else
        {
            encryptedText += item;
        }
    }
    Console.WriteLine(encryptedText);
}
