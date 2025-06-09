function solve([n, ...numbers]) {
    n = Number(n);
    numbers = numbers.map(Number);
    let index = 0
    let sum = 0;

    while (true) {
        if (sum >= n) {
            console.log(sum);
            break;         
        }

        sum += numbers[index];
        index++;
    }
}

solve(['20', '1', '2', '3', '4', '5', '6']);