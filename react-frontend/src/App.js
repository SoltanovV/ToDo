import React, {Component} from 'react';
import './App.css';

export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }

    componentDidMount() {
        fetch("https://localhost:7055/api/User/view")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }
    render() {
        const { error, isLoaded, items } = this.state;
        console.log(items)
        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return (
               <div>
                   {items.map(item =>(
                       <div key={item.id} className={'cartUser'}>
                           <h1> {item.projects.map(p =>(p.name))}</h1>
                           <h3 className={'title-main'}>Задачи</h3>
                           <ul>
                               {item.todos.map(p =>(
                                   <li key={p.id}> {p.nameTask}
                                       <p>Стату задачи: {p.status.statusName}</p>
                                       <p>Приоритет: <span className={'priority'}>{p.priority.priorityName}</span></p>
                                   </li>
                               ))}

                           </ul>
                           <h3> Выполняющий: {item.name}</h3>
                       </div>
                   ))}
               </div>
            );
        }
    }
}
