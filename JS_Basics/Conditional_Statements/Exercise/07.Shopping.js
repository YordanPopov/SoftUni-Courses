function solve(budget, GPUs, CPUs, RAMs) {
    let gpuPrice = 250;
    let cpuPrice = (GPUs * gpuPrice) * 0.35;
    let ramPrice = (GPUs * gpuPrice) * 0.1;

    let totalPrice = (gpuPrice * GPUs) + (cpuPrice * CPUs) + (ramPrice * RAMs);

    if (GPUs > CPUs) {
        totalPrice *= 0.85;
    }

    if (budget >= totalPrice) {
        console.log(`You have ${(budget-totalPrice).toFixed(2)} leva left!`);
    } else {
       console.log(`Not enough money! You need ${(totalPrice - budget).toFixed(2)} leva more!`);
    }
}

solve(920.45, 3, 1, 1);