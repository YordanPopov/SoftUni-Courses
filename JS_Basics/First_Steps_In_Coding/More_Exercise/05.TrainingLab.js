function calcWorkingPlaces(lengthInMeters, widthInMeters) {
    let workplaceWidth = 70;
    let workplaceLength = 120;

    let widthInCm = widthInMeters * 100;
    let lengthInCm = lengthInMeters * 100;

    function calcTotalWorkPlaces(widthInCm, workplaceWidth, lengthInCm, workplaceLength) {
        let deskPerRow = parseInt((widthInCm - 100) / workplaceWidth);
        let rows = parseInt(lengthInCm / workplaceLength);
        return deskPerRow * rows;
    }

    let lostPlaces = 3;
    let finalWorkplaces = calcTotalWorkPlaces(widthInCm, workplaceWidth, lengthInCm, workplaceLength) - lostPlaces;

    console.log(finalWorkplaces);
}

calcWorkingPlaces(15, 8.9);
calcWorkingPlaces(8.4, 5.2);