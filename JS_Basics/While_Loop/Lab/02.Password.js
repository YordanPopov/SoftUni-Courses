function solve([username, password, ...attempts]) {
    let index = 0;
    let currentAttempt = attempts[index];

    while (true) {
        if (currentAttempt === password) {
            console.log(`Welcome ${username}!`);
            break;
        }

        index++;
        currentAttempt = attempts[index];
    }
}

solve(["Nakov",
    "1234",
    "Pass",
    "1324",
    "1234"]);
