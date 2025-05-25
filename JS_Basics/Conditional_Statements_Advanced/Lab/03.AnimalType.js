function solve(animal) {
    let output;

    switch (animal) {
        case 'dog':
            output = 'mammal'
            break;
        case 'crocodile':
        case 'tortoise':
        case 'snake':
            output = 'reptile';
            break;
        default:
            output = 'unknown'
            break;
    }

    console.log(output);
}

solve('invalid');