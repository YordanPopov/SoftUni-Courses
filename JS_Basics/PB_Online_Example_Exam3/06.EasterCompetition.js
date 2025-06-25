function solve([participants, ...input]) {
    participants = Number(participants);
    let index = 0;
    let maxPoints = 0;
    let theBestBakerName = ''

    for (let i = 0; i < participants; i++) {
        let currentBakerName = '';
        let currentBakerPoints = 0;

        while (input[index] !== 'Stop') {
            if (isNaN(input[index])) {
                currentBakerName = input[index++];
            }
            let points = Number(input[index++]);

            currentBakerPoints += points;
        }

        console.log(`${currentBakerName} has ${currentBakerPoints} points.`);

        if (currentBakerPoints > maxPoints) {
            maxPoints = currentBakerPoints;
            theBestBakerName = currentBakerName;
            console.log(`${currentBakerName} is the new number 1!`);
        }

        index++;
    }

    console.log(`${theBestBakerName} won competition with ${maxPoints} points!`);
}

solve(["3",
    "Chef Manchev", "10",
    "10",
    "10",
    "10",
    "Stop",
    "Natalie",
    "8",
    "2",
    "9",
    "Stop",
    "George",
    "9",
    "2",
    "4",
    "2",
    "Stop"]);
