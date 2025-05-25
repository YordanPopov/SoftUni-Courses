function solve(city, sales) {
    let comission = 0;
    let isValid = true;

    switch (city) {
        case 'Sofia':
            if (sales >= 0 && sales <= 500) {
                comission = sales * 0.05;
            } else if (sales > 500 && sales <= 1000) {
                comission = sales * 0.07;
            } else if (sales > 1000 && sales <= 10_000) {
                comission = sales * 0.08;
            } else if (sales > 10_000) {
                comission = sales * 0.12;
            } else {
                isValid = false;
            }
            break;
        case 'Varna':
            if (sales >= 0 && sales <= 500) {
                comission = sales * 0.045;
            } else if (sales > 500 && sales <= 1000) {
                comission = sales * 0.075;
            } else if (sales > 1000 && sales <= 10_000) {
                comission = sales * 0.1;
            } else if (sales > 10_000) {
                comission = sales * 0.13;
            } else {
                isValid = false;
            }
            break;
        case 'Plovdiv':
            if (sales >= 0 && sales <= 500) {
                comission = sales * 0.055;
            } else if (sales > 500 && sales <= 1000) {
                comission = sales * 0.08;
            } else if (sales > 1000 && sales <= 10_000) {
                comission = sales * 0.12;
            } else if (sales > 10_000) {
                comission = sales * 0.145;
            } else {
                isValid = false;
            }
            break;
        default:
            isValid = false;
            break;
    }

    if (!isValid) {
        console.log('error');
    } else {
        console.log(comission.toFixed(2));
    }
}

solve('Varna', -50);