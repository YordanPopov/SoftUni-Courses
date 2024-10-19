import { it } from "mocha";
import { movieService } from "../Movies.js";
import { expect } from "chai";

describe("movieService Tests", function () {
    let movies = [];

    beforeEach(() => {
        movies = movieService.getMovies().data;
    });

    describe("getMovies()", function () {
        it('Should return all movies with status 200', () => {
            const result = movieService.getMovies();

            // 1. Check if the response status is 200.
            expect(result.status).to.equal(200);

            // 2. Ensure the data is an array with a length of 3.
            expect(result.data).to.be.an('array').that.has.lengthOf(3);

            // 3. Verify the first item contains the required keys: 'id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc'.
            expect(result.data[0]).to.have.keys('id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc');
        });
    });

    describe("addMovie()", function () {
        it('Should successfully add a new movie', () => {
            // 1. Create a new movie object with valid data.
            const newMovie = {
                id: '4',
                name: 'Dunkirk',
                genre: 'War',
                year: 2017,
                director: 'Christopher Nolan',
                rating: 7.9,
                duration: 106,
                language: 'English',
                desc: 'Allied soldiers are surrounded by the German Army and evacuated during a fierce battle in World War II.'
            };

            const result = movieService.addMovie(newMovie);

            // 2. Check if the response status is 201 and the success message is correct.
            expect(result.status).to.equal(201);
            expect(result.message).to.equal('Movie added successfully.');

            // 3. Verify that the newly added movie is present in the movie list.
            expect(movies).to.deep.include(newMovie);
        });

        it('Should return an error for invalid movie data', () => {
            // 1. Create a movie object with incomplete or invalid data.
            const incompleteMovie = {
                id: '5',
                name: 'Incomplete movie'
            };

            const invalidDataMovie = {
                id: false,
                name: 0,
                genre: null,
                year: false,
                director: 0,
                rating: '100',
                duration: '106',
                language: 0,
                desc: false
            };

            const resultIncomplateData = movieService.addMovie(incompleteMovie);
            const resultInvalidData = movieService.addMovie(invalidDataMovie);

            // 2. Check if the response status is 400 and the error message is correct.
            expect(resultInvalidData.status).to.equal(400);
            expect(resultIncomplateData.status).to.equal(400);
            expect(resultInvalidData.error).to.equal('Invalid Movie Data!');
            expect(resultIncomplateData.error).to.equal('Invalid Movie Data!');
        });

    });

    describe('deleteMovie()', function () {
        it('Should delete a movie by id successfully', () => {
            // 1. Add a movie to ensure there is one to delete.
            const newMovie = {
                id: '6',
                name: 'Tenet',
                genre: 'Action',
                year: 2020,
                director: 'Christopher Nolan',
                rating: 7.5,
                duration: 150,
                language: 'English',
                desc: 'A secret agent embarks on a dangerous, time-bending mission to prevent the start of World War III.'
            };

            movieService.addMovie(newMovie);
            const result = movieService.deleteMovie('6');

            // 2. Delete the movie by its id and check if the response status is 200.
            expect(result.status).to.equal(200);

            // 3. Verify that the success message is correct.
            expect(result.message).to.equal('Movie deleted successfully.');

            // 4. Ensure that the movie is no longer in the list..
            expect(movies).to.not.deep.include(newMovie);
        });

        it('Should return 404 for a non-existent movie id', () => {
            // 1. Attempt to delete a movie with an id that doesn't exist.
            const result = movieService.deleteMovie('999');

            // 2. Check if the response status is 404 and the error message is correct.
            expect(result.status).to.equal(404);
            expect(result.error).to.equal('Movie Not Found!');
        });
    });

    describe("updateMovie()", function () {
        it('Should update an existing movie successfully', () => {
            // 1. Create an updated movie object with valid data.
            const updatedMovie = {
                id: "2",
                name: "The Matrix Updated",
                genre: "Action",
                year: 1999,
                director: "Lana Wachowski, Lilly Wachowski",
                rating: 8.7,
                duration: 136,
                language: "English",
                desc: "Updated description"    
            };

            const result = movieService.updateMovie('The Matrix', updatedMovie);

            // 2. Update the movie by its name and check if the response status is 200.
            expect(result.status).to.equal(200);

            // 3. Verify that the success message is correct.
            expect(result.message).to.equal('Movie updated successfully.');

            // 4. Ensure that the updated movie is present in the movie list.
            expect(movies).to.deep.include(updatedMovie);
        });

        it('Should return an error if the movie to update does not exist', () => {
            // 1. Attempt to update a movie that doesn't exist.
            const nonExistentdMovie = {
                id: '999',
                name: 'Non-existent Movie',
                genre: 'Drama',
                year: 1990,
                director: 'Someone',
                rating: 1.0,
                duration: 5,
                language: 'Bulgarian',
                desc: 'Description for non-existent Movie'
            };

            const result = movieService.updateMovie('Non-existent Movie', nonExistentdMovie);

            // 2. Check if the response status is 404 and the error message is correct.
            expect(result.status).to.equal(404);
            expect(result.error).to.equal('Movie Not Found!');
        });

        it('Should return an error if the new movie data is invalid', () => {
            // 1. Provide incomplete or invalid data for an existing movie.
            const invalidMovie = {
                id: '999',
                name: 'no-name'
            }

            const result = movieService.updateMovie('Inception', invalidMovie);

            // 2. Check if the response status is 400 and the error message is correct.
            expect(result.status).to.equal(400);
            expect(result.error).to.equal('Invalid Movie Data!');
        });
    });
});