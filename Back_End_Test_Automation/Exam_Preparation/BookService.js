export const bookService = {
    books: [
        { id: "1", title: "1984", author: "George Orwell", year: 1949 },
        { id: "2", title: "To Kill a Mockingbird", author: "Harper Lee", year: 1960 },
        { id: "3", title: "The Great Gatsby", author: "F. Scott Fitzgerald", year: 1925 }
    ],
    
    getBooks() {
        return { status: 200, data: this.books };
    },
    
    addBook(book) {
        if (!book.id || !book.title || !book.author || !book.year) {
            return { status: 400, error: "Invalid Book Data!" };
        }
        this.books.push(book);
        return { status: 201, message: "Book added successfully." };
    },
    
    deleteBook(bookId) {
        const bookIndex = this.books.findIndex(book => book.id === bookId);
        if (bookIndex === -1) {
            return { status: 404, error: "Book Not Found!" };
        }
        this.books.splice(bookIndex, 1);
        return { status: 200, message: "Book deleted successfully." };
    },
    
    updateBook(bookId, newBook) {
        const bookIndex = this.books.findIndex(book => book.id === bookId);
        if (bookIndex === -1) {
            return { status: 404, error: "Book Not Found!" };
        }
        if (!newBook.id || !newBook.title || !newBook.author || !newBook.year) {
            return { status: 400, error: "Invalid Book Data!" };
        }
        this.books[bookIndex] = newBook;
        return { status: 200, message: "Book updated successfully." };
    },
    
    getBookById(bookId) {
        const book = this.books.find(book => book.id === bookId);
        if (!book) {
            return { status: 404, error: "Book Not Found!" };
        }
        return { status: 200, data: book };
    }
};
