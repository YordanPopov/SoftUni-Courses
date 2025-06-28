function solve([computersCount, ...input]) {
    computersCount = Number(computersCount);
    let totalSales = 0;
    let totalRating = 0;

    const ratings = { 2: 0.0, 3: 0.5, 4: 0.7, 5: 0.85, 6: 1.0 };

    for (let i = 0; i < computersCount; i++) {
        let number = Number(input[i]);

        let rating = number % 10;
        let sales = Math.floor(number / 10);

        let actualSales = sales * ratings[rating];

        totalSales += actualSales;
        totalRating += rating;
    }

    console.log(totalSales.toFixed(2));
    console.log(`${(totalRating / computersCount).toFixed(2)}`);
}

solve(["2",
    "204",
    "206"])

