function solve(num) {
    let bonusPoints = 0;

    if (num <= 100) {
        bonusPoints += 5;
    } else if(num > 100 && num <= 1000) {
        bonusPoints = num * 0.2;
    } else if (num > 1000) {
        bonusPoints = num * 0.1;
    }

    if (num % 2 === 0) {
        bonusPoints++;
    }

    if (num % 10 === 5) {
        bonusPoints += 2;
    }

    console.log(bonusPoints);
    console.log(num + bonusPoints);
}

solve(15875);