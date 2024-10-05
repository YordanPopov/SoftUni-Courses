function isLeapYear(input) {
    let year = parseInt(input);
    let isLeap = (year % 4 === 0 && year % 100 !== 0) || year % 400 === 0;

    let output = (isLeap) ? 'yes' : 'no';

    console.log(output);  
}

isLeapYear(1984);
isLeapYear(2003);
isLeapYear(4);