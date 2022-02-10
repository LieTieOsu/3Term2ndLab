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

List<Point> path = GetShortestPath(map, starting, finish);
new MapPrinter().Print(map, path);
List<Point> GetShortestPath(string[,] localMap, Point starting, Point finish)
{
	var nearPath = new List<Point> {starting};
	var lastPoint = finish;
	var distance = new Dictionary<Point, int>();
	var origins = new Dictionary<Point, Point>();
	var frontier = new Queue<Point>();
	frontier.Enqueue(starting);
	distance.Add(starting, 0);
	while (frontier.Count != 0)
	{
		var current = frontier.Dequeue();
		var available = FindingPoints(localMap, current);
		foreach (var point in available)
		{
			if (!origins.ContainsKey(point))
			{
				frontier.Enqueue(point);
				origins.Add(point, current);
				if (!distance.ContainsKey(point))
				{
					distance.Add(point, distance[current] + 1);
				}
			}
			else if (origins.ContainsKey(point) && distance[current] + 1 < distance[point])
			{
				origins[point] = current;
			}
		}
		if (current.Equals(finish))
		{
			lastPoint = finish;
			break;
		}
	}

	var length = distance[lastPoint];
	for (var i = 0; i != length; i++)
	{
		nearPath.Add(origins[lastPoint]);
		lastPoint = origins[lastPoint];
	}
	nearPath.Add(finish);
	return nearPath;
}
