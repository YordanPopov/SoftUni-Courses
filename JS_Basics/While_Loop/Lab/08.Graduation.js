function solve([studentName, ...grades]) {
    grades = grades.map(Number);
    let totalGrades = 0;
    let schoolClass = 0;
    let excludedCount = 0;

    let index = 0;
    let currentGrade = grades[index];

    while (index < grades.length) {
        if (currentGrade < 4) {
            excludedCount++;
            if (excludedCount > 1) {
                console.log(`${studentName} has been excluded at ${schoolClass + 1} grade`);
                return;
            }
        } else {
            totalGrades += currentGrade;
            schoolClass++;
        }

        index++;
        currentGrade = grades[index];
    }

    let averageGrade = totalGrades / schoolClass;
    console.log(`${studentName} graduated. Average grade: ${averageGrade.toFixed(2)}`);
}

solve(["Mimi",
    "5",
    "6",
    "5",
    "6",
    "5",
    "6",
    "6",
    "2",
    "3"]);

