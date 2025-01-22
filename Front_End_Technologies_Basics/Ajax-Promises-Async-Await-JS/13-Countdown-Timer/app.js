async function getUserInput(promptMsg) {
    return new Promise((resolve) => {
        const input = prompt(promptMsg);
        resolve(input);
    });
}

async function startCountDown() {
    const userInput = await getUserInput("Enter the number of seconds for the countdown:");
    let timeLeft = parseInt(userInput);

    if (isNaN(timeLeft) || timeLeft <= 0) {
        console.log("Please enter a valid number of seconds:");
        return;
    }

    console.log(`Countdown started from ${timeLeft} seconds`);
    const countDownInterval = setInterval(async () => {
        console.log(`Time left: ${timeLeft}s`);
        timeLeft--;

        if (timeLeft === 0) {
            clearInterval(countDownInterval);
            console.log("Countdown finished");
            await saveRemaningTime(timeLeft);
        }
    }, 1000);
}

function saveRemaningTime(time) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            console.log(`Remaning time saved: ${time} seconds`);
            resolve();
        }, 500);
    });
}
