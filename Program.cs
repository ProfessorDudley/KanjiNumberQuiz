using System.Text;

class KanjiNumberQuiz
{
  static void Main()
  {
    // Sets console encoding so it can understand japanese characters.
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
    int score = 0;

    Dictionary<int, string> kanjiList = new()
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

    Random rnd = new(); // New Random Number object.
    int number = rnd.Next(11); // New random number between 0 and 11 (0-10 inc).

    Console.WriteLine($"Write the kanji for {number}");

    string? response = Console.ReadLine();
    string? answer = kanjiList.GetValueOrDefault(number);
    if (response == answer)
    {
      Console.WriteLine("Correct!");
    Console.WriteLine($"{number} is {answer}.");
      score++;
    }
    else
    {
      Console.WriteLine("Incorrect");
    Console.WriteLine($"{number} is actually {answer}.");
      
    }


    // while (true)
    // {
    //   Console.Write(">>> ");
    //   string command = (Console.ReadLine() ?? string.Empty).ToLower();
    //   if (command == "exit") break;
    // }
  }
}