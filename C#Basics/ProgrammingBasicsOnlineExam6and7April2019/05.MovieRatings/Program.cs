int numberOfMovies = int.Parse(Console.ReadLine());

double highRating = double.MinValue;
double lowRating = double.MaxValue;
double ratingSum = 0.0;
string highRatingFilmName = "";
string lowRatingFilmName = "";

for (int film = 1; film <= numberOfMovies; film++)
{
    string movieName = Console.ReadLine();
    double rating = double.Parse(Console.ReadLine());
    if (rating >= highRating)
    {
        highRating = rating;
        highRatingFilmName = movieName;
    }
    if (rating <= lowRating)
    {
        lowRating = rating;
        lowRatingFilmName = movieName;
    }
    ratingSum += rating;
}

Console.WriteLine($"{highRatingFilmName} is with highest rating: {highRating:f1}");
Console.WriteLine($"{lowRatingFilmName} is with lowest rating: {lowRating}");
Console.WriteLine($"Average rating: {ratingSum / numberOfMovies:f1}");