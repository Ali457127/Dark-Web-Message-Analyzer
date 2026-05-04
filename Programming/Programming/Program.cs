List<string> yasaklikelimeler = new List<string>(5);
for (int i = 0; i < 5; i++)
{
    Console.Write("5 Tane Yasaklı Kelime Yazınız :");
    string kelime = (Console.ReadLine() ?? "").ToLower();
    if (string.IsNullOrWhiteSpace(kelime))
    {
        Console.WriteLine("Lütfen bir kelime giriniz...");
        i--;
        continue;
    }
    else
    {
        yasaklikelimeler.Add(kelime);
        Console.WriteLine("Kelime Eklendi...");
    }
}
Console.WriteLine("Lütfen uzun bir paragraf giriniz;");
string paragraf = Console.ReadLine() ?? "";
if (string.IsNullOrEmpty(paragraf)) Console.WriteLine("Paragraf demiştik ama :(");
else
{
    int guess;
    string temizParagraf = VerileriTemizle(paragraf);
    RiskAnalizi(temizParagraf, yasaklikelimeler);
    Console.Write("Bir değer giriniz :");
    if (int.TryParse(Console.ReadLine(), out guess))
        MetniSifrele(temizParagraf, guess);
    else Console.WriteLine("Bir değer giriniz...");
}
// Verileri Temizle
static string VerileriTemizle(string x)
{
    string temiz = "";
    foreach (char item in x)
    {
        if (char.IsLetter(item) || item == ' ')
        {
            temiz += item;
        }
    }
    return temiz;

}
// RiskAnalizi
static void RiskAnalizi(string y, List<string> liste)
{
    int risk = 0;
    string[] toplam_kelime = y.Split(' ');
    foreach (string i in liste)
    {
        if (y.Contains(i))
        {
            Console.WriteLine($"Yasaklı Kelime Bulundu : {i}");
            risk++;
            if ((risk * 100) / toplam_kelime.Length > 20)
                Console.WriteLine("Yüksek Risk...");
        }
    }

    
}
// Metni Şifrele
static void MetniSifrele(string metin, int anahtar)
{
    string bos = "";
    char kaydirmali = ' ';
    foreach (char item in metin)
    {
        if (char.IsLetter(item) && char.IsUpper(item))
        {
            kaydirmali = (char)(((int)item - 65 + anahtar) % 26 + 65);
            bos += kaydirmali;
        }
        else if (char.IsLower(item))
        {
            kaydirmali = (char)(((int)item - 97 + anahtar) % 26 + 97);
            bos += kaydirmali;
        }
        else
        {
            bos += item;
        }

    }
    Console.WriteLine(bos);
}