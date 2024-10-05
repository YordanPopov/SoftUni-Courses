function cookTheNumber(inputArr = []) {
    let number = Number(inputArr.shift());

    for (const op of inputArr) {
        switch (op) {
            case 'chop': number /= 2; break;
            case 'dice': number = Math.sqrt(number); break;
            case 'spice': number++; break;
            case 'bake': number *= 3; break;
            case 'fillet': number *= 0.8; break;
        }

        console.log(number);      
    }
}



cookTheNumber(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
cookTheNumber(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);
