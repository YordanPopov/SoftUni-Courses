// Object literal
let person = { name:'Peter', age:20, height:183 };

// Empty object and add property later
let person2 = {};
person2.name = 'John';
person2.age = 22;
person2.height = 175;
person2.hairColor = 'black';

console.log(person);
console.log(person2);

let person3 = {
    sayHello: function(){
        console.log('I am person3');
    }
}

let person4 = {
    sayHello(){
        console.log('I am person4');
    }
}

person.sayHello = () => console.log('I am person with name ' + person.name);

person3.sayHello();
person4.sayHello();
person.sayHello();

console.log(Object.keys(person));
console.log(Object.values(person));

let entries = Object.entries(person);
for (let key in entries) {
   console.log(key + ' = ' + entries[key]);
}

// Create an object
const car = {
    type: "Fiat",
    model: "500",
    color: "white"
}

const person5 = {};

// Add Properties
person5.firstName = "John";
person5.lastName = "Doe";
person5.age = 50;
person5.eyeColor = "blue";

// Create an object using new Object()
const person6 = new Object();

person6.firstName = "John";
person6.lastName = "Doe";
person6.age = 50;
person6.eyeColor = "brown";

console.log(person5.firstName);
console.log(person6["lastName"]);

// Object Methods
const person7 = {
    firstName: "John",
    lastName: "Doe",
    age: 50,
    eyeColor: "black",
    fullName: function (){
        return `${this.firstName} ${this.lastName}`;
    }
}

// Add properties
person7.nationality = "English";

// Delete properties
delete person7.eyeColor;

// nested objects

const obj = {
    name: "John",
    age: 30,
    cars: {
        car1: "Citroen",
        car2: "Opel"
    }
}

// Display
console.log(obj.cars.car1);

// Object.values
const displayArr = Object.values(person)
console.log(displayArr);

// Object.entries
const fruits = {
    Bananas: 300,
    Oranges: 200,
    Apples: 500
}

for (const [fruit, value] of Object.entries(fruits)) {
    console.log(`${fruit} -> ${value}`);
}

// JSON.stringify()
let myString = JSON.stringify(fruits);
console.log(myString);

// Object constructor
function Person(firstName, lastName, age, eyeColor) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.eyeColor = eyeColor;
    this.nationality = "English"; // default value
}

const myFather = new Person("John", "Doe", 50, "brown");

// Adding a propertie to a Constructor
Person.prototype.car = "VW";

const myFatherInfo = JSON.stringify(myFather);
console.log(myFatherInfo);
















