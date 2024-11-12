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
            expect(() => onlineStore.isProductAvailable({ product: "apples" }, 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable(NaN, 1)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable([], 1)).to.throw("Invalid input.");
        });

        it("Should throw an error if not a number for stockQuantity is given", () => {
            expect(() => onlineStore.isProductAvailable('foo', '1')).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', true)).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', [1])).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', { number: 1 })).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', [])).to.throw("Invalid input.");
            expect(() => onlineStore.isProductAvailable('foo', {})).to.throw("Invalid input.");
        });
    });

    describe("canAffordProduct()", () => {
        it("Should return correct message if balance is greater than 0 after purchase", () => {
            let productPrice = 99;
            let balance = 100;
            let expectedMsg = `Product purchased. Your remaining balance is $1.`;

            let response = onlineStore.canAffordProduct(productPrice, balance);

            expect(response).to.be.equal(expectedMsg);
        });

        it("Should return correct message if balance is equal to 0 after purchase", () => {
            let productPrice = 100;
            let balance = 100;
            let expectedMsg = `Product purchased. Your remaining balance is $0.`;

            let response = onlineStore.canAffordProduct(productPrice, balance);

            expect(response).to.be.equal(expectedMsg);
        });

        it("Should return correct message if balance is less than 0 after purchase", () => {
            let productPrice = 101;
            let balance = 100;
            let expectedMsg = "You don't have sufficient funds to buy this product.";

            let response = onlineStore.canAffordProduct(productPrice, balance);

            expect(response).to.be.equal(expectedMsg);
        });

        it("Should throw an error if not a number is given for productPrice parameter", () => {
            expect(() => onlineStore.canAffordProduct(true, 100)).to.throw('Invalid input.');
            expect(() => onlineStore.canAffordProduct('100', 100)).to.throw("Invalid input.");
            expect(() => onlineStore.canAffordProduct([1], 100)).to.throw("Invalid input.");
            expect(() => onlineStore.canAffordProduct({number: 100},100)).to.throw("Invalid input.");
        });

        it("Should throw an error if not a number is given for accountBalance parameter", () => {
            expect(() => onlineStore.canAffordProduct(100, true)).to.throw("Invalid input.");
            expect(() => onlineStore.canAffordProduct(100, '100')).to.throw("Invalid input.");
            expect(() => onlineStore.canAffordProduct(100, [100])).to.throw("Invalid input.");
            expect(() => onlineStore.canAffordProduct(100, {balance: 100})).to.throw("Invalid input.");
        });
    });

    describe("getRecommendedProducts()", () => {
        it("Test", () => {
            expect(true).to.be.true;
        });
    });
});
