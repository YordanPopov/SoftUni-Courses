function printString(arr) {
    let result = `${arr[2].charCodeAt(0)} ${arr[1].charCodeAt(0)} ${arr[0].charCodeAt(0)}`;
    let result2 = arr[2] + arr[1] + arr[0];
    console.log(result2);
    console.log(result);
}

printString(['a', 'b', 'c']);
printString(['%', '2', 'o']);
printString(['1', '5', 'p']);