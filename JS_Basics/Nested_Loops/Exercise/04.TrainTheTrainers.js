function solve([juryCount, ...input]) {
    let index = 0;
    let totalGradesSum = 0;
    let presentationCounter = 0;

    while (input[index] !== 'Finish') {
        let presentationName = input[index++];
        presentationCounter++;
        let gradeSum = 0;

        for (let i = 0; i < juryCount; i++) {
            let grade = Number(input[index++]);
            gradeSum += grade;
        }

        totalGradesSum += gradeSum;
        let avgGrade = gradeSum / juryCount;
        console.log(`${presentationName} - ${avgGrade.toFixed(2)}.`);
    }

    console.log(`Student's final assessment is ${(totalGradesSum / (presentationCounter * juryCount)).toFixed(2)}.`)
}

solve(["3",
    "Arrays",
    "4.53",
    "5.23",
    "5.00",
    "Lists",
    "5.83",
    "6.00",
    "5.42",
    "Finish"]);
