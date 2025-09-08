// Define the Contact interface
interface Contact {
    id: number;
    name: string;
    email: string;
    phone: string;
}

// Implement the ContactManager class
class ContactManager {
    private contacts: Contact[] = [];
    private nextId: number = 1;

    // Method to add a new contact
    addContact(contact: Omit<Contact, 'id'>): void {
        const newContact: Contact = { ...contact, id: this.nextId++ };
        this.contacts.push(newContact);
        console.log(`Contact added: ${newContact.name}`);
    }

    // Method to view all contacts
    viewContacts(): Contact[] {
        return this.contacts;
    }

    // Method to modify an existing contact
    modifyContact(id: number, updatedContact: Partial<Omit<Contact, 'id'>>): void {
        const contactIndex = this.contacts.findIndex(contact => contact.id === id);
        if (contactIndex === -1) {
            console.error(`Error: Contact with ID ${id} does not exist.`);
            return;
        }
        this.contacts[contactIndex] = { ...this.contacts[contactIndex], ...updatedContact };
        console.log(`Contact modified: ${this.contacts[contactIndex].name}`);
    }

    // Method to delete a contact
    deleteContact(id: number): void {
        const contactIndex = this.contacts.findIndex(contact => contact.id === id);
        if (contactIndex === -1) {
            console.error(`Error: Contact with ID ${id} does not exist.`);
            return;
        }
        const deletedContact = this.contacts.splice(contactIndex, 1);
        console.log(`Contact deleted: ${deletedContact[0].name}`);
    }
}

// Testing the ContactManager class
const contactManager = new ContactManager();

// Adding contacts
contactManager.addContact({ name: "Sai", email: "sai@gmail.com", phone: "123-456-7890" });
contactManager.addContact({ name: "John", email: "john@gmail.com", phone: "098-765-4321" });

// Viewing contacts
console.log("All Contacts:", contactManager.viewContacts());

// Modifying a contact
contactManager.modifyContact(1, { email: "sai_updated@gmail.com" });

// Attempting to modify a non-existent contact
contactManager.modifyContact(3, { name: "Non-existent Contact" });

// Deleting a contact
contactManager.deleteContact(2);

// Attempting to delete a non-existent contact
contactManager.deleteContact(3);

// Viewing contacts after modifications and deletions
console.log("All Contacts after modifications:", contactManager.viewContacts());
