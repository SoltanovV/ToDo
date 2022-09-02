import React, {Component} from 'react';
import ColumStatus from "./ColumStatus";
import './css/HomeWindow.css'
import AddColum from "./AddColum";

class HomeWindow extends Component {
    render() {
        return (
            <div className='todo-window'>
                <AddColum/>
                <ColumStatus/>
            </div>
        );
    }
}

export default HomeWindow;