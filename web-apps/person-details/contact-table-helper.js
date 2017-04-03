contactsApp.contactTableHelper = (function () {



        function fillTable() {
            var contacts = contactsApp.contactStore.loadContacts();
            var table = document.getElementById("resultsTable");
            table.innerHTML = '';
            var i = 0;
            contacts.forEach(function (contact) {
                var row = table.insertRow(table.rows.length);
                var fName = row.insertCell(0);
                var lName = row.insertCell(1);
                var pho = row.insertCell(2);
                var address = row.insertCell(3);
                var edit = row.insertCell(4);
                var del = row.insertCell(5);

                fName.innerText = contact.firstName;
                lName.innerText = contact.lastName;
                pho.innerText = contact.phone;
                address.innerHTML = googleAddress(contact.street, contact.city);
                edit.innerHTML = '<button class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect" onclick="contactsApp.onClickFunctions().startEdit(' + i + ')">Edit</button>';
                del.innerHTML = '<button class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect" onclick="contactsApp.onClickFunctions().onDelete(' + i + ')">Delete</button>';

                i++;
            });
        }

        function googleAddress(street, city) {
            return '<a href="https://www.google.fi/maps/place/' + street + ',+' + city + '" target="_blank">' + street + ' , ' + city + '</a>';
        }

        return {
            fillTable: function () {
                var getContacts = contactsApp.contactStore.loadContacts();
                fillTable(getContacts);
            }

        }
    })();