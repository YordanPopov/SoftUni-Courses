// + or +=
let text = 'Hello' + ', ';
text += 'JS';
console.log(text);

// concat()
let greet = 'Hello, ';
let name = 'Jonh';
let result = greet.concat(name);
console.log(result);

// indexOf(substr)
let str = "I'm JavaScript Developer";
console.log(str.indexOf('Java'));
console.log(str.indexOf('java'));

// lastIndexOf(substr)
console.log(str.lastIndexOf('a'));

// substring(startIndex, endIndex)
let sub = str.substring(4, 14);
console.log(sub);

// replace(search, replacement)
let text2 = 'Hello, john@softuni.bg, you have been using john@softuni.bg in your registration';
let replacedText = text2.replace('.bg', '.com')
console.log(text2);
console.log(replacedText);

 // split(operator)
 let text3 = 'I Love Fruits';
 let words = text3.split(' ');
 console.log(words);

 // includes(substr)
 console.log(text3.includes('Fruits'));
 console.log(text3.includes('Banana'));;

 // repeat(count) -> creates a new string repeated count times
 let n = 3;
 for (let i = 1; i <= n; i++) {
    console.log('*'.repeat(i));
 }
 
 // trim(), trimStart(), trimEnd()
 let text4 = '      Annoying spaces     '
 console.log(text4.trim());
 console.log(text4.trimStart());
 console.log(text4.trimEnd());
 
 // starstWith(), endsWith()
 console.log(text3.startsWith('I'));
 console.log(text3.startsWith('You'));

 console.log(text3.endsWith('Fruits'));
 console.log(text3.endsWith('Banana'));
 
 
 
 
 

 


