function solve([firstPlayerName, secondPlayerName, ...cards]) {
    let index = 0;
    let firstPlayerPoints = 0;
    let secondPlayerPoints = 0;

    while (cards[index] !== 'End of game') {
        let firstPlayerCard = Number(cards[index++]);
        let secondPlayerCard = Number(cards[index++]);

        if (firstPlayerCard > secondPlayerCard) {
            firstPlayerPoints += firstPlayerCard - secondPlayerCard;
        } else if (firstPlayerCard < secondPlayerCard) {
            secondPlayerPoints += secondPlayerCard - firstPlayerCard;
        } else {
            console.log('Number wars!')
            firstPlayerCard = Number(cards[index++]);
            secondPlayerCard = Number(cards[index++]);

            if (firstPlayerCard > secondPlayerCard) {
                console.log(`${firstPlayerName} is winner with ${firstPlayerPoints} points`);
                return;
            } else {
                console.log(`${secondPlayerName} is winner with ${secondPlayerPoints} points`);
                return;
            }
        }
    }

    console.log(`${firstPlayerName} has ${firstPlayerPoints} points`);
    console.log(`${secondPlayerName} has ${secondPlayerPoints} points`);
}

solve(["Elena",
    "Simeon",
    "6",
    "3",
    "2",
    "5",
    "8",
    "9",
    "End of game"]);

