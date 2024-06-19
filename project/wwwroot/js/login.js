/////login/////
function login()
{
    let name = document.getElementById('nameLogin').value;
    let password = document.getElementById('passwordLogin').value;
    let json = JSON.stringify({ "name":name, "password":password });
    fetch(`${basicUrl}Login`,
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
    .then(result =>
        {
            sessionStorage.setItem("token", result);
            location.href = "./html/home.html";
            alert('you are connected!!!');
        })
    .catch(error => alert('error: please login...', error.message));
}
