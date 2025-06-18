function solve(numberOfFloors, roomsPerFloor) {
    for (let floor = numberOfFloors; floor >= 1; floor--) {
        let floorRooms = [];

        for (let room = 0; room < roomsPerFloor; room++) {
            if (floor === numberOfFloors) {
                floorRooms.push(`L${floor}${room}`);
            } else if (floor % 2 === 0) {
                floorRooms.push(`O${floor}${room}`);
            } else {
                floorRooms.push(`A${floor}${room}`);
            }
        }
        console.log(floorRooms.join(' '));
    }
}

solve(9, 5);