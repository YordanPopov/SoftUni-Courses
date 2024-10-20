import { it } from "mocha";
import { bookService } from "../BookService2.js";
import { expect } from "chai";

describe("Book Service Tests", function () {
    let books = [];
    const invalidBook = { id: "0", title: "Tester" };
    const updatedBook = { id: "1", title: "1984", author: "Updated Author", year: 1949, genre: "Dystopian" }

    beforeEach(() => {
        books = bookService.getBooks().data;
    });

    describe("getBooks()", function () {
        it("Should return a status 200 and an array of books", () => {
            const response = bookService.getBooks();

            expect(response.status).to.equal(200);
            expect(response.data).to.be.an("array").that.have.lengthOf(3);
            expect(response.data[0]).to.have.keys("id", "title", "author", "year", "genre");
        });
    });

    describe("addBook()", function () {
        it("Should add a new book successfully", () => {
            const newBook = {
                id: "4",
                title: "Carrie",
                author: "Stephen King",
                year: 1974,
                genre: "Classic"
            };

            const response = bookService.addBook(newBook);

            expect(response.status).to.equal(201);
            expect(response.message).to.equal("Book added successfully.");
            expect(books).to.deep.includes(newBook);
        });

        it("Should return status 400 when adding a book with missing fields", () => {
            const response = bookService.addBook(invalidBook);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Book Data!");
        });
    });

    describe("deleteBook()", function () {
        it("Should delete a book by id successfully", () => {
            const bookToBeDeleted = {
                id: "10",
                title: "Carrie",
                author: "Stephen King",
                year: 1974,
                genre: "Classic"
            };

            bookService.addBook(bookToBeDeleted);
            const response = bookService.deleteBook("10");

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Book deleted successfully.");
            expect(books).to.be.an("array").that.have.lengthOf(4);
        });

        it("Should return status 404 when deleting a book with a non-existent id", () => {
            const response = bookService.deleteBook("999");

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Book Not Found!");
        });
    });

    describe("updateBook()", function () {
        it("Should update a book successfully", () => {
            const response = bookService.updateBook("1", updatedBook);

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Book updated successfully.");
            expect(books).to.deep.include(updatedBook);
        });

        it("Test: Should return status 404 when updating a non-existent book", () => {
            const response = bookService.updateBook("11111", updatedBook);

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Book Not Found!")
        });

        it("Should return status 400 when updating with invalid book data", () => {
            const response = bookService.updateBook("2", invalidBook);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Book Data!");
        });
    });
});