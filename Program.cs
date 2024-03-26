using System.Text;

class KanjiNumberQuiz
{
  // The basic 0-9 kanji numbers.
  static readonly Dictionary<int, string> kanjiList = new()
  {
      { 0, "零" },
      { 1, "一" },
      { 2, "二" },
      { 3, "三" },
      { 4, "四" },
      { 5, "五" },
      { 6, "六" },
      { 7, "七" },
      { 8, "八" },
      { 9, "九" },
      {10, "十" },
      {100, "百"},
      {1000, "千"},
  };
  static void Main()
  {
    

    // Sets console encoding so it can understand japanese characters.
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
    int score = 0;

    

    Random rnd = new(); // New Random Number object.
    int number = rnd.Next(1000); // New random number between 0 and 1000 (0-999 inc).
    // number = 44;

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
    Console.ReadLine();
  


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
    // If there is a specific entry in the kanji list, return early with that kanji
    if(kanjiList.ContainsKey(num)) return kanjiList.GetValueOrDefault(num);

    // new sting variable for containing the built output string
    string? s = string.Empty;
    int remainder, quotient;

    // Do we have any hundreds values?
    quotient = Math.DivRem(num, 100, out remainder);
    if (quotient > 0)
    {
      s += kanjiList.GetValueOrDefault(quotient) + kanjiList.GetValueOrDefault(100);
      num = remainder;
    }

    // Do we have any tens values?
    quotient = Math.DivRem(num, 10, out remainder);
    if (quotient > 0)
    {
      s += kanjiList.GetValueOrDefault(quotient) + kanjiList.GetValueOrDefault(10);
      num = remainder;
    }

    // Add the final number unless it is a 0
    s += num == 0 ? string.Empty : kanjiList.GetValueOrDefault(num);

    return s;
  }
}