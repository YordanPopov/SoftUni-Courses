import { petAdoptionAgency } from "../PetAdoptionAgency.js";
import { expect } from "chai";

describe("PetAdoptionAgency Tests", () => {
    describe("isPetAvailable()", () => {
        it("Should return correct message if availableCount is greater than zero and vaccinated parameter is true", () => {
            const expectedResult = "Great! We have 1 vaccinated dog(s) available for adoption at the agency.";

            const actualResult = petAdoptionAgency.isPetAvailable("dog", 1, true);

            expect(actualResult).to.be.equal(expectedResult);
        });

        it("Should return correct message if availableCount is greater than zero and vaccinated parameter is false", () => {
            const expectedResult = "Great! We have 1 dog(s) available for adoption, but they need vaccination.";

            const actualResult = petAdoptionAgency.isPetAvailable("dog", 1, false);

            expect(actualResult).to.be.equal(expectedResult);
        });

        it("Should return correct message if availableCount is less than or equal to zero", () => {
            const expectedResult = "Sorry, there are no dog(s) available for adoption at the agency.";

            expect(petAdoptionAgency.isPetAvailable("dog", 0, true)).to.be.equal(expectedResult);
            expect(petAdoptionAgency.isPetAvailable("dog", -1, true)).to.be.equal(expectedResult);
        });

        it("Should throw an error if not a string is passed for the pet parameter", () => {
            expect(() => petAdoptionAgency.isPetAvailable(1, 1, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable(true, 1, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable([], 1, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable({}, 1, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable(['pet'], 1, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable(undefined, 1, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable(NaN, 1, true)).to.throw("Invalid input");
        });

        it("Should throw an error if not a number is passed for availableCount parameter", () => {
            expect(() => petAdoptionAgency.isPetAvailable("foo", "", true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", "1", true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", true, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", undefined, true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", [1], true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", { number: 1 }, true)).to.throw("Invalid input");
        });

        it("Should throw an error if not a boolean is passed for vaccinated parameter", () => {
            expect(() => petAdoptionAgency.isPetAvailable("foo", 1, 1)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", 1, "true")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", 1, [true])).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", 1, { value: true })).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", 1, undefined)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.isPetAvailable("foo", 1, NaN)).to.throw("Invalid input");
        });
    });

    describe("getRecommendedPets()", () => {
        it("Should return correct message if one match exist", () => {
            const petList = [
                {name: "Buddy", traits: "friendly"},
                {name: "Mittens", traits: "playful"},
            ];

            const expectedResult = "Recommended pets with the desired traits (friendly): Buddy";

            const actualResult = petAdoptionAgency.getRecommendedPets(petList, "friendly");

            expect(actualResult).to.be.equal(expectedResult);
        });

        it("Should return correct message if multiple matches exists", () => {
            const petList = [
                {name: "Buddy", traits: "friendly"},
                {name: "Mittens", traits: "playful"},
                {name: "Whiskers", traits: "friendly"}
            ];

            const expectedResult = "Recommended pets with the desired traits (friendly): Buddy, Whiskers";

            const actualResult = petAdoptionAgency.getRecommendedPets(petList, "friendly");

            expect(actualResult).to.be.equal(expectedResult);
        });

        it("Should return correct message if no match exist", () => {
            const petList = [
                {name: "Buddy", traits: "curious"},
                {name: "Mittens", traits: "playful"},
                {name: "Whiskers", traits: "calm"}
            ];

            const expectedResult = "Sorry, we currently have no recommended pets with the desired traits: friendly.";

            const actualResult = petAdoptionAgency.getRecommendedPets(petList, "friendly");

            expect(actualResult).to.be.equal(expectedResult);
        });

        it("Should throw an error if non an array is passed for the petList", () => {
            expect(() => petAdoptionAgency.getRecommendedPets(true, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets(" ", "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets(NaN, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets(undefined, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets({name: "foo", traits: "bar"}, "test")).to.throw("Invalid input");
        });

        it("Should throw an error if not a string is passed for the desireTraits parameter", () => {
            expect(() => petAdoptionAgency.getRecommendedPets([{name: "foo", traits: "bar"}], true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets([{name: "foo", traits: "bar"}], [])).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets([{name: "foo", traits: "bar"}], {})).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets([{name: "foo", traits: "bar"}], 2415)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.getRecommendedPets([{name: "foo", traits: "bar"}], ["foo"])).to.throw("Invalid input");
        });
    });

    describe("adoptPet()", () => {
        it("Should return correct message, if valid input is given", () => {
            const expectedResult = "Congratulations, TESTER! You have adopted DOG from the agency. Enjoy your time with your new furry friend!";

            const actualResult = petAdoptionAgency.adoptPet("DOG", "TESTER");

            expect(actualResult).to.be.equal(expectedResult);
        });

        it("Should throw an error if not a string is passed for the pet parameter", () => {
            expect(() => petAdoptionAgency.adoptPet(1, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet(true, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet(undefined, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet(NaN, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet(['pet'], "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet({}, "test")).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet([], "test")).to.throw("Invalid input");
        });

        it("Should throw an error if not a string is passed for the adopterName parameter", () => {
            expect(() => petAdoptionAgency.adoptPet("test", 1)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet("test", true)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet("test", [])).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet("test", undefined)).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet("test", {})).to.throw("Invalid input");
            expect(() => petAdoptionAgency.adoptPet("test", ['test'])).to.throw("Invalid input");
        })
    });
});