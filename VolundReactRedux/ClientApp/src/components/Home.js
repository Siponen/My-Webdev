import React from 'react';
import { connect } from 'react-redux';

const Home = props => (
    <div>
    <h1>Welcome to Volund!</h1>
        <p>This is a MVC Core app with React and Redux as the View Engine</p>
        <p>For minimal server rendering, and minimal requests for data the client have already downloaded from the server.</p>
        <ul>
            <li>
                <a href="/backlog/index">Backlog</a> <span> - Manages our game backlog, allows us to vote for which game we should play next through twitch</span>
            </li>
        </ul>
  </div>
);

export default connect()(Home);
