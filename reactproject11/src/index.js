import React from 'react';
import './index.css';
import App from './App';
import ReactDOM from 'react-dom/client';

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
        <App>
            <button id="btn" value="Запрос">Запрос</button>
        </App>
  </React.StrictMode>
);
