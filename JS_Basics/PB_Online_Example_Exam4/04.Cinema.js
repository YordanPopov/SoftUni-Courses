function solve([hallCapacity, ...input]) {
    hallCapacity = Number(hallCapacity);
    let ticketPrice = 5;
    let cinemaIncome = 0;
    let isFull = false;


    let index = 0;
    while (input[index] !== 'Movie time!') {
        let people = Number(input[index++]);
        if (people > hallCapacity) {
            console.log(`The cinema is full.`);
            isFull = true;
            break;
        } else {
            hallCapacity -= people;
        }

        let income = people * ticketPrice;
        if (people % 3 === 0) {
            income -= 5;
        }

        cinemaIncome += income;
    }

    if (!isFull) {
        console.log(`There are ${hallCapacity} seats left in the cinema.`)
    }

    console.log(`Cinema income - ${cinemaIncome} lv.`)
}

solve(["100",
    "10",
    "10",
    "10",
    "10",
    "10",
    "10",
    "10",
    "10",
    "10",
    "10",
    "Movie time!"]);


