import React, {Component} from 'react';
import '../css/Status.css';

export default class ColStatus extends Component{
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
                        <div className={'card-col'} key={item.id}>
                            <p className={'title-main'}>{item.statusName}</p>


                        </div>
                    ))}


                </div>
            )
        }
    }
}