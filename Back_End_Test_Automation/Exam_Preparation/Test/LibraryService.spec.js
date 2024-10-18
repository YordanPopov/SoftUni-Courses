import { it } from "mocha";
import { libraryService } from "../LibraryService.js";
import { expect } from "chai";

describe("libraryService Tests", () => {
    let libraries = [];
    let invalidLibrary = { id: "0", name: "Test" },
        updatedLibrary = { id: "5", name: "Test", location: "Test" };

    beforeEach(() => {
        libraries = libraryService.getLibraries().data;
    });

    describe("getLibraries()", () => {
        it("Should return all libraries with status 200", () => {
            const result = libraryService.getLibraries();

            expect(result.status).to.equal(200);
            expect(result.data).to.be.an('array').that.have.lengthOf(3);
            expect(result.data[0]).to.have.keys('id', 'name', 'location');
        });
    });

    describe("addLibrary()", () => {
        it("Should successfully add a new library", () => {
            const newLibrary = {
                id: "4",
                name: "Test",
                location: "Test"
            };

            const result = libraryService.addLibrary(newLibrary);

            expect(result.status).to.equal(201);
            expect(result.message).to.equal("Library added successfully.");
            expect(libraries).to.deep.include(newLibrary);
        });

        it("Should return an error for invalid library data", () => {
            const result = libraryService.addLibrary(invalidLibrary);

            expect(result.status).to.equal(400);
            expect(result.error).to.equal("Invalid Library Data!");
            expect(libraries).to.not.deep.include(invalidLibrary);
        });
    });

    describe('deleteLibrary()', () => {
        it("Should delete a library by id successfully", () => {
            const libraryToBeDeleted = {
                id: "5",
                name: "Test",
                location: "Test"
            };

            libraryService.addLibrary(libraryToBeDeleted);
            const result = libraryService.deleteLibrary("5");

            expect(result.status).to.equal(200);
            expect(result.message).to.equal("Library deleted successfully.");
            expect(libraries).to.not.deep.include(libraryToBeDeleted);
        });
        it("Should return 404 for a non-existent library id", () => {
            const result = libraryService.deleteLibrary("999");

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Library Not Found!");
        });
    });

    describe("updateLibrary()", () => {
        it("Should update an existing library successfully", () => {
            const result = libraryService.updateLibrary("4", updatedLibrary);

            expect(result.status).to.equal(200);
            expect(result.message).to.equal("Library updated successfully.");
            expect(libraries).to.deep.include(updatedLibrary);
        });
        it("Should return an error if the library to update does not exist", () => {
            const result = libraryService.updateLibrary("999", updatedLibrary);

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Library Not Found!");
        });
        it("Should return an error if the new library data is invalid", () => {
            const result = libraryService.updateLibrary("1", invalidLibrary);

            expect(result.status).to.equal(400);
            expect(result.error).to.equal("Invalid Library Data!");
        });
    });

    describe("getLibraryById()", () => {
        it("Should return a library by id successfully", () => {
            const result = libraryService.getLibraryById("1");

            expect(result.status).to.equal(200);
            expect(result.data).to.deep.include(libraries[0]);
        });

        it("Should return status 404 for a non-existing library id", () => {
            const result = libraryService.getLibraryById("999");

            expect(result.status).to.equal(404);
            expect(result.error).to.equal("Library Not Found!");
        });
    });
});