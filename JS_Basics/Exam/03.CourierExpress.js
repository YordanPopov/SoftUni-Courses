function solve(weightKg, serviceType, distanceKm) {
    let pricePerKm = 0;

    if (weightKg < 1) {
        pricePerKm = 0.03;
    } else if (weightKg < 10) {
        pricePerKm = 0.05;
    } else if (weightKg < 40) {
        pricePerKm = 0.10;
    } else if (weightKg < 90) {
        pricePerKm = 0.15;
    } else if (weightKg <= 150) {
        pricePerKm = 0.20;
    }

    let totalPrice = pricePerKm * distanceKm;
    if (serviceType === "express") {
        let markupRate = 0;
        if (weightKg < 1) {
            markupRate = 0.80;
        } else if (weightKg < 10) {
            markupRate = 0.40;
        } else if (weightKg < 40) {
            markupRate = 0.05;
        } else if (weightKg < 90) {
            markupRate = 0.02;
        } else if (weightKg <= 150) {
            markupRate = 0.01;
        }

        let extraChargePerKmPerKg = pricePerKm * markupRate;
        let expressSurcharge = extraChargePerKmPerKg * weightKg * distanceKm;
        totalPrice += expressSurcharge;
    }

    console.log(`The delivery of your shipment with weight of ${weightKg.toFixed(3)} kg. would cost ${totalPrice.toFixed(2)} lv.`);
}

solve(87, 'express', 130);