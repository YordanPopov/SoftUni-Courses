let a = 5;
let b = 10;

if (b > a) {
    console.log(b); // 10
}

function solve(name, grade) {
    //console.log('The name is: ' + name + ', grade: ' + grade);
    console.log(`The name is: ${name}, grade: ${grade.toFixed(2)}`);
}
solve('Peter', 3.555); 

let number = 10; // Number
let person = {   // Object
    name: 'George',
    age: 25
};
let array = [1, 2, 3]; // Array
let name = 'George'; // String
let empty = null; // null
let unknown = undefined; // undefined

console.log(person);
console.log(typeof person); // object

// For-in
for (let key in person) {
    console.log(`${key} -> ${person[key]}`);    
}

// For-Of
let numbers = [20, 30, 40]
for (let number of numbers) {
    console.log(number); 
}

