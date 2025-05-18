function calculatePaintingLiters(houseHeight, sideWallLength, roofTriangleHeight) {
    let greenPaintCoverage = 3.4;
    let redPaintCovarage = 4.3;

    let doorArea = 1.2 * 2;
    let windowArea = 1.5 * 1.5;

    let wallAreaFrontBack = 2 * (houseHeight * houseHeight);
    let newWallAreaFrontBack = wallAreaFrontBack - doorArea;
    let wallAreaSides = houseHeight * sideWallLength;
    let netWallAreaSides = 2 * wallAreaSides - 2 * windowArea;
    let totalGreenArea = newWallAreaFrontBack + netWallAreaSides;
    let greenPaintNeeded = totalGreenArea / greenPaintCoverage;

    let roofRectangleArea = 2 * (houseHeight * sideWallLength);
    let roofTriangleArea = 2 * (houseHeight * roofTriangleHeight / 2);
    let totalRedArea = roofRectangleArea + roofTriangleArea;
    let redPaintNeeded = totalRedArea / redPaintCovarage;

    console.log(greenPaintNeeded.toFixed(2));
    console.log(redPaintNeeded.toFixed(2));
}

calculatePaintingLiters(6, 10, 5.2);
calculatePaintingLiters(10, 25, 8.88);