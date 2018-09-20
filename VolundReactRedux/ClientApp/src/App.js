import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Backlog from './components/Backlog';
import GameDetail from './components/backlog/GameDetails';
import BacklogGameForm from './components/backlog/BacklogGameForm';
import FinishedGameForm from './components/backlog/FinishedGameForm';


export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/backlog/index:foo?' component={Backlog} />
        <Route path='/backlog/game/:gameId?' component={GameDetail} />
        <Route path='/Backlog/CreateBacklogGame' component={BacklogGameForm} />
        <Route path='/Backlog/CreateFinishedGame' component={FinishedGameForm} />
    </Layout>
);
