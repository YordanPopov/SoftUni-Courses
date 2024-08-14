function printVacationPrice(group, groupType, weekDay) {
    let price;
    let totalPrice;

    if (groupType === 'Students') {
        price = (weekDay === 'Friday') ? 8.45 : 
                (weekDay === 'Saturday') ? 9.80 :
                (weekDay === 'Sunday') ? 10.46 : 0;
    }else if (groupType === 'Business') {
        price = (weekDay === 'Friday') ? 10.90 : 
                (weekDay === 'Saturday') ? 15.60 :
                (weekDay === 'Sunday') ? 16 : 0;
    }else if (groupType === 'Regular') {
        price = (weekDay === 'Friday') ? 15 : 
                (weekDay === 'Saturday') ? 20 :
                (weekDay === 'Sunday') ? 22.50 : 0;
    }

    totalPrice = price * group;

    if (groupType === 'Students' && group >= 30) {
        totalPrice *= 0.85;
    }else if (groupType === 'Regular' && (group >= 10 && group <= 20)) {
        totalPrice *= 0.95;
    }else if (groupType === 'Business' && group >= 100) {
        totalPrice = price * (group - 10);
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

printVacationPrice(30, 'Students', 'Sunday');
printVacationPrice(40, 'Regular', 'Saturday');


