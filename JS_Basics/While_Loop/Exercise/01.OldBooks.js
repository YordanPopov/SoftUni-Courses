function solve([favoriteBook, ...books]) {
    let index = 0;
    let currentBook = books[index];
    let count = 0;
    let isFound = false;

    while (currentBook !== 'No More Books') {     
        if (currentBook === favoriteBook) {
            isFound = true;
            break;
        }
        
        count++;
        index++;
        currentBook = books[index];
    }
    if (isFound) {
        console.log(`You checked ${count} books and found it.`);
    } else {
        console.log("The book you search is not here!");
        console.log(`You checked ${count} books.`);
    }
}

solve(["The Spot",
    "Hunger Games",
    "Harry Potter",
    "Torronto",
    "Spotify",
    "No More Books"]);


solve(["Troy",
    "Stronger",
    "Life Style",
    "Troy"]);

