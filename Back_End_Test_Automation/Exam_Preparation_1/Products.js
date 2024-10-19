function solve(products) {
    function getProductsByCategory(category) {
        return products.filter(product => product.category === category);
    }

    function addProduct(id, name, category, price, stock) {
        products.push({
            id: id,
            name: name,
            category: category,
            price: price,
            stock: stock
        })

        return products;
    }

    function getProductById(id) {
        const productIndex = products.findIndex(product => product.id === id);

        if (productIndex === -1) {
            return `Product with ID ${id} not found`;
        }

        for (const product of products) {
            if (Object.values(product).includes(id)) {
                return product;
            }
        }
    }

    function removeProductById(id) {
        const productIndex = products.findIndex(product => product.id === id);

        if (productIndex === -1) {
            return `Product with ID ${id} not found`;
        }
        products.splice(productIndex, 1);
        return products;
    }

    function updateProductPrice(id, newPrice) {
        const productIndex = products.findIndex(product => product.id === id);

        if (productIndex === -1) {
            return `Product with ID ${id} not found`;
        }
        for (const product of products) {
            if (Object.values(product).includes(id)) {
                product.price = newPrice;
            }
        }

        return products;
    }

    function updateProductStock(id, newStock) {
        const productIndex = products.findIndex(product => product.id === id);

        if (productIndex === -1) {
            return `Product with ID ${id} not found`;
        }
        
        for (const product of products) {
            if (Object.values(product).includes(id)) {
                product.stock = newStock;
            }
        }

        return products;
    }

    return {
        getProductsByCategory,
        addProduct,
        getProductById,
        removeProductById,
        updateProductPrice,
        updateProductStock
    };
}

const products = [
    { id: 1, name: "Laptop", category: "Electronics", price: 1200, stock: 30 },
    { id: 2, name: "Smartphone", category: "Electronics", price: 800, stock: 50 },
    { id: 3, name: "Headphones", category: "Accessories", price: 150, stock: 100 }
];

const store = solve(products);
//store.addProduct(4, 'Tablet', 'Electronics', 300, 7);
//console.log(store.getProductsByCategory('Electronics'));
//console.log(store.getProductById(4));
//console.log(store.removeProductById(4));
//console.log(store.updateProductPrice(5, 350));
//console.log(store.updateProductStock(5, 100));








