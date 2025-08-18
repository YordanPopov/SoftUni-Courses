export class LoginPage {

    constructor(page) {
        this.page = page;
        this.loginLink = '#login2';
        this.usernameInput = '#loginusername';
        this.passwordInput = '#loginpassword';
        this.loginBtn = 'button[onclick="logIn()"]';
    }

    async GotoLoginPage() {
        await this.page.goto('https://demoblaze.com/index.html');
        await this.page.click(this.loginLink);
    }

    async Login(username, password) {
        await this.page.fill(this.usernameInput, username);
        await this.page.fill(this.passwordInput, password);
        await this.page.click(this.loginBtn);
    }
}