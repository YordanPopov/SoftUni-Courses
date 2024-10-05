function printSumOfElements(arr) {
    let firstElement = parseInt(arr[0]);
    let lasElement = parseInt(arr[arr.length - 1]);

    console.log(firstElement + lasElement);  
}

printSumOfElements(['20', '30', '40']);