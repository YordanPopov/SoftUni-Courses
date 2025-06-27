function solve(shootingTime, sceneCount, sceneLength) {
    const preparationTime = shootingTime * 0.15;
    const totalSceneTime = sceneCount * sceneLength + preparationTime;

    if (totalSceneTime <= shootingTime) {
        console.log(`You managed to finish the movie on time! You have ${Math.round(shootingTime - totalSceneTime)} minutes left!`);
    } else {
        console.log(`Time is up! To complete the movie you need ${Math.round(totalSceneTime - shootingTime)} minutes.`);
    }
}

solve(60, 15, 3);