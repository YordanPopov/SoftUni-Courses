function solve(numberOfMen, numberOfWomen, maxTables) {
    const meetings = [];

    for (let man = 1; man <= numberOfMen; man++) {
        for (let woman = 1; woman <= numberOfWomen; woman++) {
            if (meetings.length < maxTables) {
                meetings.push(`(${man} <-> ${woman})`);
            }
        }
    }

    console.log(meetings.join(' '));
}

solve(5, 8, 40);