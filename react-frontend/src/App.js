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
                // Примечание: важно обрабатывать ошибки именно здесь, а не в блоке catch(),
                // чтобы не перехватывать исключения из ошибок в самих компонентах.
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
        const project = items
        let pro
        let text
        //console.log(items)

        //Point
// for (let i = 0; i < comment.length; i++) {
//     return comm = comment[i].comment.$values
//     Comment
//     console.log(comment[i].x)
//     for (let j = 0; j < comm.length; j++) {
//         text = comm[i].text
//         //console.log(text)
//     }
// }
//         for(let i=0; i < project.length; i++){
//             pro = project[i].projects
//             for(let j=0; j < pro.length; j++){
//                 text = pro[i]
//                 console.log(text.name)
//                 console.log(text.deadLine)
//             }
//         }
        console.log(items[2])
        if (error) {
            return <div>Ошибка: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return (
                <ul>
                    {items.map(item => (
                        <li key={item.id}>

                        </li>
                    ))}
                </ul>
            );
        }
    }
}
