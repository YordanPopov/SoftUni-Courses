function solve(movieName, days, ticketsCount, ticketPrice, percentForCinema) {
    const movieProfit = days * (ticketsCount * ticketPrice);
    const totalProfit = movieProfit - (movieProfit * percentForCinema / 100);
    console.log(`The profit from the movie ${movieName} is ${totalProfit.toFixed(2)} lv.`);
}

solve('The Programmer', 20, 500, 7.50, 7);