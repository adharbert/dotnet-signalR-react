require('normalize.css/normalize.css');
require('styles/App.css');

import React from 'react';
import { HubConnection } from '@aspnet/signalr';

let yeomanImage = require('../images/yeoman.png');

class AppComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            bookingMessage: '',
            bookingHubConnection: null
        };
    }

    componentDidMount = () => {
        const bookingHubConnection = new HubConnection('http://localhost:59084/bookingHub');

        this.setState({ bookingHubConnection}, () => {
            this.state.bookingHubConnection.start()
                .then(() => console.log('SignalR Started'))
                .catch(err => console.log('Error connection SignalR - ' + err));
            this.state.bookingHubConnection.on('booking', (message) => {
                const bookingMessage = message;
                this.setState({ bookingMessage });
            });
        });
    }


    render() {
        return (
            <div className="index">
            <img src={yeomanImage} alt="Yeoman Generator" />
            <div className="notice">Please edit <code>src/components/Main.js</code> to get started!</div>
            </div>
        );
    }
}

AppComponent.defaultProps = {
};

export default AppComponent;
