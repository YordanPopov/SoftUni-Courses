function solve(input) {
    let n = Number(input[0]);
    let sum = 0;

    for (let i = 1; i <= n; i++) {
        sum += Number(input[i]);
    }

    let average = sum / n;
    console.log(average.toFixed(2));
}