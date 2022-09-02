import React, {Component} from 'react';
import './css/Status.css'
import Todo from './TodoCard';

export default class ColumStatus extends Component{
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }
    componentDidMount() {
        const URL = 'https://localhost:7055/api/Status/view'
        fetch(URL)
            .then(res => res.json())
            .then((result) => {
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
            })
    }
    render() {
        const {error, isLoaded, items} = this.state;

        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return (
                <div className={'card-table'}>
                    {items.map(item => (
                        <div className='card-col' key={item.id}>
                            <div className='title-col'>
                                {item.statusName}
                                <button className=''>
                                    <svg width="26" height="26" viewBox="0 0 26 26" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <path d="M13.2665 0C6.2342 0 0.533081 5.74583 0.533081 12.8333C0.533081 19.9208 6.2342 25.6667 13.2665 25.6667C20.2989 25.6667 26 19.9208 26 12.8333C26 5.74583 20.2989 0 13.2665 0ZM14.4241 17.5C14.4241 17.8094 14.3022 18.1062 14.0851 18.325C13.868 18.5438 13.5736 18.6667 13.2665 18.6667C12.9595 18.6667 12.6651 18.5438 12.448 18.325C12.2309 18.1062 12.109 17.8094 12.109 17.5V14H8.63619C8.32918 14 8.03475 13.8771 7.81766 13.6583C7.60057 13.4395 7.47861 13.1428 7.47861 12.8333C7.47861 12.5239 7.60057 12.2272 7.81766 12.0084C8.03475 11.7896 8.32918 11.6667 8.63619 11.6667H12.109V8.16667C12.109 7.85725 12.2309 7.5605 12.448 7.34171C12.6651 7.12292 12.9595 7 13.2665 7C13.5736 7 13.868 7.12292 14.0851 7.34171C14.3022 7.5605 14.4241 7.85725 14.4241 8.16667V11.6667H17.8969C18.2039 11.6667 18.4983 11.7896 18.7154 12.0084C18.9325 12.2272 19.0545 12.5239 19.0545 12.8333C19.0545 13.1428 18.9325 13.4395 18.7154 13.6583C18.4983 13.8771 18.2039 14 17.8969 14H14.4241V17.5Z" fill="currentColor"/>
                                    </svg>
                                </button>
                            </div>

                            <Todo />
                        </div>
                    ))}
                </div>
            )
        }
    }
}
