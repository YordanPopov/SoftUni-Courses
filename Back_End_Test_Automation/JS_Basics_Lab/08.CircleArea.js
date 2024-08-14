function printCircleArea(radius) {
    let typeOfArg = typeof(radius);
    let area;

    if (typeOfArg === 'number') {
        area = Math.pow(radius, 2) * Math.PI;
        console.log(area.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we received a ${typeOfArg}.`);
    }
}

printCircleArea(5);
printCircleArea('name');