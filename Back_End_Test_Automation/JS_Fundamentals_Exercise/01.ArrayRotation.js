function rotateArray(array, countRotation) {
    for (let count = 1; count <= countRotation; count++){
        let firstElement = array.shift();
        array.push(firstElement);
    }

    console.log(array.join(' '));
}

rotateArray([51, 47, 32, 61, 21], 2);
rotateArray([32, 21, 61, 1], 4);
rotateArray([2, 4, 15, 31], 5);