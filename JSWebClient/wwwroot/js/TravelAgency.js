// Create the customer
function createTravelAgency(name, rating) {
        let obj = {
            Point: rating,
            Name: name
        };
        let body = JSON.stringify(obj);
        console.log(body);
    let createRequest = fetch("http://localhost:50867/TravelAgencies/", {
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

function findTravelAgencyById(id) {
    let url = "http://localhost:50867/TravelAgencies?id=" + id;
        let getReq = fetch(url).then(res => {
            if (res.ok) {
                let resp = res.json().then(data => {
                    let arr = [];
                    arr.push(data);
                    insertIntoTravelAgencyTable(arr);
                });
            } else {
                alert("Request failed");
            }
        }).catch(err => {
            alert('Error');
        });
}

function findAllTravelAgencies() {
    let url = "http://localhost:50867/TravelAgencies/all";
    let getReq = fetch(url).then(res => {
        if (res.ok) {
            let resp = res.json().then(data => {
                insertIntoTravelAgencyTable(data);
            });
        } else {
            alert("Request failed");
        }
    }).catch(err => {
        alert('Error');
    });
}

function editTravleAgency(id, name, rating) {
    let obj = {
        id,
        Rating: rating,
        Name: name
    };
    let editReq = fetch("http://localhost:50867/TravelAgencies", {
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
function deleteTravelAgency(id) {
    let url = "http://localhost:50867/TravelAgencies?id=" + id;
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
function handleDeleteOnClickTravelAgency(evt) {
    let id = evt.target.id;
    let travelAgencyId = id.split('-')[1];
    console.log(travelAgencyId);
    deleteTravelAgency(travelAgencyId);
}

function handleEditOnClickTravelAgency(evt) {
    let id = evt.target.id.split('-')[1];
    let name = $(evt.target).data('name');
    let rating = $(evt.target).data('rating');

    let editForm = document.getElementById('editModal');
    document.getElementById('edit-id-travelagency').value = id;
    document.getElementById('edit-name-travelagency').value = name;
    document.getElementById('edit-rating-travelagency').value = rating;
    editForm.classList.toggle('hidden');
}

function insertIntoTravelAgencyTable(arr) {
    clearAllFromTravelAgencyTable();
    for (let i = 0; i < arr.length; i++) {
        let row = document.createElement('tr');
        let id = document.createElement('td');
        let name = document.createElement('td');
        let btns = document.createElement('td');

        let del = document.createElement('button');
        del.id = 'del-' + arr[i].id;
        del.innerHTML = 'Delete';
        del.className = "btn btn-danger float-right ml-2";
        del.onclick = handleDeleteOnClickTravelAgency;
        btns.appendChild(del);

        let edit = document.createElement('button');
        edit.id = 'edit-' + arr[i].id;
        edit.innerHTML = 'Edit';
        edit.setAttribute('data-name', arr[i].name);
        edit.setAttribute('data-rating', arr[i].rating);
        edit.setAttribute('data-toggle', 'modal');
        edit.setAttribute('data-target', '#editModal');
        edit.className = "btn btn-success float-right";
        edit.onclick = handleEditOnClickTravelAgency;
        btns.appendChild(edit);

        name.innerText = arr[i].name;
        id.innerText = arr[i].id;

        row.appendChild(id);
        row.appendChild(name);
        row.appendChild(btns);
        document.getElementById('data-table').appendChild(row);
    }
}

function clearAllFromTravelAgencyTable() {
    var items = document.querySelectorAll('#data-table > tr');
    for (let i = 0; i < items.length; i++) {
        items[i].remove();
    }
}
let createButtonTA = document.getElementById('create-button-travelagency');
createButtonTA.onclick = () => {
    clearAllFromTravelAgencyTable();
    let name = document.getElementById('create-name').value;
    let phone = document.getElementById('create-rating').value;
    //let agencyId = document.getElementById('create-agencyId').value;
    rating = parseInt(phone);
    //agencyId = parseInt(agencyId);
    createTravelAgency(name, rating);
};

let getByIdButtonTA = document.getElementById('get-by-id');
getByIdButtonTA.onclick = () => {
    let id = document.getElementById('id-input').value;
    findTravelAgencyById(id);
};

let allBtnTA = document.getElementById('all-travelagency');
allBtnTA.onclick = () => {
    findAllTravelAgencies();
};

let editTABtn = document.getElementById('edit-travelagency');

editTABtn.onclick = () => {
    let id = document.getElementById('edit-id-travelagency').value;
    let name = document.getElementById('edit-name-travelagency').value;
    let phone = document.getElementById('edit-rating-travelagency').value;
    clearAllFromTravelAgencyTable();
    editTravleAgency(id, name, phone);
}