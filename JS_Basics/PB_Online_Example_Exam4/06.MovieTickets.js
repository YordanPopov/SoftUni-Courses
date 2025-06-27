function solve(a1, a2, n) {

    for (let asciiCode = a1; asciiCode <= a2 - 1; asciiCode++) {
        for (let digit2 = 1; digit2 <= n - 1; digit2++) {
            for (let digit3 = 1; digit3 <= n / 2 - 1; digit3++) {
                let symbol1 = String.fromCharCode(asciiCode);
                let symbol2 = digit2;
                let symbol3 = digit3;
                let symbol4 = asciiCode;

                if (asciiCode % 2 !== 0 && (symbol2 + symbol3 + symbol4) % 2 !== 0) {
                    console.log(`${symbol1}-${symbol2}${symbol3}${symbol4}`);
                }
            }
        }
    }
}

solve(86, 88, 4);