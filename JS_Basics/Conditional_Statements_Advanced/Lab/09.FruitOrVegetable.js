function solve(productName) {
    let output;

    let isFruit = productName === 'banana' ||
        productName === 'apple' ||
        productName === 'kiwi' ||
        productName === 'lemon' ||
        productName === 'grapes' ||
        productName === 'cherry';
    let isVegetable = productName === 'tomato' ||
        productName === 'cucumber' ||
        productName === 'pepper' ||
        productName === 'carrot';

    if (isFruit) {
        output = 'fruit';
    } else if (isVegetable) {
        output = 'vegetable';
    } else {
        output = 'unknown';
    }

    console.log(output);
}

solve('water');