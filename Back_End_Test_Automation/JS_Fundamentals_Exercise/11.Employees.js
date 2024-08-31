/**
 * 
 * @param {Array} employees 
 */
function printEmployeesInfo(employees) {
    const employeesData = [];

    for (const employee of employees) {
        employeesData.push({
            name: employee,
            personalNumber: employee.length
        });
    }

    employeesData.forEach((employee) =>
         console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`));
}

printEmployeesInfo(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
console.log('---------------------');
printEmployeesInfo(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);    