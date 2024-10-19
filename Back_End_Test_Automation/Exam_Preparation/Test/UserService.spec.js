import { userService } from "../UserService.js";
import { expect } from "chai";

describe("userService Tests", function () {
    let users = [];
    let invalidUser = { id: 2, name: "invalid user" };
    let updatedUser = { id: "12", name: "Updated user", email: "updateduser@test.test" };

    beforeEach(() => {
        users = userService.getUsers().data;
    });

    describe("getUsers()", () => {
        it("Should return all users with status 200", () => {
            const response = userService.getUsers();

            expect(response.status).to.equal(200);
            expect(response.data).to.be.an("array").that.have.lengthOf(3);
            for (let index = 0; index < response.data.length; index++) {
                expect(response.data[index]).to.have.keys("id", "name", "email");
            }
        });
    });

    describe("addUser()", () => {
        it("Should successfully add new user", () => {
            const newUser = { id: "4", name: "New User", email: "newuser@test.test" };

            const response = userService.addUser(newUser);

            expect(response.status).to.equal(201);
            expect(response.message).to.equal("User added successfully.");
            expect(users).to.deep.include(newUser);
        });
        it("Should return error for invalid user data", () => {
            const response = userService.addUser(invalidUser);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid User Data!");
            expect(users).to.not.deep.include(invalidUser);
        });
    });

    describe('deleteUser()', () => {
        it("Should delete an user by id successfully", () => {
            const userForDeleting = { id: "10", name: "Delete this user", email: "Delete@delete.delete" };

            userService.addUser(userForDeleting);
            const response = userService.deleteUser("10", userForDeleting);

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("User deleted successfully.");
            expect(users).to.not.deep.include(userForDeleting);
        });

        it("Should return status 404 for a non-existing user id", () => {
            const response = userService.deleteUser("999");

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("User Not Found!");
        });
    });

    describe("updateUSer()", () => {
        it("Should update an existing user successfully", () => {
            const response = userService.updateUser("2", updatedUser);

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("User updated successfully.");
            expect(users).to.deep.include(updatedUser);
        });

        it("Should return an error if the user to update does not exist", () => {
            const response = userService.updateUser("999", updatedUser);

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("User Not Found!");
        });
        // Test: Should return an error if the movie to update does not exist
        // 1. Attempt to update a movie that doesn't exist.
        // 2. Check if the response status is 404 and the error message is correct.
        it("Should return an error if the user data is invalid", () => {
            const response = userService.updateUser("3", invalidUser);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid User Data!");
        });
    });

    describe("getUserById()", () => {
        it("Should return user by id successfully", () => {
            const responce = userService.getUserById("1");

            expect(responce.status).to.equal(200);
            expect(responce.data).to.deep.include({ id: "1", name: "Alice", email: "alice@example.com" });
        });

        it("Should return status 404 for a non-existing user id", () => {
            const responce = userService.getUserById("999");

            expect(responce.status).to.equal(404);
            expect(responce.error).to.equal("User Not Found!");
        });
    });
});