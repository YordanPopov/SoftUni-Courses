function findOddOccurrences(sentence) {
    let wordCounts = {};

    let words = sentence.toLowerCase().split(' ');

    for (let word of words) {
        if (wordCounts[word]) {
            wordCounts[word] += 1;
        }else {
            wordCounts[word] = 1;
        }
    }

    let result = [];
    for (let word in wordCounts) {
        if (wordCounts[word] % 2 != 0) {
            result.push(word);
        }
    }

    console.log(result.join(' '));    
}

findOddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
findOddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');