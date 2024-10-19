import { it } from "mocha";
import { gameService } from "../Games.js";
import { expect } from "chai";

describe("gameService Tests", function () {
    let games = [];
    const updatedGame = {
        id: "888",
        title: "God of War Updated",
        genre: "Action-adventure",
        year: 2018,
        developer: "Santa Monica Studio",
        description: "An action-adventure game set in Norse mythology."
    };

    const invalidGame = {
        id: '998',
        name: 'Invalid Game'
    };

    beforeEach(() => {
        games = gameService.getGames().data;
    });

    describe("getGames()", function () {
        it('Should return a successful response with a list of games', () => {
            const response = gameService.getGames();

            // 1. Verify the response status is 200.
            expect(response.status).to.equal(200);

            // 2. Ensure the data is an array with a length of 3.
            expect(response.data).to.be.an('array').that.has.lengthOf(3);

            // 3. Check that the first game includes the required keys: 'id', 'title', 'genre', 'year', 'developer', 'description'.
            expect(response.data[0]).to.have.keys('id', 'title', 'genre', 'year', 'developer', 'description');
        });
    });

    describe("addGame()", function () {
        it('Should add a new game successfully', () => {
            // 1. Create a valid new game object.
            const newGame = {
                id: '100',
                title: 'Cyberpunk 2077',
                genre: 'RPG',
                year: 2020,
                developer: 'CD Projekt Red',
                description: 'An open-world, action-adventure RPG set in the dystopian Night City, where players take on the role of V, a mercenary with cybernetic enhancements.'
            };

            const response = gameService.addGame(newGame);

            // 2. Verify the response status is 201 and the success message is correct.
            expect(response.status).to.equal(201);
            expect(response.message).to.equal('Game added successfully.');

            // 3. Check that the newly added game appears in the game list.
            expect(games).to.deep.include(newGame);
        });

        it('Should return an error for invalid game data', () => {
            const response = gameService.addGame(invalidGame);

            // 2. Check that the response status is 400 and the error message is "Invalid Game Data!".
            expect(response.status).to.equal(400);
            expect(response.error).to.equal('Invalid Game Data!');
        });
    });

    describe("deleteGame()", function () {
        it('Should delete an existing game by ID', () => {
            // 1. Delete a game by its ID.
            const deletedGame = {
                id: "200",
                title: "Red Dead Redemption 2",
                genre: "Action-Adventure",
                year: 2018,
                developer: "Rockstar Games",
                description: "A sprawling open-world action-adventure game set in the American Wild West, where players follow the story of Arthur Morgan, an outlaw trying to survive in a rapidly changing world."
            };

            gameService.addGame(deletedGame);
            const response = gameService.deleteGame('200');

            // 2. Verify the response status is 200 and the success message is correct.
            expect(response.status).to.equal(200);
            expect(response.message).to.equal('Game deleted successfully.');

            // 3. Ensure the game is successfully removed from the list.
            expect(games).to.not.deep.include(deletedGame);
        });

        it('Should return an error if the game is not found', () => {
            // 1. Attempt to delete a game with a non-existent ID.
            const response = gameService.deleteGame('999');

            // 2. Check that the response status is 404 and the error message is "Game Not Found!".
            expect(response.status).to.equal(404);
            expect(response.error).to.equal('Game Not Found!');
        });

    });

    describe("updateGame()", function () {
        it('Should update an existing game with new data', () => {
            const response = gameService.updateGame('2', updatedGame);

            // 2. Verify the response status is 200 and the success message is correct.
            expect(response.status).to.equal(200);
            expect(response.message).to.equal('Game updated successfully.');

            // 3. Ensure the updated game is reflected in the game list.
            expect(games).to.deep.include(updatedGame);
        });

        it('Should return an error if the game to update is not found', () => {
            const response = gameService.updateGame('444', updatedGame);

            // 2. Check that the response status is 404 and the error message is "Game Not Found!".
            expect(response.status).to.equal(404);
            expect(response.error).to.equal('Game Not Found!');
        });

        it('Should return an error if the new game data is invalid', () => {
            const response = gameService.updateGame('1', invalidGame);

            // 2. Check that the response status is 400 and the error message is "Invalid Game Data!".
            expect(response.status).to.equal(400);
            expect(response.error).to.equal('Invalid Game Data!');
        });
    });
});