/**
 * 
 * @param {string} text 
 * @param {string} word 
 */

function solve(text, word) {
    const replacement = '*'.repeat(word.length);

    const censoredText = text.split(word).join(replacement);

    console.log(censoredText);  
}

solve('A small sentence with some small words', 'small');
solve('Find the hidden word', 'hidden');