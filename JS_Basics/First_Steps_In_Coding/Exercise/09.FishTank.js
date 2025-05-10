function caluculateNeededLiters(length, width, height, percent) {
    let volumeInLiters = (length * width * height) / 1000;
    let neededLiters = volumeInLiters * (1 - (percent / 100));

    console.log(neededLiters);
}

caluculateNeededLiters(85, 75, 47, 17);
caluculateNeededLiters(105, 77, 89, 18.5);