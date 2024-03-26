using System.Text;

class KanjiNumberQuiz
{
  // The basic 0-9 kanji numbers.
  static readonly Dictionary<int, string> kanjiList = new()
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
      {10, "十" },
  };
  static void Main()
  {
    

    // Sets console encoding so it can understand japanese characters.
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
    int score = 0;

    

    Random rnd = new(); // New Random Number object.
    int number = rnd.Next(100); // New random number between 0 and 11 (0-10 inc).
    // number = 59;

    Console.WriteLine($"Write the kanji for {number}");

    string? response = Console.ReadLine();
    string? answer = GetAnswer(number);
    if (response == answer)
    {
      Console.Write("Correct! ");
      Console.WriteLine($"{number} is {answer}.");
      score++;
    }
    else
    {
      Console.Write("Incorrect! ");
     Console.WriteLine($"{number} is actually {answer}.");
      
    }


    // while (true)
    // {
    //   Console.Write(">>> ");
    //   string command = (Console.ReadLine() ?? string.Empty).ToLower();
    //   if (command == "exit") break;
    // }
  }

  /// <summary>
  /// Only works for numbers up to 99
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns＞
  public static string? GetAnswer(int num)
  {
    // If there is a specific entry in the kanji list, return early with that kanji.
    if(kanjiList.ContainsKey(num)) return kanjiList.GetValueOrDefault(num);

    string? s = string.Empty;
    int remainder, quotient = Math.DivRem(num, 10, out remainder);
    
    s += kanjiList.GetValueOrDefault(quotient) + kanjiList.GetValueOrDefault(10);
    s += kanjiList.GetValueOrDefault(remainder);

    return s;
  }
}