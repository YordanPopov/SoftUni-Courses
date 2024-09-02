function parkingLot(logs) {
    let parkingLot = new Set();

    for (let entry of logs) {
        let [direction, plate] = entry.split(', ');

        if (direction === 'IN') {
            parkingLot.add(plate);
        }else {
            parkingLot.delete(plate);
        }
    }

    if (parkingLot.size === 0) {
        console.log('Parking Lot is Empty');
    }else {
        let sortedPlates = Array.from(parkingLot).sort((a, b) => 
            a.localeCompare(b)
        );
        console.log(sortedPlates.join('\n'));
    }
}

parkingLot(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']);

parkingLot(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA']);