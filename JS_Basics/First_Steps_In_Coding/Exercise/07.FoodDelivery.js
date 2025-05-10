function calculateTotalPrice(chickenMenusCount, fishMenusCount, vegetrianMenusCount) {
    let chickenMenuCost = 10.35;
    let fishMenuCost = 12.40;
    let vegetarianMenuCost = 8.15;
    let totalMenuCost = (chickenMenusCount * chickenMenuCost) + (fishMenusCount * fishMenuCost) + (vegetrianMenusCount * vegetarianMenuCost);
    let dessertPrice = totalMenuCost * 0.2;
    let deliveryPrice = 2.50;
    let totalCost = dessertPrice + totalMenuCost + deliveryPrice;

    console.log(totalCost);
}

calculateTotalPrice(2, 4, 3);
calculateTotalPrice(9, 2, 6);