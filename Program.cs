using System;

class Magic8Ball
{
    static readonly string[] Responses =
    {
        // Positive
        "You better fucking believe it.",
        "Don't be an asshole, of course it is.",
        "Why are you asking such stupid questions? Yes.",
        "Ok I'mseriously wasting time here, right?",
        "It is certain.",
        "It is decidedly so.",
        "Without a doubt.",
        "Yes, definitely.",
        "You may rely on it.",
        "As I see it, yes.",
        "Most likely.",
        "Outlook good.",
        "Yes.",
        "Signs point to yes.",
        // Neutral
        "Reply hazy, try again.",
        "Ask again later.",
        "Better not tell you now.",
        "Cannot predict now.",
        "Concentrate and ask again.",
        // Negative
        "Don't count on it.",
        "My reply is no.",
        "My sources say no.",
        "Outlook not so good.",
        "Very doubtful.",
        "I don't know, go ask someone who is really interested in giving you an answer.",
        "I doubt it, your feet smell awful actually, do you use SOAP or Json?",
        "Your database is so fat it blocks the sun.",



    };

    static readonly Random Rng = new Random();

    static void DrawBall(string response)
    {
        int width = 44;
        string border = new string('*', width);

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine();
        Console.WriteLine("          .·´¯`·.¸¸.·´¯`·.¸¸.·´¯`·.");
        Console.WriteLine("        (                               )");
        Console.WriteLine("       (    ___________________________  )");
        Console.WriteLine("      (    /                           \\  )");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("      |   |         Magic 8 Ball        |   |");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("      (    \\___________________________/  )");
        Console.WriteLine("       (                               )");

        Console.ForegroundColor = ConsoleColor.White;
        string padded = response.PadLeft((width + response.Length) / 2).PadRight(width);
        Console.WriteLine($"        [ {padded.Trim().PadLeft((38 + response.Length) / 2).PadRight(38)} ]");

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("        (                               )");
        Console.WriteLine("          `·.¸¸.·´¯`·.¸¸.·´¯`·.¸¸.·´");
        Console.ResetColor();
        Console.WriteLine();
    }

    static ConsoleColor ResponseColor(string response)
    {
        int idx = Array.IndexOf(Responses, response);
        if (idx < 10)  return ConsoleColor.Green;
        if (idx < 15)  return ConsoleColor.Yellow;
        return ConsoleColor.Red;
    }

    static void Main()
    {
        Console.Title = "Magic 8 Ball";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║          ✦  Virtual Magic 8 Ball  ✦      ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("  Ask a yes/no question, then press ENTER.");
        Console.WriteLine("  Type 'quit' or 'exit' to leave.\n");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  Your question: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (input == null) break;
            input = input.Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n  The Magic 8 Ball has spoken its last. Farewell.\n");
                Console.ResetColor();
                break;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  Please ask a question first.\n");
                Console.ResetColor();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Consulting the mystical forces...");
            System.Threading.Thread.Sleep(1200);
            Console.ResetColor();

            string answer = Responses[Rng.Next(Responses.Length)];

            DrawBall(answer);

            Console.ForegroundColor = ResponseColor(answer);
            Console.WriteLine($"  >> {answer}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
