function findSubstring(word, text) {
    let isFoundWord = text
                      .toLowerCase()
                      .split(' ')
                      .includes(word);
    
    if (isFoundWord) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

findSubstring('javascript', 'JavaScript is the best programming language');
findSubstring('python', 'JavaScript is the best programming language');