function printVacationPrice(arr) {
    let price;
    let totalPrice;

    let group = arr[0];
    let groupType = arr[1];
    let weekDay = arr[arr.length - 1];
    
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

    totalPrice = price * parseInt(group);

    if (groupType === 'Students' && parseInt(group) >= parseInt('30')) { 
        totalPrice *= parseFloat('0.85');
    }else if (groupType === 'Regular' && (parseInt(group) >= parseInt('10') && parseInt(group) <= parseInt('20'))) { 
        totalPrice *= parseFloat('0.95');
    }else if (groupType === 'Business' && parseInt(group) >= parseInt('100')) {  
        totalPrice = price * (parseInt(group) - parseInt('10'));
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

printVacationPrice(['30', 'Students', 'Sunday']);
printVacationPrice(['40', 'Regular', 'Saturday']);


