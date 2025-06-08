function solve([students, ...grades]) {
    students = Number(students);
    grades = grades.map(Number);

    let totalGrades = 0;

    let topStudents = 0;
    let veryGoodStudents = 0;
    let goodStudents = 0;
    let failStudents = 0;

    for (let i = 0; i < students; i++) {
        const grade = grades[i];
        totalGrades += grade;

        if (grade >= 5.00) {
            topStudents++;
        } else if (grade >= 4.00) {
            veryGoodStudents++;
        } else if (grade >= 3.00) {
            goodStudents++;
        } else {
            failStudents++;
        }
    }

    const averageGrade = totalGrades / students;
    console.log(`Top students: ${(topStudents / students * 100).toFixed(2)}%`);
    console.log(`Between 4.00 and 4.99: ${(veryGoodStudents / students * 100).toFixed(2)}%`);
    console.log(`Between 3.00 and 3.99: ${(goodStudents / students * 100).toFixed(2)}%`);
    console.log(`Fail: ${(failStudents / students * 100).toFixed(2)}%`);
    console.log(`Average: ${averageGrade.toFixed(2)}`);
}

solve(["10",
    "3.00",
    "2.99",
    "5.68",
    "3.01",
    "4",
    "4",
    "6.00",
    "4.50",
    "2.44",
    "5"])
