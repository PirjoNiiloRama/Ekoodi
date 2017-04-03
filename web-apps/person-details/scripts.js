// var contacts = [];
// var editMode = -1; //Start with smaller value than any index has
//
// function onLoad() {
//     if (typeof (Storage) !== 'undefined') {
//         var data = localStorage.getItem("data");
//         if (data == null) {
//             contacts = [];
//             return;
//         }
//         contacts = JSON.parse(data);
//         fillTable();
//     }
// }

//
//
// function saveData() {
//     localStorage.removeItem("data");
//     localStorage.setItem("data", JSON.stringify(contacts));
// }
//
// function fieldCheck() {
//     var inputs = document.getElementsByTagName("input");
//     for (var i = 0; i < inputs.length; i++) {
//         if (inputs[i].value == '') {
//             alert('Fill all fields :) ');
//             return true;
//         }
//     }
// }
//
// function createUser() {
//     return {
//         firstName: document.getElementById('firstName').value,
//         lastName: document.getElementById('lastName').value,
//         phone: document.getElementById('phone').value,
//         street: document.getElementById('street').value,
//         city: document.getElementById('city').value
//     };
// }
//
// function fillTable() {
//     var table = document.getElementById("resultsTable");
//     table.innerHTML = "<tr><th>First name</th><th>Last name</th><th>Phone</th><th>Address</th><th></th><th></th></tr>";
//     for (var i = 0; i < contacts.length; i++) {
//
//         var row = table.insertRow(table.rows.length);
//         var fName = row.insertCell(0);
//         var lName = row.insertCell(1);
//         var pho = row.insertCell(2);
//         var adress = row.insertCell(3);
//         var edit = row.insertCell(4);
//         var del = row.insertCell(5);
//
//         fName.innerText = contacts[i].firstName;
//         lName.innerText = contacts[i].lastName;
//         pho.innerText = contacts[i].phone;
//         adress.innerHTML = shoWAddress(contacts[i].street, contacts[i].city);// contacts[i].street + ' , ' + contacts[i].city;
//         edit.innerHTML = '<button class="editButton" onclick="onEdit(' + i + ')">Edit</button>';
//         del.innerHTML = '<button class="deleteButton" onclick="onDelete(' + i + ')">Delete</button>';
//
//     }
// }
//
// function showAdress(street, city) {
//     return '<a href="https://www.google.fi/maps/place/' + street + ',+' + city + '" target="_blank">' + street + ' , ' + city + '</a>';
// }
//
// function emptyInputs() {
//     var inputs = document.getElementsByTagName("input");
//     for (var i = 0; i < inputs.length; i++) {
//         inputs[i].value = '';
//     }
// }
//
// function onEdit(editIndex) {
//     document.getElementById("firstName").value = contacts[editIndex].firstName;
//     document.getElementById("lastName").value = contacts[editIndex].lastName;
//     document.getElementById("phone").value = contacts[editIndex].phone;
//     document.getElementById("street").value = contacts[editIndex].street;
//     document.getElementById("city").value = contacts[editIndex].city;
//     document.getElementById("addButton").innerText = 'Edit';
//     editMode = editIndex;
// }
//
// function onDelete(delIndex) {
//     if (editMode > -1) {
//         alert('User is in editing mode.');
//         return;
//     }
//     var editTable = [];
//     for (var i = 0; i < contacts.length; i++) {
//         if (i != delIndex) {
//             editTable.push(contacts[i]);
//         }
//     }
//     contacts = editTable;
//     saveData();
//     fillTable();
// }