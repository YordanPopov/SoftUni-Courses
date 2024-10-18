import { describe, it } from "mocha";
import { productService } from "../ProductService.js";
import { expect } from "chai";

describe("movieService Tests", function () {
    let products = [];
    let invalidProduct = { id: 1, name: "invalid product" };
    let updatedProduct = { id: 10, name: "Updated product", price: 100 };

    beforeEach(() => {
        products = productService.getProducts().data;
    });
    describe("getProducts()", () => {
        it("Should return all products with status 200", () => {
            const response = productService.getProducts();

            expect(response.status).to.equal(200);
            expect(response.data).to.be.an("array").that.have.lengthOf(3);
            for (let index = 0; index < response.data.length; index++) {
                expect(response.data[index]).to.have.keys("id", "name", "price");
            }
        });
    });

    describe("addProduct()", () => {
        it("Should successfully add a new product", () => {
            const newProduct = { id: "4", name: "New Product", price: 1000 };

            const response = productService.addProduct(newProduct);

            expect(response.status).to.equal(201);
            expect(response.message).to.equal("Product added successfully.");
            expect(products).to.deep.include(newProduct);
        });

        it("Should return an error for invalid product data", () => {
            const response = productService.addProduct(invalidProduct);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Product Data!");
            expect(products).to.not.deep.include(invalidProduct);
        });
    });

    describe('deleteProduct()', () => {
        it("Should delete a product by id successfully", () => {
            const product = { id: "5", name: "Deleted product", price: -1 };

            productService.addProduct(product);
            const response = productService.deleteProduct("5");

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Product deleted successfully.");
            expect(products).to.not.deep.include(product);
        });

        it("Should return status 404 for a non-existing product id", () => {
            const response = productService.deleteProduct("999");

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Product Not Found!");
        });
    });

    describe("updateProduct()", () => {
        it("Should update an existing product successfully", () => {
            const response = productService.updateProduct("1", updatedProduct);

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Product updated successfully.");
            expect(products).to.deep.include(updatedProduct);
        });

        it("Should return an error if the product to update does not exist", () => {
            const response = productService.updateProduct("99", updatedProduct);

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Product Not Found!");
        });

        it("Should return an error if the product data is invalid", () => {
            const response = productService.updateProduct("3", invalidProduct);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Product Data!");
        });
    });

    describe("getProductById()", function () {
        it("Should return product by id successfully", () => {
            const responce = productService.getProductById("2");

            expect(responce.status).to.equal(200);
            expect(responce.data).to.deep.include({ id: "2", name: "Phone", price: 800 });
        });

        it("Should return status 404 for a non-existing product id", () => {
            const responce = productService.getProductById("999");

            expect(responce.status).to.equal(404);
            expect(responce.error).to.equal("Product Not Found!");
        });
    });
});