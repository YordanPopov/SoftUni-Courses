function solve(fruit, day, quantity) {
    let fruitPrice = 0;
    let isValid = true;

    switch (day) {
        case 'Saturday':
        case 'Sunday':
            switch (fruit) {
                case 'banana': fruitPrice = 2.70; break;
                case 'apple': fruitPrice = 1.25; break;
                case 'orange': fruitPrice = 0.90; break;
                case 'grapefruit': fruitPrice = 1.60; break;
                case 'kiwi': fruitPrice = 3.00; break;
                case 'pineapple': fruitPrice = 5.60; break;
                case 'grapes': fruitPrice = 4.20; break;
                default:
                    isValid = false;
                    break;
            }
            break;
        case 'Monday':
        case 'Tuesday':
        case 'Wednesday':
        case 'Thursday':
        case 'Friday':
            switch (fruit) {
                case 'banana': fruitPrice = 2.50; break;
                case 'apple': fruitPrice = 1.20; break;
                case 'orange': fruitPrice = 0.85; break;
                case 'grapefruit': fruitPrice = 1.45; break;
                case 'kiwi': fruitPrice = 2.70; break;
                case 'pineapple': fruitPrice = 5.50; break;
                case 'grapes': fruitPrice = 3.85; break;
                default:
                    isValid = false;
                    break;
            }
            break;
        default:
            isValid = false;
            break;
    }

    if (isValid) {
        let totalPrice = fruitPrice * quantity;
        console.log(totalPrice.toFixed(2));
    } else {
        console.log('error');
    }
}

solve('invalid', 'invalid', 2);