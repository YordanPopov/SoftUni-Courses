import { airplaneService } from "../AirPlaneCompany.js";
import { expect } from "chai";


describe("airplaneService Tests", function() {
    describe("getFlights()", function() {
        it("should return a list of flights with status 200", function() {
            const response = airplaneService.getFlights();
            expect(response).to.have.property('status', 200);
            expect(response).to.have.property('data').that.is.an('array').with.lengthOf(3);
            expect(response.data[0]).to.have.all.keys('flightNumber', 'destination', 'departureTime', 'status');
        });
    });

    describe("addFlight()", function() {
        it("should add a new flight successfully", function() {
            const newFlight = { flightNumber: "DA123", destination: "Paris", departureTime: "2024-08-01T09:00:00Z", status: "On Time" };
            const response = airplaneService.addFlight(newFlight);
            expect(response).to.have.property('status', 201);
            expect(response).to.have.property('message', "Flight added successfully.");
            const flights = airplaneService.getFlights().data;
            expect(flights).to.deep.include(newFlight);
        });

        it("should return an error with status 400 for invalid flight data", function() {
            const invalidFlight = { flightNumber: "DA124", destination: "Paris" }; // Missing other fields
            const response = airplaneService.addFlight(invalidFlight);
            expect(response).to.have.property('status', 400);
            expect(response).to.have.property('error', "Invalid Flight Data!");
        });
    });

    describe("deleteFlight()", function() {
        it("should delete an existing flight by flight number", function() {
            const flightNumberToDelete = "CA789";
            const response = airplaneService.deleteFlight(flightNumberToDelete);
            expect(response).to.have.property('status', 200);
            expect(response).to.have.property('message', "Flight deleted successfully.");
            const flights = airplaneService.getFlights().data;
            const foundFlights = flights.filter(f => f.flightNumber == flightNumberToDelete);
	    expect(foundFlights.length).to.equal(0);
        });

        it("should return an error with status 404 if the flight is not found", function() {
            const nonExistentFlightNumber = "999";
            const response = airplaneService.deleteFlight(nonExistentFlightNumber);
            expect(response).to.have.property('status', 404);
            expect(response).to.have.property('error', "Flight Not Found!");
        });
    });

    describe("updateFlight()", function() {
        it("should update an existing flight with new data", function() {
            const oldFlightNumber = "AA123";
            const newFlight = { flightNumber: oldFlightNumber, destination: "San Francisco", departureTime: "2024-07-27T10:00:00Z", status: "On Time" };
            const response = airplaneService.updateFlight(oldFlightNumber, newFlight);
            expect(response).to.have.property('status', 200);
            expect(response).to.have.property('message', "Flight updated successfully.");
            const flights = airplaneService.getFlights().data;
            expect(flights).to.deep.include(newFlight);
        });

        it("should return an error with status 404 if the flight to update is not found", function() {
            const oldFlightNumber = "ZZ999";
            const newFlight = { flightNumber: "ZZ999", destination: "Miami", departureTime: "2024-08-01T15:00:00Z", status: "Delayed" };
            const response = airplaneService.updateFlight(oldFlightNumber, newFlight);
            expect(response).to.have.property('status', 404);
            expect(response).to.have.property('error', "Flight Not Found!");
        });

        it("should return an error with status 400 if the new flight data is invalid", function() {
            const oldFlightNumber = "AA123";
            const invalidFlight = { flightNumber: oldFlightNumber, destination: "Chicago" }; 
            const response = airplaneService.updateFlight(oldFlightNumber, invalidFlight);
            expect(response).to.have.property('status', 400);
            expect(response).to.have.property('error', "Invalid Flight Data!");
        });
    });
});