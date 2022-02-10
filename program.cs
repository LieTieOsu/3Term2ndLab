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
