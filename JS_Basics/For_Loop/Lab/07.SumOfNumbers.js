function solve(number) {
    let sum = 0;

    for (const num of number) {
        sum += parseInt(num);
    }

    console.log(`The sum of the digits is:${sum}`)
}

solve('564891');