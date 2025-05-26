function solve(stayDays, roomType, review) {
    const roomPrice = {
        'room for one person': 18.00,
        'apartment': 25.00,
        'president apartment': 35.00
    };

    let totalPrice = (stayDays - 1) * roomPrice[roomType];

    switch (roomType) {
        case 'apartment':
            if (stayDays < 10) {
                totalPrice *= 0.7;
            } else if (stayDays >= 10 && stayDays <= 15) {
                totalPrice *= 0.65;
            } else if (stayDays > 15) {
                totalPrice *= 0.5;
            }
            break;
        case 'president apartment':
            if (stayDays < 10) {
                totalPrice *= 0.9;
            } else if (stayDays >= 10 && stayDays <= 15) {
                totalPrice *= 0.85;
            } else if (stayDays > 15) {
                totalPrice *= 0.8;
            }
            break;
    }

    if (review === 'positive') {
        totalPrice *= 1.25;
    } else {
        totalPrice *= 0.90;
    }

    console.log(totalPrice.toFixed(2));
}

solve(30, 'president apartment', 'negative');