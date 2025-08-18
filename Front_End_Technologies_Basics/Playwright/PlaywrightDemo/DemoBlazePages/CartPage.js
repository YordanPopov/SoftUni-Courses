export class CartPage {
    constructor(page) {
        this.page = page;
        this.numberOfProducts = '#tbodyid tr td:nth-child(2)';
    }

    async CheckProductInCart(productName) {
        await this.page.waitForSelector(this.numberOfProducts);

        const productsInCart = await this.page.$$(this.numberOfProducts);
        for (const product of productsInCart) {
            if (productName === await product.textContent()) {
                return true;
            }
        }

        return false;
    }
}