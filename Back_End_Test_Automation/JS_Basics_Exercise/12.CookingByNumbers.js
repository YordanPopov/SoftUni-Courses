function cookNumber(number, op1, op2, op3, op4, op5) {
    number = Number(number);

    function executeOperation(number, operation) {
        switch (operation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break; 
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
                break;   
        }
    
        return number;
    }

    number = executeOperation(number, op1);
    console.log(number);
    number = executeOperation(number, op2);
    console.log(number);
    number = executeOperation(number, op3);
    console.log(number);
    number = executeOperation(number, op4);
    console.log(number);
    number = executeOperation(number, op5);
    console.log(number);
}



//cookNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookNumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
