import { onlineStore } from "../OnlineStore.js";
import { expect } from "chai";

describe("OnlineStore Tests", () => {
    describe("isProductAvailable()", () => {
        it("Should return correct message if a product is an available", () => {
            let product = "apples"
            let expectedMsg = `Great! ${product} is available for purchase.`;

            let response = onlineStore.isProductAvailable(product, 1);

            expect(response).to.be.equal(expectedMsg);
        });

        it("Should return correct message if stockQuantity is negative number", () => {
            let product = "apples"
            let expectedMsg = `Sorry, ${product} is currently out of stock.`;

            let response = onlineStore.isProductAvailable(product, -1);

            expect(response).to.be.equal(expectedMsg);
        });

        it("Should return correct message if stockQuantity is 0", () => {
            let product = "apples"
            let expectedMsg = `Sorry, ${product} is currently out of stock.`;

            let response = onlineStore.isProductAvailable(product, 0);

            expect(response).to.be.equal(expectedMsg);
        });

        it("Should throw an error if not a string for product is given", () => {
            expect(() => onlineStore.isProductAvailable(true, 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable(['foo'], 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable(1111, 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable({product: "apples"}, 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable(NaN, 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable([], 1)).to.throw("Invalid input.");
        });

        it("Should throw an error if not a number for stockQuantity is given", () => {
            expect(() => onlineStore.isProductAvailable('foo', '1')).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', true)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', [1])).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', {number: 1})).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', [])).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', {})).to.throw("Invalid input.");
        });
    });

    describe("canAffordProduct()", () => {
        it("Test", () => {
            expect(true).to.be.true;
        });
    });

    describe("getRecommendedProducts()", () => {
        it("Test", () => {
            expect(true).to.be.true;
        });
    });
});
