/**
 * 
 * @param {Array} currentStock 
 * @param {Array} orderedStock 
 */
function printStoreProvision(currentStock, orderedStock) {
    let stock = {};

    for (let index = 0; index <= currentStock.length - 1; index += 2) {
        let productName = currentStock[index];
        let quantity = Number(currentStock[index + 1]);
        stock[productName] = quantity;
    }

    for (let index = 0; index <= orderedStock.length - 1; index += 2) {
        let productName = orderedStock[index];
        let quantity = Number(orderedStock[index + 1]);

        if (stock.hasOwnProperty(productName)) {
            stock[productName] += quantity;
        }else {
            stock[productName] = quantity;
        }
    }

    for (let product in stock) {
        console.log(`${product} -> ${stock[product]}`);  
    }
}

printStoreProvision(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
                    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);
console.log('-------------------------------------');
printStoreProvision(['Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'],
                    ['Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30']);