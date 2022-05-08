let customer = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:58976/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        getdata();
    });

    connection.on("CustomerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:58976/customer')
        .then(x => x.json())
        .then(y => {
            actors = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    actors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.customerId + "</td><td>"
            + t.customerName + "</td><td>" +
            `<button type="button" onclick="remove(${t.customerId})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:58976/customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('customername').value;
    fetch('http://localhost:58976/customer', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}