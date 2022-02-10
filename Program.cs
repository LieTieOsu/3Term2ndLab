using Kse.Algorithms.Samples;


var globalHeight = 18;
var globalWidth = 178;
var generator = new MapGenerator(new MapGeneratorOptions()
{
	Height = globalHeight,
	Width = globalWidth,
});

string[,] map = generator.Generate();
int StartX, StartY;
Console.Write("StartX:");StartX = int.Parse(Console.ReadLine());
Console.Write("StartY:");StartY = int.Parse(Console.ReadLine());
var starting = new Point(StartX, StartY);
var finish = new Point(globalWidth - 2, globalHeight - 2);

List<Point> FindingPoints(string[,] localMap2, Point current)
{
	List<Point> available = new List<Point>();
	if (current.Column - 1 >= 0 && current.Column - 1 <= globalWidth - 1 && current.Row <= globalWidth - 1)
	{
		if (localMap2[current.Column - 1, current.Row] != "█")
		{
			available.Add(new Point(current.Column - 1, current.Row));
		}
	}

	if (current.Column + 1 >= 0 && current.Column + 1 <= globalWidth - 1 && current.Row <= globalWidth - 1)
	{
		if (localMap2[current.Column + 1, current.Row] != "█")
		{
			available.Add(new Point(current.Column + 1, current.Row));
		}
	}
	if ( current.Row - 1 >= 0 && current.Row - 1 <= globalHeight - 1 && current.Column <= globalWidth - 1) 
	{
		if (localMap2[current.Column, current.Row - 1] != "█")
		{
			available.Add(new Point(current.Column, current.Row - 1));
		}
	}

	if (current.Row + 1 >= 0 && current.Row + 1 <= globalHeight - 1 && current.Column <= globalWidth - 1)
	{
		if (localMap2[current.Column, current.Row + 1] != "█")
		{
			available.Add(new Point(current.Column, current.Row + 1));
		}
	}
	return available;
}
