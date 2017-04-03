contactsApp.onClickFunctions = function () {
//Button activities

    function onClicked() {
        var contact = buildInputContact();

        if (modifyIndex > -1) {
            onEdit(modifyIndex);
        }
        else {
            contactsApp.contactStore.saveContact(contact);
        }
        contactsApp.contactTableHelper.fillTable();
        modifyIndex = -1;
        document.getElementById("addButton").innerText = 'Add';
        emptyInputs();
    }

    function emptyInputs() {
        var inputs = document.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
            inputs[i].value = '';
        }
    }

    function buildInputContact() {

        var contact = contactsApp.contact(
            document.getElementById('firstName').value,
            document.getElementById('lastName').value,
            document.getElementById('phone').value,
            document.getElementById('street').value,
            document.getElementById('city').value
        );
        return contact;
    }

    function startEdit(editIndex) {
        var contacts = contactsApp.contactStore.loadContacts();
        document.getElementById("firstName").value = contacts[editIndex].firstName;
        document.getElementById("lastName").value = contacts[editIndex].lastName;
        document.getElementById("phone").value = contacts[editIndex].phone;
        document.getElementById("street").value = contacts[editIndex].street;
        document.getElementById("city").value = contacts[editIndex].city;
        document.getElementById("addButton").innerText = 'Edit';
    }

    function onEdit(editIndex) {
        var contact = buildInputContact();
        contactsApp.contactStore.editItem(contact, editIndex);
        contactsApp.contactTableHelper.fillTable();
    }

    function onDelete(delIndex) {
        if (modifyIndex > -1) {
            alert('Hello, edit first');
            return;
        }
        contactsApp.contactStore.removeItem(delIndex);
        contactsApp.contactTableHelper.fillTable();
    }

    return {
        onClicked: function () {
            onClicked();
        },
        startEdit: function (editIndex) {
            modifyIndex = editIndex;
            startEdit(editIndex);
        },
        onDelete: function (delIndex) {
            onDelete(delIndex);
        }
    }

}
