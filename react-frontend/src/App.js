import React, {Component} from 'react';

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

        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return (
               <div>
                   {items.map(item =>(
                       <div key={item.id}>
                           <h1> {item.projects.map(p =>(p.name))}</h1>
                           <h3>Задачи: {item.todos.map(p =>(p.nameTask))}</h3>
                           <h3> Выполняющий: {item.name}</h3>
                           <h3> </h3>
                       </div>
                   ))}
               </div>
            );
        }
    }
}
