function solve(budget, category, people) {
    const ticketPrice = {
        'VIP': 499.99,
        'Normal': 249.99
    };

    let transportBudget;
    if (people >= 1 && people <= 4) {
        transportBudget = budget * 0.75;
    } else if (people >= 5 && people <= 9) {
        transportBudget = budget * 0.6;
    } else if (people >= 10 && people <= 24) {
        transportBudget = budget * 0.5;
    } else if (people >= 25 && people <= 49) {
        transportBudget = budget * 0.40;
    } else if (people > 49) {
        transportBudget = budget * 0.25;
    }

    let totalCost = transportBudget + (people * ticketPrice[category]);

    if (budget >= totalCost) {
        console.log(`Yes! You have ${(budget-totalCost).toFixed(2)} leva left.`)
    } else {
        console.log(`Not enough money! You need ${(totalCost - budget).toFixed(2)} leva.`);
    }
}

solve(30000, 'VIP', 49);