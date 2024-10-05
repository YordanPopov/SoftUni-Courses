function printTicketPrice(typeOfDay, age) {
    let output = '';

    switch (typeOfDay) {
        case 'Weekday':
            output = (age >= 0 && age <= 18) ? '12$' :
                     (age > 18 && age <= 64) ? '18$' :
                     (age > 64 && age <= 122) ? '12$' : 'Error!';
            break;
        case 'Weekend':
            output = (age >= 0 && age <= 18) ? '15$' :
                     (age > 18 && age <= 64) ? '20$' :
                     (age > 64 && age <= 122) ? '15$' : 'Error!';
            break;
        case 'Holiday':
            output = (age >= 0 && age <= 18) ? '5$' :
                     (age > 18 && age <= 64) ? '12$' :
                     (age > 64 && age <= 122) ? '10$' : 'Error!';
            break;
    }

    console.log(output);
}

printTicketPrice('Weekday', 42);
printTicketPrice('Holiday', -12);
printTicketPrice('Holiday', 15);