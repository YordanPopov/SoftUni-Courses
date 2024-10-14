const productService = {
    products: [
        { id: "1", name: "Laptop", price: 1500 },
        { id: "2", name: "Phone", price: 800 },
        { id: "3", name: "Tablet", price: 600 }
    ],
    
    getProducts() {
        return { status: 200, data: this.products };
    },
    
    addProduct(product) {
        if (!product.id || !product.name || product.price == null) {
            return { status: 400, error: "Invalid Product Data!" };
        }
        this.products.push(product);
        return { status: 201, message: "Product added successfully." };
    },
    
    deleteProduct(productId) {
        const productIndex = this.products.findIndex(product => product.id === productId);
        if (productIndex === -1) {
            return { status: 404, error: "Product Not Found!" };
        }
        this.products.splice(productIndex, 1);
        return { status: 200, message: "Product deleted successfully." };
    },
    
    updateProduct(productId, newProduct) {
        const productIndex = this.products.findIndex(product => product.id === productId);
        if (productIndex === -1) {
            return { status: 404, error: "Product Not Found!" };
        }
        if (!newProduct.id || !newProduct.name || newProduct.price == null) {
            return { status: 400, error: "Invalid Product Data!" };
        }
        this.products[productIndex] = newProduct;
        return { status: 200, message: "Product updated successfully." };
    },
    
    getProductById(productId) {
        const product = this.products.find(product => product.id === productId);
        if (!product) {
            return { status: 404, error: "Product Not Found!" };
        }
        return { status: 200, data: product };
    }
};
