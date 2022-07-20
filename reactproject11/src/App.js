import React from 'react';

function App() {
    return (
       <div>
           <form method="POST">
               <p>Введите логин</p>
               <input type="text"/>
               <p>Введите пароль</p>
               <input type="password"/>
               <button type={"submit"}>Войти</button>
           </form>
       </div>
        )
}

export default App