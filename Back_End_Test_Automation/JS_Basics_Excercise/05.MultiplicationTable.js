function printMultiplicationTable(input) {
    let number = parseInt(input);

    for (let times = 1; times <= 10; times++){
        console.log(`${number} X ${times} = ${number * times}`);
    }
}

printMultiplicationTable(5);
printMultiplicationTable(2);