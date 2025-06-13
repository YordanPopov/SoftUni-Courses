function solve(input) {
    let counter = 0;

    while (input > 0) {
        if (input >= 2) input = (input - 2).toFixed(2);
        else if (input >= 1) input = (input - 1).toFixed(2);
        else if (input >= 0.5) input = (input - 0.5).toFixed(2);
        else if (input >= 0.2) input = (input - 0.2).toFixed(2);
        else if (input >= 0.1) input =(input - 0.1).toFixed(2);
        else if (input >= 0.05) input = (input - 0.05).toFixed(2);
        else if (input >= 0.02) input = (input - 0.02).toFixed(2);
        else if (input >= 0.01) input = (input - 0.01).toFixed(2);

        counter++;
    }

    console.log(counter);
}

solve(1.23);