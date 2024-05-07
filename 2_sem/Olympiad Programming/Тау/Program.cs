class Program
{
    public static void Main()
    {
        string beforetranslate = "rmrpiea srfaa tEo gveproo";

        string[] totranslate = beforetranslate.Split(' ');

        List<string> aftertranslate = new List<string>();

        foreach (var word in totranslate)
        {
            aftertranslate.Add(TranslateWord(word));
        }

        List<string> translate = TranslateFrase(aftertranslate);

        Console.WriteLine("Фраза до перевода: " + beforetranslate);

        Console.Write("Фраза после перевода: ");
        foreach (var word in translate)
        {
            Console.Write(word + " ");
        }
    }

    public static string TranslateWord(string word)
    {
        char[] translateword = new char[word.Length]; int si = ((word.Length + 1) / 2) -1;
        translateword[0] = word[si];

        for (int i = 1, j = 0, k=0; i < translateword.Length; i++)
        {
            if (j == 0) { k++; translateword[i] = word[si - k]; j++; continue; }
            if (j == 1) { translateword[i] = word[si + k]; j--; continue; }
        }

        string newword = new string(translateword);

        return newword;
    }

    public static List<string> TranslateFrase(List<string> Frase)
    {
        List<string> newfrase = new List<string>(); int si = (Frase.Count / 2);
        newfrase.Add(Frase[si]);

        for (int i = 1, j = 0, k = 0; i < Frase.Count; i++)
        {
            if (j == 0) { k++; newfrase.Add(Frase[si - k]); j++; continue; }
            if (j == 1) { newfrase.Add(Frase[si + k]); j--; continue; }
        }

        return newfrase;
    }
}