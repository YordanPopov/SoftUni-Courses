import { describe, it } from "mocha";
import { bookService } from "../BookService.js";
import { expect } from "chai";

describe("bookService Tests", () => {
    let books = [];

    beforeEach(() => {
        books = bookService.getBooks().data;
    });

    describe("getBooks()", () => {
        it("Should return all books with status 200", () => {
            const result = bookService.getBooks();

            expect(result.status).to.equal(200);
            expect(result.data).to.be.an('array').that.has.lengthOf(3);
            expect(result.data[0]).to.have.keys("id", "title", "author", "year");
        });
    });

    describe("addBook()", () => {
        it("Should successfully add a new book", () => {
            const newBook = {
                id: "4",
                title: "Carrie",
                author: "Stephen King",
                year: 1974
            };

            const result = bookService.addBook(newBook);

            expect(result.status).to.equal(201);
            expect(result.message).to.equal("Book added successfully.");
            expect(books).to.deep.include(newBook);
        });

        it("Should return an error for invalid book data", () => {
            const invalidBook = {
                id: "5",
                year: 2022
            };

            const result = bookService.addBook(invalidBook);

            expect(result.status).to.equal(400);
            expect(result.error).to.equal("Invalid Book Data!");
            expect(books).to.not.deep.include(invalidBook);
        });
    });

    describe("deleteBook()", () => {
        it("Should delete a book by id successfully", () => {
            const bookToBeDeleted = {
                id: "5",
                title: "The shining",
                author: "Stephen King",
                year: 1977
            };

            bookService.addBook(bookToBeDeleted)
            const result = bookService.deleteBook("5");

            expect(result.status).to.equal(200);
            expect(result.message).to.equal("Book deleted successfully.");
            expect(books).to.not.deep.include(bookToBeDeleted);
        });

        it("Should return status 404 for a non-existing book id", () => {
            const result = bookService.deleteBook("-1");

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Book Not Found!");
        });
    });

    describe("updateBook()", () => {
        it("Should update an existing book successfully", () => {
            const updatedBook = {
                id: "5",
                title: "The shining",
                author: "Stephen King",
                year: 1977
            };

            const result = bookService.updateBook("1", updatedBook);

            expect(result.status).to.equal(200);
            expect(result.message).to.equal("Book updated successfully.");
            expect(books).to.deep.include(updatedBook);
        });

        it("Should return an error if the book to update does not exist", () => {
            const nonExistingBook = {
                id: "5",
                title: "The shining",
                author: "Stephen King",
                year: 1977
            };

            const result = bookService.updateBook("999", nonExistingBook);

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Book Not Found!");
        });

        it("Should return an error if the new book data is invalid", () => {
            const invalidBook = {
                id: "0",
                name: "Invalid name",
                year: 0
            }

            const result = bookService.updateBook("2", invalidBook);

            expect(result.status).to.equal(400);
            expect(result.error).to.equal("Invalid Book Data!");
        });
    });

    describe("getBookById()", () => {
        it("Should return a book by id successfully", () => {
            const expectedBook = {
                id: "2",
                title: "To Kill a Mockingbird",
                author: "Harper Lee",
                year: 1960
            };

            const result = bookService.getBookById("2");

            expect(result.status).to.equal(200);
            expect(result.data).to.deep.include(expectedBook);
        });

        it("Should return status 404 for a non-existing book id", () => {
            const result = bookService.getBookById("999");

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Book Not Found!");
        });
    });
});