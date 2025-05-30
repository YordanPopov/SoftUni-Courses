function solve(x1, y1, x2, y2, x, y) {
    const onLeftOrRight = (x === x1 || x === x2) && (y >= y1 && y <= y2);
    const onTopOrBottom = (y === y1 || y === y2) && (x >= x1 && x <= x2);

    if (onLeftOrRight || onTopOrBottom) {
        console.log('Border');
    } else {
        console.log('Inside / Outside');
    }
}

solve(2, -3, 12, 3, 12, -1);