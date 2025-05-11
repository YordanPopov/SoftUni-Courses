function calculatePrice(mackerePrice, spratPrice, bonitoKg, safridKg, musselKg) {
    let bonitoPrice = (mackerePrice * 0.6) + mackerePrice;
    let safridPrice = (spratPrice * 0.8) + spratPrice;
    let musselPrice = 7.50;

    let totalCost = (bonitoPrice * bonitoKg) + (safridPrice * safridKg) + (musselPrice * musselKg);
    console.log(totalCost.toFixed(2));
}

calculatePrice(6.90, 4.20, 1.5, 2.5, 1);
calculatePrice(5.55, 3.57, 4.3, 3.6, 7);