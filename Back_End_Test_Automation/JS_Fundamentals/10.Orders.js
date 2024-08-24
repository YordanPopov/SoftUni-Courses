/**
 * 
 * @param {string} product 
 * @param {number} quantity 
 */

function solve(product, quantity) {
    let price;

    switch (product) {
        case 'coffee':
            price = 1.50;
            break;
        case 'coke':
            price = 1.40;
            break;
        case 'water':   
            price = 1.00;
            break;
        case 'snacks':
            price = 2.00;
            break;
    }

    let totalPrice = price * quantity;
    console.log(totalPrice.toFixed(2));
}

solve('water', 5);
solve('coffee', 2);