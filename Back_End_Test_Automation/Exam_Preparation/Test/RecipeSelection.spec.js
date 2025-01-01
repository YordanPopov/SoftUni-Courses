import { describe } from "mocha";
import { recipeSelection } from "../RecipeSelection.js";
import { expect } from "chai";

describe("recipeSelection tests", () => {
    describe("isTypeSuitable() tests", () => {
        it("Should throw an error, when dietaryRestriction is not a string.", () => {
            const invalidCases = [
                { type: "number", dietaryRestriction: 123 },
                { type: "boolean", dietaryRestriction: true },
                { type: "array", dietaryRestriction: [] },
                { type: "object", dietaryRestriction: {} }
            ];

            invalidCases.forEach(({ type, dietaryRestriction }) => {
                expect(() => recipeSelection.isTypeSuitable(type, dietaryRestriction)).to.throw("Invalid input");
            });
        });

        it("Should throw an error, when type is not a string.", () => {
            const invalidCases = [
                { type: 123, dietaryRestriction: "number" },
                { type: true, dietaryRestriction: "boolean" },
                { type: ["foo"], dietaryRestriction: "array" },
                { type: {}, dietaryRestriction: "object" }
            ];

            invalidCases.forEach(({ type, dietaryRestriction }) => {
                expect(() => recipeSelection.isTypeSuitable(type, dietaryRestriction)).to.throw("Invalid input");
            });
        });

        it("Should return correct message, when 'Meat' and 'Vegetarian' are passed.", () => {
            let expectedMsg = "This recipe is not suitable for vegetarians";

            let actualMsg = recipeSelection.isTypeSuitable("Meat", "Vegetarian");
            expect(actualMsg).to.eq(expectedMsg);
        });

        it("should return correct message, when dietaryRestriction is 'Vegan' and type is 'Meat or Dairy'.", () => {
            let expectedMsg = "This recipe is not suitable for vegans";
            const validTypes = [
                { type: "Meat" },
                { type: "Dairy" }
            ];

            validTypes.forEach(({ type }) => {
                expect(recipeSelection.isTypeSuitable(type, "Vegan")).to.eq(expectedMsg);
            });
        });

        it("Should return correct message, when various inputs are passed.", () => {
            let expectedMsg = "This recipe is suitable for your dietary restriction";
            const validInputs = [
                { type: "bar", dietaryRestriction: "foo" },
                { type: "foo", dietaryRestriction: "bar" },
            ];

            validInputs.forEach(({ type, dietaryRestriction }) => {
                expect(recipeSelection.isTypeSuitable(type, dietaryRestriction)).to.eq(expectedMsg);
            });
        });
    });

    describe("isItAffordable() tests", () => {

    });

    describe("getRecipeByCategory", () => {

    });
});