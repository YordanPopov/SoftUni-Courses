function solve(users) {
    function getUsersByDepartment(department) {
        return users.filter(user => user.department === department);
    }

    function addUser(id, name, department, salary, active) {
        const newUser = {
            id: id,
            name: name,
            department: department,
            salary: salary,
            active: active
        }

         users.push(newUser);

         return users;
    }

    function getUserById(id) {
        const userIndex = users.findIndex(user => user.id === id);

        if (userIndex === -1) {
            return `User with ID ${id} not found`;
        }

        for (const user of users) {
            if(Object.values(user).includes(id)){
                return user;
            }    
        }
    }

    function removeUserById(id) {
        const userIndex = users.findIndex(user => user.id === id);

        if (userIndex === -1) {
            return `User with ID ${id} not found`;
        }

        users.splice(userIndex, 1);

        return users;
    }

    function updateUserSalary(id, newSalary) {
        const userIndex = users.findIndex(user => user.id === id);

        if (userIndex === -1) {
            return `User with ID ${id} not found`;
        }

        for (const user of users) {
            if(Object.values(user).includes(id)){
                user.salary = newSalary;
            }    
        }

        return users;
    }

    function updateUserActiveStatus(id, newStatus) {
        const userIndex = users.findIndex(user => user.id === id);

        if (userIndex === -1) {
            return `User with ID ${id} not found`;
        }

        for (const user of users) {
            if(Object.values(user).includes(id)){
                user.active = newStatus;
            }    
        }

        return users;
    }

    return {
        getUsersByDepartment,
        addUser,
        getUserById,
        removeUserById,
        updateUserSalary,
        updateUserActiveStatus
    };
}

let users = [
    { id: 1, name: "Alice", department: "HR", salary: 50000, active: true },
    { id: 2, name: "Bob", department: "IT", salary: 70000, active: true },
    { id: 3, name: "Charlie", department: "Finance", salary: 60000, active: false },
    { id: 4, name: "David", department: "IT", salary: 80000, active: true }
];

const company = solve(users);

//console.log(company.getUsersByDepartment("IT"));
//console.log(company.addUser(5, "Eve", "Marketing", 55000, true));
//console.log(company.getUserById(1));
//console.log((company.removeUserById(3)));
//console.log(company.updateUserSalary(2, 75000));
//console.log(company.updateUserActiveStatus(4, false));


