import React, {Component} from 'react';
import moment from "moment";
import './css/TodoStyle.css'
import todoApi from './Api/TodoApi'

export default class todoCard extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
        // const todo = todoApi();
        // console.log(todo.map(t => (t.nameTask)))
    }
    render() {

        const { error, isLoaded, items } = this.state;
        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return (
                <div className={'card-table'}>
                    {items.map(item =>(
                        <div className="card-col">
                            <div key={item.id} className={'cardUser'}>
                                <p className={'task-name'}>{item.nameTask}</p>
                                <p className={'task-description'}>{item.description}</p>
                                <p className={'task-date'}>{moment(item.startDate).format('DD.MM.YY') } – {moment(item.endDate).format('DD.MM.YY')}</p>
                            </div>
                        </div>
                    ))}
                </div>
            );
        }
    }
}
