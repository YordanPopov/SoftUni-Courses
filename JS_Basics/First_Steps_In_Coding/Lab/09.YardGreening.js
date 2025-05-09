function calculateTotalPrice(squareMeters) {
    let pricePerSquareMeter = 7.61;

    let priceWithoutDiscount = squareMeters * pricePerSquareMeter;
    let discount = priceWithoutDiscount * 0.18;
    let totalPrice = priceWithoutDiscount - discount;
    
    let output = `The final price is: ${totalPrice} lv.\nThe discount is: ${discount} lv.`;
    console.log(output);
}

calculateTotalPrice(550);
calculateTotalPrice(150);