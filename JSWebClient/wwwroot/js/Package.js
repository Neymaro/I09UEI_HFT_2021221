// Create the customer
function createPackage(name, price, agencyId, category) {
        let obj = {
            Price: price,
            Name: name,
            Category: category,
            TravelAgencyId: agencyId
        };
        let body = JSON.stringify(obj);
        console.log(body);
    let createRequest = fetch("http://localhost:50867/Packages/", {
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

function findPackageById(id) {
    let url = "http://localhost:50867/Packages?id=" + id;
        let getReq = fetch(url).then(res => {
            if (res.ok) {
                let resp = res.json().then(data => {
                    let arr = [];
                    arr.push(data);
                    insertIntoPackageTable(arr);
                });
            } else {
                alert("Request failed");
            }
        }).catch(err => {
            alert('Error');
        });
}

function findAllPackages() {
    let url = "http://localhost:50867/Packages/all";
    let getReq = fetch(url).then(res => {
        if (res.ok) {
            let resp = res.json().then(data => {
                insertIntoPackageTable(data);
            });
        } else {
            alert("Request failed");
        }
    }).catch(err => {
        alert('Error');
    });
}

function editPackage(id, name, price, category) {
    let obj = {
        id,
        Price: price,
        Category: category,
        Name: name
    };
    let editReq = fetch("http://localhost:50867/Packages", {
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
function deletePackage(id) {
    let url = "http://localhost:50867/Packages?id=" + id;
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
function handleDeleteOnClickPackage(evt) {
    let id = evt.target.id;
    let PackageId = id.split('-')[1];
    console.log(PackageId);
    deletePackage(PackageId);
}

function handleEditOnClickPackage(evt) {
    let id = evt.target.id.split('-')[1];
    let name = $(evt.target).data('name');
    let price = $(evt.target).data('price');
    let category = $(evt.target).data('category');

    let editForm = document.getElementById('editModal');
    document.getElementById('edit-id-Package').value = id;
    document.getElementById('edit-name-Package').value = name;
    document.getElementById('edit-price-Package').value = price;
    document.getElementById('edit-category-Package').value = category;
    editForm.classList.toggle('hidden');
}

function insertIntoPackageTable(arr) {
    clearAllFromPackageTable();
    for (let i = 0; i < arr.length; i++) {
        let row = document.createElement('tr');
        let id = document.createElement('td');
        let name = document.createElement('td');
        let btns = document.createElement('td');

        let del = document.createElement('button');
        del.id = 'del-' + arr[i].id;
        del.innerHTML = 'Delete';
        del.className = "btn btn-danger float-right ml-2";
        del.onclick = handleDeleteOnClickPackage;
        btns.appendChild(del);

        let edit = document.createElement('button');
        edit.id = 'edit-' + arr[i].id;
        edit.innerHTML = 'Edit';
        edit.setAttribute('data-name', arr[i].name);
        edit.setAttribute('data-price', arr[i].price);
        edit.setAttribute('data-category', arr[i].category);
        edit.setAttribute('data-toggle', 'modal');
        edit.setAttribute('data-target', '#editModal');
        edit.className = "btn btn-success float-right";
        edit.onclick = handleEditOnClickPackage;
        btns.appendChild(edit);

        name.innerText = arr[i].name;
        id.innerText = arr[i].id;

        row.appendChild(id);
        row.appendChild(name);
        row.appendChild(btns);
        document.getElementById('data-table').appendChild(row);
    }
}

function clearAllFromPackageTable() {
    var items = document.querySelectorAll('#data-table > tr');
    for (let i = 0; i < items.length; i++) {
        items[i].remove();
    }
}
let createButtonP = document.getElementById('create-button-Package');
createButtonP.onclick = () => {
    clearAllFromPackageTable();
    let name = document.getElementById('create-name').value;
    let phone = document.getElementById('create-price').value;
    let category = document.getElementById('create-category').value;
    let agencyId = document.getElementById('create-agencyId').value;
    price = parseInt(phone);
    agencyId = parseInt(agencyId);
    createPackage(name, price, agencyId, category);
};

let getByIdButtonP = document.getElementById('get-by-id');
getByIdButtonP.onclick = () => {
    let id = document.getElementById('id-input').value;
    findPackageById(id);
};

let allBtnP = document.getElementById('all-Package');
allBtnP.onclick = () => {
    findAllPackages();
};

let editPBtn = document.getElementById('edit-Package');

editPBtn.onclick = () => {
    let id = document.getElementById('edit-id-Package').value;
    let name = document.getElementById('edit-name-Package').value;
    let phone = document.getElementById('edit-price-Package').value;
    let category = document.getElementById('edit-category-Package').value;
    clearAllFromPackageTable();
    editPackage(id, name, phone, category);
}