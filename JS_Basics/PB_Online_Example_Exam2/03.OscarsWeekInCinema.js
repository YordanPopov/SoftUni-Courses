function solve(movieName, hallType, ticketsCount) {
    const movieProjections = {
        'A Star Is Born': {
            'normal': 7.50,
            'luxury': 10.50,
            'ultra luxury': 13.50
        },
        'Bohemian Rhapsody': {
            'normal': 7.35,
            'luxury': 9.45,
            'ultra luxury': 12.75
        },
        'Green Book': {
            'normal': 8.15,
            'luxury': 10.25,
            'ultra luxury': 13.25
        },
        'The Favourite': {
            'normal': 8.75,
            'luxury': 11.55,
            'ultra luxury': 13.95
        }
    }

    let price = movieProjections[movieName][hallType];
    const totalPrice = price * ticketsCount;

    console.log(`${movieName} -> ${totalPrice.toFixed(2)} lv.`);
}

solve('Green Book', 'normal', 63);