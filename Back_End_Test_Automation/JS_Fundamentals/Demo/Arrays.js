// Arrays
// Array literal
let myArray = ['John Doe', 24, true];

let myArray2 = [];
myArray2[0] = 'John Doe';
myArray2[1] = 24;
myArray2[2] = true;

// Array constructor
let myArray3 = new Array('John Doe', 24, true);

let cars = ['BMW', 'Audi', 'Opel'];
let firstCar = cars[0];
let lastCar = cars[cars.length - 1];

// Rest operator
let numbers = [10, 20, 30, 40, 50];
let [a, b, ...elems] = numbers;

// Array's methods
// pop() -> removes last element from an array and returns that element
console.log(numbers.length);
console.log(numbers.pop());
console.log(numbers.length);

// push() -> adds one or more elements to the end of an array nad returns the new length
console.log(numbers.push(50));
numbers.push(90, 100);
console.log(numbers);

// shift() -> removes first element and returns that element
console.log(numbers.shift());
console.log(numbers);

// unshift() -> adds one or more element to the beginning and returns the new length
console.log(numbers.unshift(10, 15));
console.log(numbers);

// splice() -> changes the contents of an array by removing or replacing existing elements and / or adding new elements
numbers.splice(numbers. length - 1, 100, 110);
console.log(numbers);
numbers.splice(0, 1, 1);
console.log(numbers);
numbers.splice(0, 1);
console.log(numbers);

// reverse()
numbers.reverse();
console.log(numbers);

// join()
console.log(numbers.join(', '));

// slice() -> returns copy of a portion an array
let numbers2 = numbers.slice(4, 7);
console.log(numbers2);

// includes()
console.log(numbers.includes(110)); // true
console.log(numbers.includes(200)); // false

// indexOf() -> returns the first index at which a given element can be found
let beasts = ['ant', 'bison', 'camel', 'duck', 'bison'];
console.log(beasts.indexOf('bison')); // 1
console.log(beasts.indexOf('bison', 2)); // 4
console.log(beasts.indexOf('giraffe')); // -1

// forEach() -> execute provide function for each array element
let numbers3 = [];
numbers.forEach(item => {numbers3.push(item); });
console.log(numbers3);

// map() -> creates a new array with the result of calling a provided function on every element
let roots = numbers.map(function(num, i, arr) {
    return Math.sqrt(num);
});
console.log(roots);

// find() -> returns first found value in an array
let found = numbers.find(function(element){
    return element < 80;
});
console.log(found);





















