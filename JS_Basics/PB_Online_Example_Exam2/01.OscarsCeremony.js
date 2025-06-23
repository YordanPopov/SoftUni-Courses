function solve(rentHall) {
    let statuettePrice = rentHall * 0.7;
    let cateringPrice = statuettePrice * 0.85;
    let voicingPrice = cateringPrice * 0.5;

    let totalPrice = statuettePrice + cateringPrice + voicingPrice + rentHall;
    console.log(totalPrice.toFixed(2));
}

solve(3500);