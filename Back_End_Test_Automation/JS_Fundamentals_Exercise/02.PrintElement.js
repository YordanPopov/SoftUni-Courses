function printElement(array, step) {
    let resultArray = [];

    for (let index = 0; index <= array.length - 1; index += step) {
        resultArray.push(array[index]);
    }

    return resultArray;
}

console.log(printElement(['5', '20', '31', '4', '20'], 2));
console.log(printElement(['dsa', 'asd', 'test', 'tset'], 2));
console.log(printElement(['1', '2', '3', '4', '5'], 6));

