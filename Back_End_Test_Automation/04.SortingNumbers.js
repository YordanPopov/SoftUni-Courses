function sortNumbers(numbers) {
    let sortedArray = numbers.sort((num1, num2) => {
        return num1 - num2;
    });

    let resultArray = [];
    let counts = sortedArray.length - 1;
    
    for (let index = 0; index <= counts; index++) {
        if (index % 2 == 0) {
            resultArray.push(sortedArray.shift());
        }else {
            resultArray.push(sortedArray.pop());
        }
    }

    return resultArray;
}

console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
