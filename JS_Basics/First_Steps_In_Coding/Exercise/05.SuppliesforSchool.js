function calculatePrice(pensCount, markersCount, cleanerLiters, discountPercent) {
    let pricePerPenPack = 5.80 * pensCount;
    let pricePerMarkersPack = 7.20 * markersCount;
    let pricePerLiterCleaner = 1.20 * cleanerLiters;

    let totalPriceBeforeDiscount = pricePerPenPack + pricePerMarkersPack + pricePerLiterCleaner;
    let finalPrice = totalPriceBeforeDiscount - (totalPriceBeforeDiscount * (discountPercent / 100));

    console.log(finalPrice);
}

calculatePrice(2, 3, 4, 25);
calculatePrice(4, 2, 5, 13);