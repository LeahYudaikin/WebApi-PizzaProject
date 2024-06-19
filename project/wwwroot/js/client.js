let basicUrl = 'https://localhost:7140/api/';

var token = sessionStorage.getItem("token");
let s = "";

////Pizzas/////
function getAll()
{
    fetch(`${basicUrl}Pizza`)
    .then((res) => res.json())
    .then((data) => fillPizzaList(data))
    .catch(err => {console.log(error)})
}
function fillPizzaList(pizzaList)
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "Get";
    document.getElementById(`${s}`).style.display = "block";
    var pizza_tbody = document.getElementById('pizza_tbody');
    pizza_tbody.innerHTML=
    `<tr>
    <th>Id</th>
    <th>Name</th>
    <th>Price</th>
    <th>isGluten</th>
    </tr>`;
    pizzaList.forEach(Pizza=>{
        pizza_tbody.innerHTML+=`<tr>
        <td>${Pizza.id}</td>
        <td>${Pizza.name}</td>
        <td>${Pizza.price}₪</td>
        <td>${Pizza.gluten}</td>
        </tr>`    
    });
}


function getById()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "GetById";
    document.getElementById(`${s}`).style.display = "block";
}
function sendGetById()
{
    let id = document.getElementById("idForGet").value;
    
    fetch(`${basicUrl}Pizza/${id}`)
    .then((res) => res.json())
    .then((data) => getPizzaId(data))
    .catch(err => {console.log(err)})
}    
function getPizzaId(data)
{
    let pizza_tbody = document.getElementById('write');

    pizza_tbody.innerHTML = `<tr>
    <td>${data.id}</td>
    <td>${data.name}</td>
    <td>${data.price}₪</td>
    <td>${data.gluten}</td>
    </tr>`
    pizza_tbody.innerHTML += tr;
}


function post()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "AddPizza";
    document.getElementById(`${s}`).style.display = "block";
}
function sendPost()
{
    var name = document.getElementById('name').value;
    var price = document.getElementById('price').value;
    var gluten = document.getElementById('gluten').checked;
    let json = JSON.stringify({ "name": `${name}`, "price": `${price}`, "gluten": gluten });

    fetch(`${basicUrl}Pizza`,
        {
            method: 'Post',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                "Authorization": `Bearer ${token}`
            },
            body: json
        })
        .then(response => response.json())
        .then((result)=>{
            if(result.includes("400")){
                alert("faild to add!!");
            }
            else{
                alert("The pizza has been successfully added");
            }
        })
        .catch(error => console.log('error', error.message));
}


function putPizza()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "ChangePizza";
    document.getElementById(`${s}`).style.display = "block";
}
function sendPut()
{
    var id = document.getElementById('idChange').value;
    var name = document.getElementById('nameChange').value;
    var price = document.getElementById('priceChange').value;
    var gluten = document.getElementById('glutenChange').checked;
    let json = JSON.stringify({"id": id, "name": `${name}`, "price": `${price}`, "gluten": gluten });

    fetch(`${basicUrl}Pizza/${id}`,
        {
            method: 'Put',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                "Authorization": `Bearer ${token}`
            },
            body: json,
        })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log(error));
}


function deletePizza()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "Delete";
    document.getElementById(`${s}`).style.display = "block";
}
function deleteGetById()
{
    var id = document.getElementById('idDelete').value;

    fetch(`${basicUrl}Pizza/Delete/${id}`,
        {
            method: 'Delete',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                "Authorization": `Bearer ${token}`
            },
        })
        .then(result => console.log(result))
        .catch(error => alert('⛔error ', error.message));
}


////Workers////
function getAllWorker()
{
    fetch(`${basicUrl}Worker`,
    {
        method: 'Get',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            "Authorization": `Bearer ${token}`
        },
    })    
    .then((res) => res.json())
    .then((data) => fillWorkerList(data))
    .catch(err => {console.log(err)})
}
function fillWorkerList(workerList)
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "GetW";
    document.getElementById(`${s}`).style.display = "block";
    
    var worker_tbody = document.getElementById('worker_tbody');
    worker_tbody.innerHTML=
    `<tr>
    <th>Id</th>
    <th>Name</th>
    <th>Role</th>
    <th>Password</th>
    </tr>`;
    workerList.forEach(Worker=>{
        worker_tbody.innerHTML+=`<tr>
        <td>${Worker.id}</td>
        <td>${Worker.name}</td>
        <td>${Worker.role}</td>
        <td>${Worker.password}</td>
        </tr>`    
    });
}

function getByIdWorker()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "GetByIdW";
    document.getElementById(`${s}`).style.display = "block";
}
function sendGetWorker()
{
    let id = document.getElementById("idForGetW").value;
    
    fetch(`${basicUrl}Worker/${id}`,
    {
        method: 'Get',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            "Authorization": `Bearer ${token}`
        },
    })    .then((res) => res.json())
    .then((data) => getWorkerId(data))
    .catch(err => {console.log(err)})
}    
function getWorkerId(data)
{
    let worker_tbody = document.getElementById('writeW');

    worker_tbody.innerHTML = `<tr>
    <td>${data.id}</td>
    <td>${data.name}</td>
    <td>${data.role}</td>
    <td>${data.password}</td>
    </tr>`
    worker_tbody.innerHTML += tr;
}

function postWorker()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "AddWorker";
    document.getElementById(`${s}`).style.display = "block";
}
function sendWorker()
{
    var name = document.getElementById('NameW').value;
    var role = document.getElementById('role').value;
    var password = document.getElementById('password').value;
    let json = JSON.stringify({ "name": `${name}`, "role": `${role}`, "password": `${password}` });

    fetch(`${basicUrl}Worker`,
        {
            method: 'Post',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                "Authorization": `Bearer ${token}`
            },
            body: json
        })
        .then(response => response.json())
        .then((result)=>{
            if(result.includes("400")){
                alert("faild to add!!");
            }
            else{
                alert("The worker has been successfully added");
            }
        })
        .catch(error => console.log('error', error.message));
}

function deleteWorker()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "DeleteWorker";
    document.getElementById(`${s}`).style.display = "block";
}
function deleteGetByIdWorker()
{
    var id = document.getElementById('idDeleteW').value;

    fetch(`${basicUrl}Worker/Delete/${id}`,
        {
            method: 'Delete',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                "Authorization": `Bearer ${token}`
            },
        })
        .then(result => console.log(result))
        .catch(error => alert('⛔error ', error.message));
}