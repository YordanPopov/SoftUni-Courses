function printTypeOfPerson(age) {

    age = parseInt(age);
    if (age >= parseInt('0') && age <= parseInt('2')) {
        console.log('baby');
    }else if (age > parseInt('2') && age <= parseInt('13')) {
        console.log('child');
    }else if (age > parseInt('13') && age <= parseInt('19')) {
        console.log('teenager');
    }else if (age > parseInt('19') && age <= parseInt('65')) {
        console.log('adult');
    }else if (age > parseInt('65')) {
        console.log('elder');
    }else {
        console.log('out of bounds');
    }
}

printTypeOfPerson('20');
printTypeOfPerson('1');
printTypeOfPerson('100');
printTypeOfPerson(-'1');