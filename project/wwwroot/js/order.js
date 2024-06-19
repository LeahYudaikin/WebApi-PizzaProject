let basicUrl = 'https://localhost:7140/api/';

var token = sessionStorage.getItem("token");
let s = "";

let listItem = [];

function getAll()
{
    fetch(`${basicUrl}Order`)
    .then((res) => res.json())
    .then((data) => fillOrderList(data))
    .catch(err => {console.log(error)})
}
function fillOrderList(orderList)
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "Get";
    document.getElementById(`${s}`).style.display = "block";
    var order_tbody = document.getElementById('order_tbody');
    order_tbody.innerHTML=
    `<tr>
    <th>Id</th>
    <th>Date</th>
    <th>Name</th>
    <th>Email</th>
    <th>TotalPrice</th>
    </tr>`;
    orderList.forEach(order=>{
        order_tbody.innerHTML+=`<tr>
        <td>${order.id}</td>
        <td>${order.date}</td>
        <td>${order.name}</td>
        <td>${order.mail}</td>
        <td>${order.TotalPrice}₪</td>
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
    
    fetch(`${basicUrl}Order/${id}`)
    .then((res) => res.json())
    .then((data) => getOrderId(data))
    .catch(err => {console.log(err)})
}    
function getOrderId(order)
{
    let order_tbody = document.getElementById('write');

    order_tbody.innerHTML = `<tr>
    <td>${order.id}</td>
    <td>${order.date}</td>
    <td>${order.name}</td>
    <td>${order.mail}</td>
    <td>${order.TotalPrice}₪</td>
    </tr>`
    order_tbody.innerHTML += tr;
}


function post()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "AddOrder";
    document.getElementById(`${s}`).style.display = "block";
    listItem = [];
}
function addItem()
{
    document.getElementById("addItem_pizza").style.display = "block";
}
function saveItem()
{
    var id = document.getElementById('idPizza').value;
    var amount = document.getElementById('amount').value;
    let item = JSON.stringify({ "PizzaId":`${id}`, "Amount":`${amount}` });
    listItem.push(item);
    alert("The pizza has been successfully added");
    document.getElementById("addItem_pizza").style.display = "none";
    id = "";
    amount ="";
}
function payment()
{
    document.getElementById("payment").style.display = "block";
}
function sendPost()
{
    var name = document.getElementById('name').value;
    var mail = document.getElementById('mail').value;
    var list = listItem;
    var number = document.getElementById('Number').value;
    var validity = document.getElementById('Validity').value;
    var cvc = document.getElementById('cvc').value;
    let json = JSON.stringify({
        "date": Date.now,
        "name": `${name}`,
        "mail": `${mail}`,
        "items":`${list}`,
        "creditCard": {
        "number": `${number}`,
        "validity": `${validity}`,
        "threeDigits": `${cvc}`
        }
      });

    fetch(`${basicUrl}Order`,
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
                alert("The order has been successfully added");
            }
        })
        .catch(error => console.log('error', error.message));
}

function deleteOrder()
{
    if (s)
    document.getElementById(`${s}`).style.display = "none";
    s = "Delete";
    document.getElementById(`${s}`).style.display = "block";
}
function deleteGetById()
{
    var id = document.getElementById('idDelete').value;

    fetch(`${basicUrl}Order/Delete/${id}`,
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






