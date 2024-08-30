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






