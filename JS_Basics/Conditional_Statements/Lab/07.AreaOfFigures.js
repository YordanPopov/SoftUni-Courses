function calcArea(arg1, arg2, arg3) {
    let figureType = arg1;

    if (figureType === 'square') {
        squareArea(Number(arg2));
    } else if (figureType === 'rectangle') {
        rectangleArea(Number(arg2), Number(arg3));
    } else if (figureType === 'circle') {
        circleArea(Number(arg2));
    } else if (figureType === 'triangle') {
        triangleArea(Number(arg2), Number(arg3))
    }

    function squareArea(a) {
        let area = a * a;
        console.log(area.toFixed(3));
    }

    function rectangleArea(a, b) {
        let area = a * b;
        console.log(area.toFixed(3));
    }

    function circleArea(r) {
        let area = Math.PI * Math.pow(r, 2);
        console.log(area.toFixed(3));
    }

    function triangleArea(b, h) {
        let area = b * h * 0.5;
        console.log(area.toFixed(3));
    }
}

calcArea("square", 5);
calcArea("rectangle", 7, 2.5);
calcArea("circle", 6);
calcArea("triangle", 4.5, 20);