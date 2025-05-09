function calculateDivident(deposit, termInMonths, apr) {
    let divident = deposit + termInMonths * ((deposit * (apr / 100)) / 12);

    console.log(divident);
}

calculateDivident(200, 3, 5.7);
calculateDivident(2350, 6, 7);