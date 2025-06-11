function solve(num) {
    let k = 1;

    while (k <= num) {
        console.log(k);
        k = 2 * k + 1;
    }
}

solve(31);