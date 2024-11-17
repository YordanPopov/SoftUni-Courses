export const airplaneService = {
    flights: [
        { flightNumber: "AA123", destination: "New York", departureTime: "2024-07-27T08:00:00Z", status: "On Time" },
        { flightNumber: "BA456", destination: "London", departureTime: "2024-07-27T12:00:00Z", status: "Delayed" },
        { flightNumber: "CA789", destination: "Los Angeles", departureTime: "2024-07-27T16:00:00Z", status: "Cancelled" }
    ],
    getFlights() {
        return {
            status: 200,
            data: this.flights
        };
    },
    addFlight(flight) {
        if (!flight.flightNumber || !flight.destination || !flight.departureTime || !flight.status) {
            return {
                status: 400,
                error: "Invalid Flight Data!"
            };
        }
        this.flights.push(flight);
        return {
            status: 201,
            message: "Flight added successfully."
        };
    },
    deleteFlight(flightNumber) {
        const flightIndex = this.flights.findIndex(flight => flight.flightNumber === flightNumber);
        if (flightIndex === -1) {
            return {
                status: 404,
                error: "Flight Not Found!"
            };
        }
        this.flights.splice(flightIndex, 1);
        return {
            status: 200,
            message: "Flight deleted successfully."
        };
    },
    updateFlight(oldFlightNumber, newFlight) {
        const flightIndex = this.flights.findIndex(flight => flight.flightNumber === oldFlightNumber);
        if (flightIndex === -1) {
            return {
                status: 404,
                error: "Flight Not Found!"
            };
        }
        if (!newFlight.flightNumber || !newFlight.destination || !newFlight.departureTime || !newFlight.status) {
            return {
                status: 400,
                error: "Invalid Flight Data!"
            };
        }
        this.flights[flightIndex] = newFlight;
        return {
            status: 200,
            message: "Flight updated successfully."
        };
    }
};
