using System.Text;

class KanjiNumberQuiz
{
  static void Main()
  {

    // int score = 0;
    Dictionary<int, string> kanjiList = new Dictionary<int, string>
    {
        { 0, "零" },
        { 1, "一" },
        { 2, "に" },
        { 3, "三" },
        { 4, "四" },
        { 5, "五" },
        { 6, "六" },
        { 7, "七" },
        { 8, "八" },
        { 9, "九" },
        { 10, "十" },
    };


    Console.WriteLine(Convert.ToInt32('十'));


    Random rnd = new(); // New Random Number object.
    int number = rnd.Next(11);

    Console.WriteLine($"Write the kanji for {number}");
    byte[] response = Encoding.Unicode.GetBytes(Console.ReadLine().ToString());
    byte[] answer = Encoding.Unicode.GetBytes(kanjiList.GetValueOrDefault<int, string>(number).ToString());
    //Decode
    string r = Encoding.Unicode.GetString(response);
    string a = Encoding.Unicode.GetString(answer);
    Console.WriteLine($"R: {r}, A: {a}");
    if (response == answer)
    {
      Console.WriteLine("Correct!");
      Console.WriteLine($"{number} is {response}!");
      // score++;
    }
    else
    {
      Console.WriteLine("Incorrect");
      Console.WriteLine($"{number} is {answer}");
    }
    Console.ReadLine();


    // while (true)
    // {
    //   Console.Write(">>> ");
    //   string command = (Console.ReadLine() ?? string.Empty).ToLower();
    //   if (command == "exit") break;
    // }
  }

  static void PrintChars(string s)
  {
    Console.WriteLine($"\"{s}\".Length = {s.Length}");
    for (int i = 0; i < s.Length; i++)
    {
      Console.WriteLine($"s[{i}] = '{s[i]}' ('\\u{(int)s[i]:x4}')");
    }
    Console.WriteLine();
  }
}