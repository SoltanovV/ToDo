export default function todoApi (){
    const URL = 'https://localhost:7055/api/Todo/view'
    return fetch(URL)
        .then((res) =>{
            return res.json()
        })
}
