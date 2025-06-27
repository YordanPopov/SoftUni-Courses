function solve(seriesName, seasonsCount, episodesCount, oridnaryEpisodeTime) {
    let advertisements = oridnaryEpisodeTime * 0.2;
    let lastEpisodeTime = seasonsCount * 10;
    let totalTime = seasonsCount * (episodesCount * (advertisements + oridnaryEpisodeTime)) + lastEpisodeTime;
    console.log(`Total time needed to watch the ${seriesName} series is ${totalTime} minutes.`);
}

solve('Lucifer', 3, 18, 55)