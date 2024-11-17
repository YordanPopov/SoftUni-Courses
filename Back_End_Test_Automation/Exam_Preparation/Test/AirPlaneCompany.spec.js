import { airplaneService } from "../AirPlaneCompany.js";
import { expect } from "chai";


describe("airplaneService Tests", function () {
    let flights = [];
    const invalidFlight = {
        destination: "Invalid destination",
        status: "Invalid status"
    };
    const newFlight = {
        flightNumber: "TT123",
        destination: "Test city",
        departureTime: "2024-11-17T11:00:00Z",
        status: "Test time"
    };
    const flightToBeDeleted = {
        flightNumber: "Test",
        destination: "Test city",
        departureTime: "2024-11-17T11:00:00Z",
        status: "Test time"
    };
    const updatedFlight = {
        flightNumber: "TTTT",
        destination: "Los Angeles",
        departureTime: "2024-07-27T16:00:00Z",
        status: "Cancelled"
    };

    beforeEach(() => {
        flights = airplaneService.getFlights().data;
    });

    describe("getFlights()", function () {
        it("Should return a list of flights with status 200", () => {
            let response = airplaneService.getFlights();

            expect(response.status).to.equal(200);
            expect(response.data).to.be.an("array").that.have.lengthOf(3);
            expect(response.data[0]).to.have.keys("flightNumber", "destination", "departureTime", "status");
            expect(response.data[1]).to.have.keys("flightNumber", "destination", "departureTime", "status");
            expect(response.data[2]).to.have.keys("flightNumber", "destination", "departureTime", "status");
        });
    });

    describe("addFlight()", function () {
        it("Should add a new flight successfully", () => {
            const response = airplaneService.addFlight(newFlight);

            expect(response.status).to.equal(201);
            expect(response.message).to.equal("Flight added successfully.");
            expect(flights).to.be.an("array").that.have.lengthOf(4);
            expect(flights).to.deep.includes(newFlight);
        });

        it("Should return an error with status 400 for invalid flight data", () => {
            const response = airplaneService.addFlight(invalidFlight);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Flight Data!");
        });
    });

    describe("deleteFlight()", function () {
        it("Should delete an existing flight by flight number", () => {
            airplaneService.addFlight(flightToBeDeleted);
            let response = airplaneService.deleteFlight("Test");

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Flight deleted successfully.");
            expect(flights).to.not.deep.includes(flightToBeDeleted);
        });

        it("Should return an error with status 404 if the flight is not found", () => {
            let response = airplaneService.deleteFlight("*****");

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Flight Not Found!");
        });
    });

    describe("updateFlight()", function () {
        it("Should update an existing flight with new data", () => {
            let response = airplaneService.updateFlight("CA789", updatedFlight);

            expect(response.status).to.equal(200);
            expect(response.message).to.equal("Flight updated successfully.");
            expect(flights).to.deep.includes(updatedFlight);
        });

        it("Should return an error with status 404 if the flight to update is not found", () => {
            let response = airplaneService.updateFlight("*****", updatedFlight);

            expect(response.status).to.equal(404);
            expect(response.error).to.equal("Flight Not Found!");
        });

        it("Should return an error with status 400 if the new flight data is invalid", () => {
            var response = airplaneService.updateFlight("BA456", invalidFlight);

            expect(response.status).to.equal(400);
            expect(response.error).to.equal("Invalid Flight Data!");
        });
    });
});