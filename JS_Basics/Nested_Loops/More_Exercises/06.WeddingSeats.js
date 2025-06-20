function solve(lastSector, rowsInFirstSector, seatsOnOddRow) {
    lastSector = lastSector.charCodeAt(0);
    let totalSeats = 0;

    for (let sector = 'A'.charCodeAt(0); sector <= lastSector; sector++) {
        let rowsInThisSector = rowsInFirstSector + (sector - 'A'.charCodeAt(0));

        for (let row = 1; row <= rowsInThisSector; row++) {
            let seatsInRow = row % 2 === 0 ? seatsOnOddRow + 2 : seatsOnOddRow;

            for (let seat = 0; seat < seatsInRow; seat++) {
                let seatLetter = String.fromCharCode('a'.charCodeAt(0) + seat);
                console.log(`${String.fromCharCode(sector)}${row}${seatLetter}`);
                totalSeats++;
            }
        }
    }

    console.log(totalSeats);
}

solve('B', 3, 2)
