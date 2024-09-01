function validatePassword(password) {
    let isValidLength = password.length >= 6 && password.length <= 10;
    let isValidContent = /^[a-zA-Z0-9]+$/.test(password);
    let isValidCount = (password.match(/\d/g) || []).length >= 2;

    if (isValidLength && isValidContent && isValidCount) {
        console.log('Password is valid');
    }else {
        if (!isValidLength) {
            console.log('Password must be between 6 and 10 characters');        
        }

        if (!isValidContent) {
            console.log('Password must consist only of letters and digits');     
        }

        if (!isValidCount) {
            console.log('Password must have at least 2 digits');
        }
    }
}

//validatePassword('logIn');
validatePassword('MyPass123');
//validatePassword('Pa$s$s');