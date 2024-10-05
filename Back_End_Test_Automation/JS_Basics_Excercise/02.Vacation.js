function calculateTotalPrice(inputArr) {
    let group = parseInt(inputArr[0]);
    let groupType = inputArr[1];
    let dayOfWeek = inputArr[inputArr.length - 1];
    let priceForPerson = 0;
    let totalPrice;

    switch (dayOfWeek) {
        case 'Friday':
            priceForPerson = (groupType === 'Students') ? 8.45 :
                             (groupType === 'Business') ? 10.90 :
                             (groupType === 'Regular') ? 15 : 0;
            break;
        case 'Saturday':
            priceForPerson = (groupType === 'Students') ? 9.80 :
                             (groupType === 'Business') ? 15.60 :
                             (groupType === 'Regular') ? 20 : 0;
            break;
        case 'Sunday':
            priceForPerson = (groupType === 'Students') ? 10.46 :
                             (groupType === 'Business') ? 16 :
                             (groupType === 'Regular') ? 22.50 : 0;
            break;
    }

    totalPrice = priceForPerson * group;

    switch (groupType) {
        case 'Students':
            if (group >= 30) {
                totalPrice *= 0.85;
            }
            break;
        case 'Business':
            if (group >= 100) {
                totalPrice = priceForPerson * (group - 10);
            } 
            break;
        case 'Regular':
            if (group >= 10 && group <= 20) {
                totalPrice *= 0.95;
            } 
            break;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

calculateTotalPrice(['30', 'Students', 'Sunday']);
calculateTotalPrice(['40', 'Regular', 'Saturday']);


