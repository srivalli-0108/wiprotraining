var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
// Implement the ContactManager class
var ContactManager = /** @class */ (function () {
    function ContactManager() {
        this.contacts = [];
        this.nextId = 1;
    }
    // Method to add a new contact
    ContactManager.prototype.addContact = function (contact) {
        var newContact = __assign(__assign({}, contact), { id: this.nextId++ });
        this.contacts.push(newContact);
        console.log("Contact added: ".concat(newContact.name));
    };
    // Method to view all contacts
    ContactManager.prototype.viewContacts = function () {
        return this.contacts;
    };
    // Method to modify an existing contact
    ContactManager.prototype.modifyContact = function (id, updatedContact) {
        var contactIndex = this.contacts.findIndex(function (contact) { return contact.id === id; });
        if (contactIndex === -1) {
            console.error("Error: Contact with ID ".concat(id, " does not exist."));
            return;
        }
        this.contacts[contactIndex] = __assign(__assign({}, this.contacts[contactIndex]), updatedContact);
        console.log("Contact modified: ".concat(this.contacts[contactIndex].name));
    };
    // Method to delete a contact
    ContactManager.prototype.deleteContact = function (id) {
        var contactIndex = this.contacts.findIndex(function (contact) { return contact.id === id; });
        if (contactIndex === -1) {
            console.error("Error: Contact with ID ".concat(id, " does not exist."));
            return;
        }
        var deletedContact = this.contacts.splice(contactIndex, 1);
        console.log("Contact deleted: ".concat(deletedContact[0].name));
    };
    return ContactManager;
}());
// Testing the ContactManager class
var contactManager = new ContactManager();
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
