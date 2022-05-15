// Create the customer
function createCustomer(name, phone, agencyId) {
        let obj = {
            phone: phone,
            customerName: name,
            travelAgencyId: agencyId
        };
        let body = JSON.stringify(obj);
        console.log(body);
        let createRequest = fetch("http://localhost:50867/Customers/", {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
            },
            body: body
        }).then((resp) => {
            if (resp.ok) {
                alert('Successfully Created');
            } else {
                alert('Error!!, ' + resp.text);
                console.log(resp.text)
            }
        }).catch((err) => {
            alert('Fatal Error');
        });
}

function findCustomerById(id) {
        let url = "http://localhost:50867/Customers?customerId=" + id;
        let getReq = fetch(url).then(res => {
            if (res.ok) {
                let resp = res.json().then(data => {
                    let arr = [];
                    arr.push(data);
                    insertIntoTable(arr);
                });
            } else {
                alert("Request failed");
            }
        }).catch(err => {
            alert('Error');
        });
}

function findAllCustomers() {
    let url = "http://localhost:50867/Customers/all";
    let getReq = fetch(url).then(res => {
        if (res.ok) {
            let resp = res.json().then(data => {
                insertIntoTable(data);
            });
        } else {
            alert("Request failed");
        }
    }).catch(err => {
        alert('Error');
    });
}

function editCustomer(id, name, phone) {
    let obj = {
        id,
        phoneNumber: phone,
        customerName: name
    };
    let editReq = fetch("http://localhost:50867/Customers/", {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(obj)
    }).then(resp => {
        if (resp.ok) {
            alert('Edited Successfully');
        } else {
            alert('Request Failed');
        }
    }).catch(err => {
        alert('Error');
    });
}
function deleteCustomer(id) {
    let url = "http://localhost:50867/Customers/" + id;
    let delReq = fetch(url, {
        method: 'DELETE',
        mode: 'cors'
    }).then(res => {
        if (res.ok) {
            alert('Deleted Succesfully');
        } else {
            alert('Request Failed');
        }
    }).catch(err => {
        alert('Error');
    });
}
function handleDeleteOnClick(evt) {
    let id = evt.target.id;
    let customerId = id.split('-')[1];
    console.log(customerId);
    deleteCustomer(customerId);
}

function handleEditOnClick(evt) {
    let id = evt.target.id.split('-')[1];
    let name = $(evt.target).data('name');
    let phone = $(evt.target).data('phone');

    let editForm = document.getElementById('edit-form');
    document.getElementById('edit-id').value = id;
    document.getElementById('edit-name').value = name;
    document.getElementById('edit-phone').value = phone;
    editForm.classList.toggle('hidden');
}

function insertIntoTable(arr) {
    clearAllFromTable();
    for (let i = 0; i < arr.length; i++) {
        let row = document.createElement('tr');
        let id = document.createElement('td');
        let name = document.createElement('td');
        let btns = document.createElement('td');

        let del = document.createElement('button');
        del.id = 'del-' + arr[i].id;
        del.innerHTML = 'Delete';
        del.className = "btn btn-danger float-right ml-2";
        del.onclick = handleDeleteOnClick;
        btns.appendChild(del);

        let edit = document.createElement('button');
        edit.id = 'edit-' + arr[i].id;
        edit.innerHTML = 'Edit';
        edit.setAttribute('data-name', arr[i].name);
        edit.setAttribute('data-phone', arr[i].phone);
        edit.setAttribute('data-toggle', 'modal');
        edit.setAttribute('data-target', '#editModal');
        edit.className = "btn btn-success float-right";
        edit.onclick = handleEditOnClick;
        btns.appendChild(edit);

        name.innerText = arr[i].name;
        id.innerText = arr[i].id;

        row.appendChild(id);
        row.appendChild(name);
        row.appendChild(btns);
        document.getElementById('data-table').appendChild(row);
    }
}

function clearAllFromTable() {
    var items = document.querySelectorAll('#data-table > tr');
    for (let i = 0; i < items.length; i++) {
        items[i].remove();
    }
}
let createButton = document.getElementById('create-button');
createButton.onclick = () => {
    clearAllFromTable();
    let name = document.getElementById('create-name').value;
    let phone = document.getElementById('create-phone').value;
    let agencyId = document.getElementById('create-agencyId').value;
    phone = parseInt(phone);
    agencyId = parseInt(agencyId);
    createCustomer(name, phone, agencyId);
};

let getByIdButton = document.getElementById('get-by-id');
getByIdButton.onclick = () => {
    let id = document.getElementById('id-input').value;
    findCustomerById(id);
};

let allBtn = document.getElementById('all-customer');
allBtn.onclick = () => {
    findAllCustomers();
};

let editCustomerBtn = document.getElementById('edit-customer');

editCustomerBtn.onclick = () => {
    let id = document.getElementById('edit-id').value;
    let name = document.getElementById('edit-name').value;
    let phone = document.getElementById('edit-phone').value;
    clearAllFromTable();
    editCustomer(id, name, phone);
}