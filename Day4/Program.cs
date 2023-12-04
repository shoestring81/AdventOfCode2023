var lines = File.ReadLines("partOneInput.txt").ToList();

var scoreValues = new [] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

var totalScore = 0;
var copyCount = new int[lines.Count];

for (var i = 0; i < lines.Count(); i++)
{
    var line = lines[i].Trim();

    copyCount[i] += 1;

    var linesTokens = line.Split('|');

    var winningTokens = linesTokens[0].Split(':')[1].Split(' ');
    var winningNumbers = new List<int>();
    foreach (var token in winningTokens)
        if (int.TryParse(token, out var wInt))
            winningNumbers.Add(wInt);

    var myTokens = linesTokens[1].Split(' ');
    var myNumbers = new List<int>();
    foreach (var token in myTokens)
        if (int.TryParse(token, out var mInt))
            myNumbers.Add(mInt);

    var count = myNumbers.Count(m => winningNumbers.Any(w => w == m));
    if (count > 0)
    {
        totalScore += scoreValues[count - 1];
        for (int j = 0, idx = i + 1; j < count && idx <= copyCount.Length; j++) copyCount[idx++] += copyCount[i];
    }
}

Console.WriteLine(totalScore);
Console.WriteLine(copyCount.Select(x => x).Sum());