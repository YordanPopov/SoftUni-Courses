/**
 * 
 * @param {string} text 
 * @param {*} startIndex 
 * @param {*} count 
 */

function solve(text, startIndex, count) {
    let result = text.substring(startIndex, startIndex + count);

    console.log(result);    
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);