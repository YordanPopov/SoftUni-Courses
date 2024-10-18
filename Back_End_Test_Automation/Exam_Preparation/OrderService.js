export const orderService = {
    orders: [
        { id: "1", product: "Laptop", amount: 1200 },
        { id: "2", product: "Phone", amount: 800 },
        { id: "3", product: "Tablet", amount: 600 }
    ],
    
    getOrders() {
        return { status: 200, data: this.orders };
    },
    
    createOrder(order) {
        if (!order.id || !order.product || !order.amount) {
            return { status: 400, error: "Invalid Order Data!" };
        }
        this.orders.push(order);
        return { status: 201, message: "Order created successfully." };
    },
    
    cancelOrder(orderId) {
        const orderIndex = this.orders.findIndex(order => order.id === orderId);
        if (orderIndex === -1) {
            return { status: 404, error: "Order Not Found!" };
        }
        this.orders.splice(orderIndex, 1);
        return { status: 200, message: "Order canceled successfully." };
    },
    
    updateOrder(orderId, newOrder) {
        const orderIndex = this.orders.findIndex(order => order.id === orderId);
        if (orderIndex === -1) {
            return { status: 404, error: "Order Not Found!" };
        }
        if (!newOrder.id || !newOrder.product || !newOrder.amount) {
            return { status: 400, error: "Invalid Order Data!" };
        }
        this.orders[orderIndex] = newOrder;
        return { status: 200, message: "Order updated successfully." };
    },
    
    getOrderById(orderId) {
        const order = this.orders.find(order => order.id === orderId);
        if (!order) {
            return { status: 404, error: "Order Not Found!" };
        }
        return { status: 200, data: order };
    }
};
