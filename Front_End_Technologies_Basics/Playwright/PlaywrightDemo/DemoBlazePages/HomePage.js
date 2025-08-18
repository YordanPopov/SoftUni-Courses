export class HomePage {
    constructor(page) {
        this.page = page;
        this.welcomeLink = '#nameofuser';
        this.cartLink = '#cartur';
        this.productsList = 'div.card-block h4.card-title a';
        this.addToCartBtn = 'a[onclick="addToCart(3)"]';
    }

    async AddProductToCart(productName) {
        const products = await this.page.$$(this.productsList);

        for (const product of products) {
            if (productName === await product.textContent()) {
                await product.click();
                break;
            }
        }

        this.page.on('dialog', async dialog => {
            if (dialog.type().includes('alert') && dialog.message().includes('Product added.')) {
                await dialog.accept();
            }
        });

        await this.page.click(this.addToCartBtn);
    }

    async OpenCart(){
        await this.page.click(this.cartLink);
    }
}