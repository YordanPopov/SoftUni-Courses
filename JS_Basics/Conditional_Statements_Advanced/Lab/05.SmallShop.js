function solve(product, city, quantity) {
    let productPrice = 0;

    switch (city) {
        case 'Sofia':
            if (product === 'coffee') {
                productPrice = 0.50;
            } else if (product === 'water') {
                productPrice = 0.80;
            } else if (product === 'beer') {
                productPrice = 1.20;
            } else if (product === 'sweets') {
                productPrice = 1.45;
            } else if (product === 'peanuts') {
                productPrice = 1.60;
            }
            break;
        case 'Plovdiv':
            if (product === 'coffee') {
                productPrice = 0.40;
            } else if (product === 'water') {
                productPrice = 0.70;
            } else if (product === 'beer') {
                productPrice = 1.15;
            } else if (product === 'sweets') {
                productPrice = 1.30;
            } else if (product === 'peanuts') {
                productPrice = 1.50;
            }
            break;
        case 'Varna':
            if (product === 'coffee') {
                productPrice = 0.45;
            } else if (product === 'water') {
                productPrice = 0.70;
            } else if (product === 'beer') {
                productPrice = 1.10;
            } else if (product === 'sweets') {
                productPrice = 1.35;
            } else if (product === 'peanuts') {
                productPrice = 1.55;
            }
            break;
    }

    let totalPrice = productPrice * quantity;
    console.log(totalPrice);
}

solve('coffee', 'Varna', 2);