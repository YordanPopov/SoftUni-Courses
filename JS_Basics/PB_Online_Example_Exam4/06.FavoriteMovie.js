function solve(movies) {
    let index = 0;
    let bestMovieName = '';
    let bestMovieScore = 0;

    while (movies[index] !== 'STOP') {
        let movieName = movies[index++];
        let movieScore = 0;

        for (const ch of movieName) {
            if (ch >= 'A' && ch <= 'Z') {
                movieScore += ch.charCodeAt(0) - movieName.length;
            } else if (ch >= 'a' && ch <= 'z') {
                movieScore += ch.charCodeAt(0) - (movieName.length * 2);
            } else {
                movieScore += ch.charCodeAt(0);
            }
        }

        if (movieScore > bestMovieScore) {
            bestMovieScore = movieScore;
            bestMovieName = movieName;
        }

        if (index === 7) {
            console.log('The limit is reached.');
            break;
        }
    }

    console.log(`The best movie for you is ${bestMovieName} with ${bestMovieScore} ASCII sum.`)
}

solve(["Matrix",
    "Breaking bad",
    "Legend",
    "STOP"])


