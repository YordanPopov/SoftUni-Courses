import { orderService } from "../OrderService.js";
import { expect } from "chai";

describe("orderService Tests", function () {
    let orders = [];
    const invalidOrder = { id: 1, product: "Invalid product" };
    const updatedOrder = { id: "11", product: "Updated product", amount: 1 };

    beforeEach(() => {
        orders = orderService.getOrders().data;
    });
    describe("getOrders()", () => {
        it("Should return all orders with status 200", () => {
            const response = orderService.getOrders();

            expect(response.status).to.equal(200, "response is not equal to 200");
            expect(response.data).to.be.an("array").that.have.lengthOf(3);
            for (let index = 0; index < response.data.length; index++) {
                expect(response.data[index]).to.have.keys("id", "product", "amount");
            }
        });
    });

    describe("createOrder()", () => {
        it("Should successfully create a new order", () => {
            const newOrder = { id: "4", product: "PC", amount: 10 };

            const response = orderService.createOrder(newOrder);

            expect(response.status).to.equal(201);
            expect(response.message).to.equal("Order created successfully.");
            expect(orders).to.deep.include(newOrder);
        });

        it("Should return an error for invalid order data", () => {
            const response = orderService.createOrder(invalidOrder);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Order Data!");
            expect(orders).to.not.deep.include(invalidOrder);
        });
    });

    describe('cancelOrder()', () => {
        it("Should cancel an order by id successfully", () => {
            const order = { id: "10", product: "Test", amount: 1111 };

            orderService.createOrder(order);
            const response = orderService.cancelOrder("10");

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Order canceled successfully.");
            expect(orders).to.not.deep.include(order);
        });

        it("Should return status 404 for a non-existing order id", () => {
            const response = orderService.cancelOrder("1111");

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Order Not Found!");
        });
    });

    describe("updateOrder()", () => {
        it("Should update an existing order successfully", () => {
            const response = orderService.updateOrder("1", updatedOrder);

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Order updated successfully.")
            expect(orders).to.deep.include(updatedOrder);
        });

        it("Should return an error if the order to update does not exist ", () => {
            const response = orderService.updateOrder("99", updatedOrder);

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Order Not Found!");
        });

        it("Should return an error id the order data is invalid", () => {
            const response = orderService.updateOrder("2", invalidOrder);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Order Data!");
        });
    });

    describe("getOrderById()", () => {
        it("Should return an order by id successfully", () => {
            const response = orderService.getOrderById("2");

            expect(response.status).to.equal(200);
            expect(response.data).to.deep.include({ id: "2", product: "Phone", amount: 800 });
        });

        it("Should return status 404 for a non-existing order id", () => {
            const response = orderService.getOrderById("222");

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Order Not Found!");
        });
    });
});