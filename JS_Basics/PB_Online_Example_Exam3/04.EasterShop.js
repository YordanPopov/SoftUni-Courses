function solve([initialCountEggs, ...commands]) {
    let availableEggs = Number(initialCountEggs);
    let soldEggs = 0;

    let index = 0;
    while (commands[index] !== 'Close') {
        let currentCommand = commands[index++];
        let eggs = Number(commands[index++]);

        if (currentCommand === 'Buy') {
            if (eggs > availableEggs) {
                console.log(`Not enough eggs in store!\nYou can buy only ${availableEggs}.`);
                return;
            }

            soldEggs += eggs;
            availableEggs -= eggs
        } else if (currentCommand === 'Fill') {
            availableEggs += eggs;
        }
    }

    console.log(`Store is closed!\n${soldEggs} eggs sold.`)
}

solve(["13",
    "Buy",
    "8",
    "Fill",
    "3",
    "Buy",
    "10"]);
