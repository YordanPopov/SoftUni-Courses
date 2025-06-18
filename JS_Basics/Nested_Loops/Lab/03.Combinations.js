function solve(n) {
    let combination = 0;

    for (let num1 = 0; num1 <= n; num1++) {

        for (let num2 = 0; num2 <= n; num2++) {

            for (let num3 = 0; num3 <= n; num3++) {
                if ((num1 + num2 + num3) === n) {
                    combination++;
                }
            }
        }
    }

    console.log(combination);
}

solve(20);