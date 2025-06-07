function solve(text) {
    const vowels = {
        'a': 1,
        'e': 2,
        'i': 3,
        'o': 4,
        'u': 5,
    };

    const textToLowerCase = text.toLowerCase();
    let sum = 0;

    for (const ch of textToLowerCase) {
        if (vowels.hasOwnProperty(ch)) {
            sum += vowels[ch];
        }
    }

    console.log(sum);
}

solve('hello');