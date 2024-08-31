function sortNames(namesArray) {
    const sortedArray = namesArray.sort((e1, e2) => {
        return e1.localeCompare(e2);
    });

    for (let index = 0; index <= sortedArray.length - 1; index++) {
        console.log(`${index + 1}.${sortedArray[index]}`);
    }
}

sortNames(["John", "Bob", "Christina", "Ema"]);