function solve([moviesCount, ...movies]) {
    moviesCount = Number(moviesCount);
    let movesCountCopy = moviesCount;
    let maxRating = Number.MIN_SAFE_INTEGER;
    let minRating = Number.MAX_SAFE_INTEGER;
    let maxRatingName = '';
    let minRatingName = '';
    let totalRatingsScore = 0;

    let index = 0;

    while (movesCountCopy > 0) {
        let movieName = movies[index++];
        let movieRating = Number(movies[index++]);

        if (movieRating > maxRating) {
            maxRating = movieRating;
            maxRatingName = movieName;
        }

        if (movieRating < minRating) {
            minRating = movieRating;
            minRatingName = movieName;
        }

        totalRatingsScore += movieRating;
        movesCountCopy--;
    }

    console.log(`${maxRatingName} is with highest rating: ${maxRating.toFixed(1)}`);
    console.log(`${minRatingName} is with lowest rating: ${minRating.toFixed(1)}`);
    console.log(`Average rating: ${(totalRatingsScore / moviesCount).toFixed(1)}`);
}

solve(["5",
    "A Star is Born",
    "7.8",
    "Creed 2",
    "7.3",
    "Mary Poppins",
    "7.2",
    "Vice",
    "7.2",
    "Captain Marvel",
    "7.1"]);
