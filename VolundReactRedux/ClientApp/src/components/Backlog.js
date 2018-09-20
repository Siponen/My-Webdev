import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { LinkContainer, Tabs, Tab, TabContainer, TabContent, TabPane } from 'react-router-bootstrap';
import { actionCreators } from '../store/Backlog';

import './css/games.css';

class Backlog extends Component {
    componentWillMount() {
        // This method runs when the component is first added to the page
        const unfinishedGamePage = parseInt(this.props.match.params.foo, 10) || 0;
        this.props.requestUnfinishedGames(unfinishedGamePage);

        const gamePage = parseInt(this.props.match.params.page, 10) || 0;
        this.props.requestGames(gamePage);
        this.props.requestBeatenGames(gamePage)
    }

    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        const unfinishedGamePage = parseInt(nextProps.match.params.foo, 10) || 0;
        this.props.requestUnfinishedGames(unfinishedGamePage);

        const gamePage = parseInt(nextProps.match.params.page, 10) || 0;
        this.props.requestGames(gamePage);
        this.props.requestBeatenGames(gamePage);
    }

    render() {
        let backlogContent = this.props.isLoadingUnfinishedGames
            ? <p><em>Loading...</em></p>
            : renderGames(this.props.unfinishedGames);

        let gameContent = this.props.isLoadingGames
            ? <p><em>Loading...</em></p>
            : renderGames(this.props.games);

        let beatenContent = this.props.isLoading

        return (
            <div>
                <h1>Backlog</h1>
                <p>Number of games: <strong>{this.props.unfinishedGames.length}</strong></p>
                <h2>Unfinished Games</h2>
                <div>
                    {backlogContent}
                </div>
                <h2>Beaten games</h2>
                <p>Number of beaten games: <strong>{this.props.beatenGames.length}</strong></p>

                <h2>Game library</h2>
                <p>Number of games: <strong>{this.props.games.length}</strong></p>
                <div>
                    {gameContent}
                </div>
            </div>
        );
    }
}

function renderGames(games) {
    return (
        <div className="row">
            {games.map(game =>
                <LinkContainer key={game.id} className="gameNewItem col-sm-2" style={{ backgroundImage: "url(" + "./img/" + game.imagePath + ")" }} to={'/Backlog/Game/' + game.id}>
                    <div>
                        <div className="gameContainer">
                            <div className="gameTitle">
                                {game.name}
                            </div>
                            <div className="gameYear">
                                <div>{game.releaseDate}, {game.genreName}</div>
                            </div>
                        </div>
                    </div>
                </LinkContainer>
            )}
        </div>
    );
}

export default connect(
    state => state.backlog,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Backlog);