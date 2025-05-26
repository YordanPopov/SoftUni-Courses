function solve(data) {
    for (const num of data) {
        let currentNum = Number(num);
        if (currentNum >= 0) {
            console.log(`Result: ${(currentNum * 2).toFixed(2)}`);
        } else {
            console.log('Negative number!');
            break;
        }
    }
}

solve(['23.43', '12.3245', '0', '65.23432', '20', '65', '-12']);