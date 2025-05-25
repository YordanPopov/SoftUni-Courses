function solve(age, gender) {
    let output;

    if (gender === 'm') {
        if (age >= 16) {
            output = 'Mr.';
        } else {
            output = 'Master';
        }
    } else if (gender === 'f') {
       if (age >= 16) {
            output = 'Ms.';
        } else {
            output = 'Miss';
        } 
    }

    console.log(output);
}

solve(12, 'f');