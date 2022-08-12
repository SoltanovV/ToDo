import React from "react";

export default class getProject extends React.Component {
    constructor(props) {
        super(props);
        this.state ={
            error: null,
            isLoaded: false,
            items: []
        };
    }

    componentDidMount() {
        const URL = 'https://localhost:7055/api/User/view'
        fetch(URL)
            .then(res => res.json())
            .then((result) =>{
                this.useState({
                    isLoaded: true,
                    items: result.items
                })
            },
                (error) =>{
                    this.useState({
                        isLoaded: true,
                        error
                    })
                }
            )
    }

    render() {
        const {item, error, isLoaded} = this.state
        if (error){
            return <div>Очипка загрузка: {error.message()}</div>
        } else if(!isLoaded){
            return <div>Pfuheprf.....</div>
        }
        else{
            return (
                <ul>
                    {item.map(<li key={item.id}>
                        {item.name}
                    </li>)}
                </ul>
            );

        }

    }
}
