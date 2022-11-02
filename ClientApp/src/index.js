import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
// import registerServiceWorker from './registerServiceWorker';
import { Provider } from 'react-redux';
import { createStore, combineReducers } from 'redux';
import { petsReducer, petOwnersReducer } from './redux/reducers.js';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

const reduxStore = createStore(
  combineReducers({
    petOwners: petOwnersReducer,
    pets: petsReducer
  })
);
window.store = reduxStore;

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Provider store={reduxStore}>
      <App />
    </Provider>
  </BrowserRouter>,
  rootElement);

// registerServiceWorker();

