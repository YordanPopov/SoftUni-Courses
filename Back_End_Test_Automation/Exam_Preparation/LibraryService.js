const libraryService = {
    libraries: [
        { id: "1", name: "Central Library", location: "Downtown" },
        { id: "2", name: "Community Library", location: "Suburbs" },
        { id: "3", name: "City Library", location: "Uptown" }
    ],
    
    getLibraries() {
        return { status: 200, data: this.libraries };
    },
    
    addLibrary(library) {
        if (!library.id || !library.name || !library.location) {
            return { status: 400, error: "Invalid Library Data!" };
        }
        this.libraries.push(library);
        return { status: 201, message: "Library added successfully." };
    },
    
    deleteLibrary(libraryId) {
        const libraryIndex = this.libraries.findIndex(library => library.id === libraryId);
        if (libraryIndex === -1) {
            return { status: 404, error: "Library Not Found!" };
        }
        this.libraries.splice(libraryIndex, 1);
        return { status: 200, message: "Library deleted successfully." };
    },
    
    updateLibrary(libraryId, newLibrary) {
        const libraryIndex = this.libraries.findIndex(library => library.id === libraryId);
        if (libraryIndex === -1) {
            return { status: 404, error: "Library Not Found!" };
        }
        if (!newLibrary.id || !newLibrary.name || !newLibrary.location) {
            return { status: 400, error: "Invalid Library Data!" };
        }
        this.libraries[libraryIndex] = newLibrary;
        return { status: 200, message: "Library updated successfully." };
    },
    
    getLibraryById(libraryId) {
        const library = this.libraries.find(library => library.id === libraryId);
        if (!library) {
            return { status: 404, error: "Library Not Found!" };
        }
        return { status: 200, data: library };
    }
};
