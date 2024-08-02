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
      {10000, "万"},
  };
  static void Main()
  {
    // Sets console encoding so it can understand japanese characters.
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;

    while (true)
    {
      Console.WriteLine("Select a Quiz mode");
      Console.WriteLine("[ normal ]   [ romaji ]   [ reverse ]");
      string command = (Console.ReadLine() ?? string.Empty).ToLower();
      if (command == "exit") break;
      switch (command)
      {
        case "normal":
          NewGame(10, 1001);
          break;
        case "romaji":
          
          break;
        case "reverse":
          break;
        case "help":
            // continue to default
        default:
          // exits switch statement if no command is matched.
          Console.WriteLine("Command List:");
          Console.WriteLine("help:        Shows this help screen.");
          Console.WriteLine("normal:      Starts a new quiz");
          Console.WriteLine("romaji:      Loads library from disk.");
          Console.WriteLine("reverse:     Saves library to disk");
          Console.WriteLine("exit:        Exits the program.");
          break;
      }
    }
  }

  /// <summary>
  /// Returns a complete answer string in Kanji for the provided number.
  /// </summary>
  /// <param name="num"></param>
  /// <returns></returns＞
  public static string? GetAnswer(int num)
  {
    // If there is a specific entry in the kanji list, return early with that kanji
    if(kanjiList.ContainsKey(num))
    {
      // For numbers greater than ten thousand, prepend "一"(ichi) as this is how Japanese works.
      return (num >= 10000) ? "一" + kanjiList.GetValueOrDefault(num) : kanjiList.GetValueOrDefault(num);
    }

    // new sting variable for containing the built output string
    string? s = string.Empty;
    int remainder, quotient;

    //　iterate through units to build kanji string
    int[] units = [ 1000, 100, 10 ];
    foreach (int unit in units)
    {
      quotient = Math.DivRem(num, unit, out remainder);
      if (quotient > 0)
      {
        s += (quotient == 1) ? kanjiList.GetValueOrDefault(unit) : kanjiList.GetValueOrDefault(quotient) + kanjiList.GetValueOrDefault(unit);
      }
      num = remainder;
    }

    

    // Add the final number unless it is a 0
    s += num == 0 ? string.Empty : kanjiList.GetValueOrDefault(num);

    return s;
  }

  /// <summary>
  /// Starts a new quiz game with a specified number of rounds up to a maximum number.
  /// </summary>
  /// <param name="rounds">The number of questions to be asked</param>
  /// <param name="max">The maximum number that will be displayed.</param>
  public static void NewGame(int rounds, int max = 1001)
  {
    // New Random Number object.
    Random rnd = new();
    // Initialise Score
    int number, score = 0;
    // List of asked questions
    int[] q = new int[rounds];

    for (int i = 0; i < rounds; i++)
    {
      // Generate a new number until number is a value not in q.
      // Add number to q array at the index of the current question.
      do
      {
        number = rnd.Next(max); // New random number between 0 and 'max' (0 to (max-1) inc).
      } while (q.Contains(number)); q[i] = number;
      
      Console.WriteLine($"Question {i+1}:");
      Console.WriteLine($"Write the kanji for {number}");

      // Get player response and answer
      string? response = Console.ReadLine();
      string? answer = GetAnswer(number);

      // Compare player response to answer
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
      Console.WriteLine("Press enter to continue");
      Console.ReadLine();
    }
    Console.WriteLine($"And that's the game! You scored {score}/{rounds}");
  }
}