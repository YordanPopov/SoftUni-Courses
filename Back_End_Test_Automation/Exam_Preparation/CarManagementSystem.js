function solve(cars) {
    function getCarsByBrand(brand) {
        return cars.filter(car => car.brand === brand);
    }

    function addCar(id, brand, model, year, price, inStock) {
        const newCar = {
            id: id,
            brand: brand,
            model: model,
            year: year,
            price: price,
            inStock: inStock
        };

        cars.push(newCar);
        
        return cars;
    }

    function getCarById(id) {
        const carIndex = cars.findIndex(car => car.id === id);

        if (carIndex === -1) {
            return `Car with ID ${id} not found`;
        }

        for (const car of cars) {
            if (Object.values(car).includes(id)) {
                return car;
            }
        }
    }

    function removeCarById(id) {
        const carIndex = cars.findIndex(car => car.id === id);

        if (carIndex === -1) {
            return `Car with ID ${id} not found`;
        }

        cars.splice(carIndex, 1);
        return cars;
    }

    function updateCarPrice(id, newPrice) {
        const carIndex = cars.findIndex(car => car.id === id);

        if (carIndex === -1) {
            return `Car with ID ${id} not found`;
        }

        for (const car of cars) {
            if (Object.values(car).includes(id)) {
                car.price = newPrice;
            }
        }

        return cars;
    }

    function updateCarStock(id, inStock) {
        const carIndex = cars.findIndex(car => car.id === id);

        if (carIndex === -1) {
            return `Car with ID ${id} not found`;
        }

        for (const car of cars) {
            if (Object.values(car).includes(id)) {
                car.inStock = inStock;
            }
        }

        return cars;
    }

    return {
        getCarsByBrand,
        addCar,
        getCarById,
        removeCarById,
        updateCarPrice,
        updateCarStock
    };
}

let cars = [
    { id: 1, brand: "Toyota", model: "Corolla", year: 2020, price: 20000, inStock: true },
    { id: 2, brand: "Honda", model: "Civic", year: 2019, price: 22000, inStock: true },
    { id: 3, brand: "Ford", model: "Mustang", year: 2021, price: 35000, inStock: false }
  ];

  const dealership = solve(cars);

// console.log(dealership.getCarsByBrand("Toyota"));
// console.log(dealership.addCar(4, "Tesla", "Model S", 2022, 80000, true));
// console.log(dealership.getCarById(2));
// console.log(dealership.removeCarById(3));
// console.log(dealership.updateCarPrice(1, 85000));
console.log(dealership.updateCarStock(10, false));




  