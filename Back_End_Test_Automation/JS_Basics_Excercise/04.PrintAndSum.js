function printAndSum(inputArr) {
    let startIndex = parseInt(inputArr[0]);
    let endIndex = parseInt(inputArr[1]);
    let sum = 0;
    let output = '';

    for (let index = startIndex; index <= endIndex; index++) {
        output += `${index} `;
        sum += index;
    }

    console.log(`${output.trimEnd()}\nSum: ${sum}`);
}

printAndSum(['5', '10']);
printAndSum(['0', '26']);
printAndSum(['50', '60']);