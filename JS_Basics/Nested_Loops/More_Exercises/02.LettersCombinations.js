function solve(startChar, endChar, skipChar) {
    let validCombination = 0;
    let combinations = [];
    const startCode = startChar.charCodeAt(0);
    const endCode = endChar.charCodeAt(0);
    const skipCode = skipChar.charCodeAt(0);

    for (let ch1 = startCode; ch1 <= endCode; ch1++) {
        for (let ch2 = startCode; ch2 <= endCode; ch2++) {
            for (let ch3 = startCode; ch3 <= endCode; ch3++) {
                if (ch1 !== skipCode && ch2 !== skipCode && ch3 !== skipCode) {
                    combinations.push(`${String.fromCharCode(ch1)}${String.fromCharCode(ch2)}${String.fromCharCode(ch3)}`);
                    validCombination++;
                }
            }
        }
    }

    combinations.push(validCombination);
    console.log(combinations.join(' '));
}

solve('a', 'c', 'z')