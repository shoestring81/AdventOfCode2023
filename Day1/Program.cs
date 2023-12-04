using Day1;

var lines = File.ReadLines("prodInput2.txt");

var sum = 0;

foreach (var line in lines)
{
    var line1 = DayOneFunctions.DoNumberThing(line);
    
    var numbersOnly = "";
    foreach (var c in line1)
    {
        if (int.TryParse(c.ToString(), out var cInt))
        {
            numbersOnly += c;
        }
    }

    //Console.WriteLine(line + " - " + line1 + " - " + numbersOnly);
    
    if (numbersOnly.Length > 0)
    {
        var number = numbersOnly[0].ToString() + numbersOnly[^1].ToString();
        // Console.WriteLine(number);
        if (int.TryParse(number, out var nInt))
        {
            sum += nInt;
        }
    }
}

Console.WriteLine(sum);