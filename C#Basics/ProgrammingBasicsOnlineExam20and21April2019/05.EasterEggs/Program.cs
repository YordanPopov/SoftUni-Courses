int eggsNumber = int.Parse(Console.ReadLine());

int redEggs = 0;
int orangeEggs = 0;
int blueEggs = 0;
int greenEggs = 0;
int maxEggs = int.MinValue;
string colourOfEgg = "";

for (int egg = 1; egg <= eggsNumber; egg++)
{
    string eggColour = Console.ReadLine();
	switch (eggColour)
	{
		case "red": redEggs++; break;
		case "orange": orangeEggs++; break;
		case "blue": blueEggs++; break;
		case "green": greenEggs++; break;
		default:
			break;
	}

}

if (redEggs >= maxEggs)
{
	maxEggs = redEggs;
	colourOfEgg = "red";
}
if (orangeEggs >= maxEggs)
{
	maxEggs = orangeEggs;
	colourOfEgg = "orange";
}
if (blueEggs >= maxEggs)
{
	maxEggs = blueEggs;
	colourOfEgg = "blue";
}
if (greenEggs >= maxEggs)
{
	maxEggs = greenEggs;
	colourOfEgg = "green";
}

Console.WriteLine($"Red eggs: {redEggs}");
Console.WriteLine($"Orange eggs: {orangeEggs}");
Console.WriteLine($"Blue eggs: {blueEggs}");
Console.WriteLine($"Green eggs: {greenEggs}");
Console.WriteLine($"Max eggs: {maxEggs} -> {colourOfEgg}");