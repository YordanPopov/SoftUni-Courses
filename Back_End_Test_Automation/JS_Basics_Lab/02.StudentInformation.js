function printStudentInfo(name, age, avrGrade) {
    let studentInfo = `Name: ${name}, Age: ${age}, Grade: ${avrGrade.toFixed(2)}`;
    console.log(studentInfo);
}


printStudentInfo('John', 15, 5.54678);
printStudentInfo('Steve', 16, 2.1426);
printStudentInfo('Marry', 12, 6.00);