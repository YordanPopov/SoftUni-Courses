function solve([numberOfFailsGrades, ...input]) {
    numberOfFailsGrades = Number(numberOfFailsGrades);

    let index = 0;
    let currentInput = input[index];
    let totalGrades = 0;
    let countGrades = 0;
    let countFails = 0;
    let lastProblem = '';

    while (currentInput !== 'Enough') {
        let grade = Number(input[index + 1]);
        countGrades++;
        totalGrades += grade;
        lastProblem = currentInput;

        if (grade <= 4) {
            countFails++;
        }

        if (countFails === numberOfFailsGrades) {
            console.log(`You need a break, ${countFails} poor grades.`);
            return;
        }

        index += 2;
        currentInput = input[index];
    }

    let averageGrade = totalGrades / countGrades;
    console.log(`Average score: ${averageGrade.toFixed(2)}`);
    console.log(`Number of problems: ${countGrades}`);
    console.log(`Last problem: ${lastProblem}`);
}


// solve(["3",
//     "Money",
//     "6",
//     "Story",
//     "4",
//     "Spring Time",
//     "5",
//     "Bus",
//     "6",
//     "Enough"]);


solve(["2",
    "Income",
    "3",
    "Game Info",
    "6",
    "Best Player",
    "4"]);
