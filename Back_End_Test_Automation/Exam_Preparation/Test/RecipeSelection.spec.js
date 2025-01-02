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
                { type: "object", dietaryRestriction: {} },
                { type: "undefined", dietaryRestriction: undefined }
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
                { type: {}, dietaryRestriction: "object" },
                { type: undefined, dietaryRestriction: "undefined" }
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

        it("Should return correct message, when dietaryRestriction is 'Vegan' and type is 'Meat or Dairy'.", () => {
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
        it("Should throw an error, when price is not a number.", () => {
            const invalidCases = [
                { price: "", budget: 100 },
                { price: true, budget: 100 },
                { price: [100], budget: 100 },
                { price: {}, budget: 100 },
                { price: "100", budget: 100 },
                { price: undefined, budget: 100 }
            ];

            invalidCases.forEach(({ price, budget }) => {
                expect(() => recipeSelection.isItAffordable(price, budget)).to.Throw("Invalid input");
            });
        });

        it("Should throw an error, when budget is not a number.", () => {
            const invalidCases = [
                { price: 100, budget: "" },
                { price: 100, budget: true },
                { price: 100, budget: [100] },
                { price: 100, budget: {} },
                { price: 100, budget: "100" },
                { price: 100, budget: undefined }
            ];

            invalidCases.forEach(({ price, budget }) => {
                expect(() => recipeSelection.isItAffordable(price, budget)).to.Throw("Invalid input");
            });
        });

        it("Should return correct message, whem budget is not enough.", () => {
            const expectedMsg = "You don't have enough budget to afford this recipe";
            const validCases = [
                { price: 100, budget: 99 },
                { price: 100, budget: 50 },
                { price: 100, budget: -1 },
                { price: 100, budget: 0 }
            ];

            validCases.forEach(({ price, budget }) => {
                expect(recipeSelection.isItAffordable(price, budget)).to.eq(expectedMsg);
            });
        });

        it("Should return correct message, when budget is enough.", () => {
            const validCases = [
                { price: 100, budget: 101 },
                { price: 100, budget: 100.01 },
                { price: 100, budget: 100 },
                { price: 100, budget: 1000 }
            ];

            validCases.forEach(({ price, budget }) => {
                expect(recipeSelection.isItAffordable(price, budget))
                    .to.eq(`Recipe ingredients bought. You have ${budget - price}$ left`);
            });
        });
    });

    describe("getRecipesByCategory() tests", () => {
        it("Should throw an error, when recipes is not an array.", () => {
            const invalidCases = [
                { recipes: 100, category: "foo" },
                { recipes: true, category: "foo" },
                { recipes: "['bar']", category: "foo" },
                { recipes: {}, category: "foo" },
                { recipes: undefined, category: "foo" },
            ];

            invalidCases.forEach(({ recipes, category }) => {
                expect(() => recipeSelection.getRecipesByCategory(recipes, category))
                    .to.throw("Invalid input");
            });
        });

        it("Should throw an error, when category is not a string", () => {
            const recipes = [
                { title: "foo", category: "bar" },
                { title: "boo", category: "far" },
                { title: "hoo", category: "bar" }
            ];
            const invalidCases = [
                { recipes: recipes, category: 1 },
                { recipes: recipes, category: true },
                { recipes: recipes, category: NaN },
                { recipes: recipes, category: [] },
                { recipes: recipes, category: {} },
                { recipes: recipes, category: undefined }
            ];

            invalidCases.forEach(({ recipes, category }) => {
                expect(() => recipeSelection.getRecipesByCategory(recipes, category))
                    .to.throw("Invalid input");
            });
        });

        it("Should return an array with valid titles", () => {
            const recipes = [
                { title: "foo", category: "bar" },
                { title: "boo", category: "far" },
                { title: "hoo", category: "bar" }
            ];

            let actualResult = recipeSelection.getRecipesByCategory(recipes, "bar");

            expect(actualResult).to.be.an("array").that.have.lengthOf(2);
            expect(actualResult[0]).to.eq("foo");
            expect(actualResult[actualResult.length - 1]).to.eq("hoo");
        });

        it("Should return empty array, when category does not match", () => {
            const recipes = [
                { title: "foo", category: "bar" },
                { title: "boo", category: "far" },
                { title: "hoo", category: "bar" }
            ];
            const nonExistentCategory = "non-existent";

            let result = recipeSelection.getRecipesByCategory(recipes, nonExistentCategory);

            expect(result).to.be.an("array").that.is.empty;
        });
    });
});