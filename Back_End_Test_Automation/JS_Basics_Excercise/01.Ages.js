function printPersonType(age) {
    age = parseInt(age);

    let output = (age >= 0 && age <= 2) ? 'baby' :
                (age >= 3 && age <= 13) ? 'child' : 
                (age >= 14 && age <= 19) ? 'teenager' :
                (age >= 20 && age <= 65) ? 'adult' :
                (age >= 66) ? 'elder' : 'out of bounds';

    console.log(output);
}

printPersonType('20');
printPersonType('1');
printPersonType('100');
printPersonType('-1');