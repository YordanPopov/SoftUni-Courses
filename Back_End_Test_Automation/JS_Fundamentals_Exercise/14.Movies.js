function printMovies(commands){
    let movies = [];

    commands.forEach(command => {
        if (command.startsWith("addMovie ")) {
            // Extract the movie name and add it to the movies array
            let movieName = command.substring(9);
            movies.push({ name: movieName });
        } else if (command.includes(" directedBy ")) {
            // Extract the movie name and director, then add the director if the movie exists
            let [movieName, director] = command.split(" directedBy ");
            let movie = movies.find(m => m.name === movieName);
            if (movie) {
                movie.director = director;
            }
        } else if (command.includes(" onDate ")) {
            // Extract the movie name and date, then add the date if the movie exists
            let [movieName, date] = command.split(" onDate ");
            let movie = movies.find(m => m.name === movieName);
            if (movie) {
                movie.date = date;
            }
        }
    });

    movies
        .filter(movie => movie.name && movie.director && movie.date)
        .forEach(movie => console.log(JSON.stringify(movie)));
}

printMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);

printMovies([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
    ]);