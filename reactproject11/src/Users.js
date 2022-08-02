//async function GetUsers() {
//     const response = await fetch("https://localhost:7055", {
//         method: "GET",
//         headers: { "Accept": "application/json" }
//     });
//         console.log(response)
//     if (response.ok === true) {
//         const users = await response.json();
//         let rows = document.querySelector("tbody");
//         users.forEach(user => {
//             rows.append(user);
//         });
//     }
   
//}

let request = new XMLHttpRequest();
let btn = document.getElementById("btn");
let result = document.getElementById("result");

btn.addEventListener("click", function (e) {
    request.open("GET", "https://localhost:7055");
    request.onreadystatechange = reqReadyStateChange;
    request.send();
});

function reqReadyStateChange() {
    if (request.readyState === 4) {
        let status = request.status;
        if (status === 200)
            result.innerText = request.responseText;
        else
            result.innerText = request.statusText;
    }
}
export default reqReadyStateChange
