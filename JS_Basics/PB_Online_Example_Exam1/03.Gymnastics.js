function solve(country, equipment) {
    const ratings = {
        'ribbon': {
            Russia: { difficultyScore: 9.100, executionScore: 9.400 },
            Bulgaria: { difficultyScore: 9.600, executionScore: 9.400 },
            Italy: { difficultyScore: 9.200, executionScore: 9.500 }
        },
        'hoop': {
            Russia: { difficultyScore: 9.300, executionScore: 9.800 },
            Bulgaria: { difficultyScore: 9.550, executionScore: 9.750 },
            Italy: { difficultyScore: 9.450, executionScore: 9.350 }
        },
        'rope': {
            Russia: { difficultyScore: 9.600, executionScore: 9.000 },
            Bulgaria: { difficultyScore: 9.500, executionScore: 9.400 },
            Italy: { difficultyScore: 9.700, executionScore: 9.150 }
        }
    }

    const { difficultyScore, executionScore } = ratings[equipment][country];
    let totalScore = difficultyScore + executionScore;
    let missingPoints = 20 - totalScore;

    console.log(`The team of ${country} get ${totalScore.toFixed(3)} on ${equipment}.`);
    console.log(`${(missingPoints / 20 * 100).toFixed(2)}%`);
}

solve('Russia', 'rope');