const userService = {
    users: [
        { id: "1", name: "Alice", email: "alice@example.com" },
        { id: "2", name: "Bob", email: "bob@example.com" },
        { id: "3", name: "Charlie", email: "charlie@example.com" }
    ],

    getUsers() {
        return { status: 200, data: this.users };
    },

    addUser(user) {
        if (!user.id || !user.name || !user.email) {
            return { status: 400, error: "Invalid User Data!" };
        }
        this.users.push(user);
        return { status: 201, message: "User added successfully." };
    },

    deleteUser(userId) {
        const userIndex = this.users.findIndex(user => user.id === userId);
        if (userIndex === -1) {
            return { status: 404, error: "User Not Found!" };
        }
        this.users.splice(userIndex, 1);
        return { status: 200, message: "User deleted successfully." };
    },

    updateUser(userId, newUser) {
        const userIndex = this.users.findIndex(user => user.id === userId);
        if (userIndex === -1) {
            return { status: 404, error: "User Not Found!" };
        }
        if (!newUser.id || !newUser.name || !newUser.email) {
            return { status: 400, error: "Invalid User Data!" };
        }
        this.users[userIndex] = newUser;
        return { status: 200, message: "User updated successfully." };
    },

    getUserById(userId) {
        const user = this.users.find(user => user.id === userId);
        if (!user) {
            return { status: 404, error: "User Not Found!" };
        }
        return { status: 200, data: user };
    }
};