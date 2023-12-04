using Day2;

var lines = File.ReadLines("partTwoInput.txt");

var sum = 0;

foreach (var line in lines)
{
    var game = new Day2Game(line);

    // part one
    //if (game.IsValid(12, 14, 13))
    //{
    //    //Console.WriteLine($"{game.ID} is valid");
    //    sum += game.ID;
    //}

    // part two
    sum += game.GetPower();
}

Console.WriteLine(sum);