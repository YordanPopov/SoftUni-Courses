import { planYourTrip } from "../PlanYourTrip.js";
import { expect } from "chai";

describe("PlanYourTrip Tests", () => {
    const destination = "Ski Resort";
    const season = "Winter";

    describe("choosingDestination()", () => {
        it("Should return correct message if season is winter and destination is Ski Resort", () => {
            const expectedMessage = `Great choice! The Winter is the perfect time to visit the Ski Resort.`;

            const result = planYourTrip.choosingDestination(destination, season, 2024);

            expect(result).to.be.equal(expectedMessage);
        });

        it("Should throw error 'Invalid Year!', if year is different than 2024", () => {
            expect(() => planYourTrip.choosingDestination(destination, season, 2023)).to.throw("Invalid Year!");
            expect(() => planYourTrip.choosingDestination(destination, season, 2025)).to.throw("Invalid Year!");
        });

        it("Should throw error message, if destination is different than 'Ski Resort", () => {
            const errorMessage = "This destination is not what you are looking for.";

            expect(() => planYourTrip.choosingDestination("blablabla", season, 2024)).to.throw(errorMessage);
            expect(() => planYourTrip.choosingDestination("Resort Ski", season, 2024)).to.throw(errorMessage);
            expect(() => planYourTrip.choosingDestination("SKI RESORT", season, 2024)).to.throw(errorMessage);
            expect(() => planYourTrip.choosingDestination("ski resort", season, 2024)).to.throw(errorMessage);
            expect(() => planYourTrip.choosingDestination("skiresort", season, 2024)).to.throw(errorMessage);
        });

        it("Should return correct message, if season is different than 'Winter'", () => {
            const expectedMessage = "Consider visiting during the Winter for the best experience at the Ski Resort.";
            const errorSeasons = [
                "winter",
                "summer",
                "autumn",
                "spring",
                "WINTER",
                "WiNtEr",
            ];

            for (const season of errorSeasons) {
                expect(planYourTrip.choosingDestination(destination, season, 2024)).to.be.equal(expectedMessage);
            }
        });
    });

    describe("exploreOptions()", () => {
        it("Should return correct activities, if valid input is given", () => {
            const activities = [
                "Skiing",
                "Snowboarding",
                "Winter Hiking"
            ];

            expect(planYourTrip.exploreOptions(activities, 0)).to.equal("Snowboarding, Winter Hiking");
            expect(planYourTrip.exploreOptions(activities, 1)).to.equal("Skiing, Winter Hiking");
            expect(planYourTrip.exploreOptions(activities, 2)).to.equal("Skiing, Snowboarding");
        });

        it("Should return empty string, if single element array is given", () => {
            expect(planYourTrip.exploreOptions(["Skiing"], 0)).to.be.empty;
        });

        it("Should throw error, if empty array is given", () => {
            expect(() => planYourTrip.exploreOptions([], 0)).to.throw("Invalid Information");
        });

        it("Should throw error message, if non-aray as a parameter is given", () => {
            expect(() => planYourTrip.exploreOptions("['Skiing']", 0)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(true, 0)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(NaN, 0)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(Number, 0)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions({}, 0)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(undefined, 0)).to.throw("Invalid Information");
        });

        it("Should throw error message, if not a number as a parameter is given", () => {
            expect(() => planYourTrip.exploreOptions(["Skiing"], "0")).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing"], true)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing"], undefined)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing"], [0])).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing"], { number: 0 })).to.throw("Invalid Information");
        });

        it("Should throw error message, if index out of range is given", () => {
            expect(() => planYourTrip.exploreOptions(["Skiing", "Snowboarding"], 2)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing", "Snowboarding"], 3)).to.throw("Invalid Information");
        });

        it("Should throw error message, if negative number for an index is given", () => {
            expect(() => planYourTrip.exploreOptions(["Skiing", "Snowboarding"], -2)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing", "Snowboarding"], -1)).to.throw("Invalid Information");
        });

        it("Should throw error message, if decimal number for an index is given", () => {
            expect(() => planYourTrip.exploreOptions(["Skiing", "Snowboarding"], 0.5)).to.throw("Invalid Information");
            expect(() => planYourTrip.exploreOptions(["Skiing", "Snowboarding"], 1.5)).to.throw("Invalid Information");
        });
    });

    describe("estimateExpenses()", () => {
        it("Should return correct message, if total cost is less than or equal $500", () => {
            expect(planYourTrip.estimateExpenses(250, 2)).to.be.equal("The trip is budget-friendly, estimated cost is $500.00.");
            expect(planYourTrip.estimateExpenses(225, 2)).to.be.equal("The trip is budget-friendly, estimated cost is $450.00.");
        });

        it("Should return correct message, if total cost is more than $500", () => {
            expect(planYourTrip.estimateExpenses(251, 2)).to.be.equal("The estimated cost for the trip is $502.00, plan accordingly.");
        });

        it("Should throw error, if not a numbers are given", () => {
            expect(() => planYourTrip.estimateExpenses(true, 2)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(2, true)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses([], 2)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(2, [])).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(undefined, 2)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(2, undefined)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(undefined, undefined)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(true, true)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(2, "2")).to.throw("Invalid Information!");
        });

        it("Should throw error if negative numbers are given", () => {
            expect(() => planYourTrip.estimateExpenses(-1, 2)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(1, -2)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(-2, -2)).to.throw("Invalid Information!");
        });

        it("Should throw error if zero as a parameter is given", () => {
            expect(() => planYourTrip.estimateExpenses(0, 2)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(1, 0)).to.throw("Invalid Information!");
            expect(() => planYourTrip.estimateExpenses(0, 0)).to.throw("Invalid Information!");
        });
    });
}); 