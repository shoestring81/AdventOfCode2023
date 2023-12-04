using Day3;

var lines = File.ReadLines("partOneInput.txt").ToList();

var numbers = new List<Day3Number>();
var symbols = new List<Day3Symbol>();

for (var i = 0; i < lines.Count(); i++)
{
    var line = lines[i].Trim();

    Day3Number number = null;

    for (var j = 0; j < line.Length; j++)
    {
        var c = line[j];
        if (c == '.')
        {
            if (number != null)
            {
                numbers.Add(number);
                number = null;
            }
        }
        else if (int.TryParse(c.ToString(), out var cInt))
        {
            if (number == null)
                number = new Day3Number { Line = i, NumberString = c.ToString(), StartIndex = j };
            else
                number.NumberString += c.ToString();
        }
        else
        {
            symbols.Add(new Day3Symbol { Index = j, Line = i, Symbol = c });
            if (number != null)
            {
                numbers.Add(number);
                number = null;
            }
        }
    }

    if (number != null) numbers.Add(number);
}

var sum = 0;

foreach (var number in numbers)
{
    var matchingSymbols = symbols.Where(s =>
        s.Line >= number.Line - 1 && s.Line <= number.Line + 1 &&
        s.Index >= number.StartIndex - 1 && s.Index <= number.EndIndex + 1);
    if (matchingSymbols.Any()) sum += number.Number;
}

Console.WriteLine(sum);


var gearSum = 0;

foreach (var symbol in symbols.Where(s => s.Symbol == '*'))
{
    var matchingNumbers = numbers.Where(n =>
        n.Line >= symbol.Line - 1 && n.Line <= symbol.Line + 1 &&
        n.EndIndex >= symbol.Index - 1 && n.StartIndex <= symbol.Index + 1).ToList();
    if (matchingNumbers.Count() == 2) gearSum += matchingNumbers[0].Number * matchingNumbers[1].Number;
}

Console.WriteLine(gearSum);