function solve(championshipStage, ticketType, ticketsQuantity, trophyPic) {
    const tickets = {
        'Standard': {
            'Quarter final': 55.50,
            'Semi final': 75.88,
            'Final': 110.10
        },
        'Premium': {
            'Quarter final': 105.20,
            'Semi final': 125.22,
            'Final': 160.66
        },
        'VIP': {
            'Quarter final': 118.90,
            'Semi final': 300.40,
            'Final': 400.00
        }
    }

    let ticketsPrice = tickets[ticketType][championshipStage];
    let totalTicketPrice = ticketsPrice * ticketsQuantity;

    if (totalTicketPrice > 4000) {
        totalTicketPrice *= 0.75;
        trophyPic = 'N';
    } else if (totalTicketPrice > 2500) {
        totalTicketPrice *= 0.9;
    }

    if (trophyPic === 'Y') {
        totalTicketPrice += ticketsQuantity * 40;
    }
    console.log(totalTicketPrice.toFixed(2));
}

solve('Semi final', 'VIP', 9, 'Y');