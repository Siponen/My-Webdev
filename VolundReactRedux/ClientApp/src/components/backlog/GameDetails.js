import React from 'react';

class GameDetails extends React.Component {
    constructor(props) {
        super(props);
        this.state = { gameDetails: new GameDetailData(), gameId: 0 };
        var gameId = parseInt(this.props.match.params.gameId, 10) || 0;
        const url = `api/Backlog/Game/Details?gameId=${gameId}`;
        fetch(url)
            .then(response => response.json())
            .then(data => this.setState({ gameDetails: data }));
    }

    render() {
        const gameDetails = this.state.gameDetails;
        let finishedGameStats = gameDetails.hasFinishedGame
            ? renderFinishedGame(gameDetails)
            : "";

        return (
            <div className="row">
                <div className="col-md-3">
                    <img alt-text="" src={"./img/" + gameDetails.imagePath} />
                </div>
                <div className="col-md-3">
                    <h1>{gameDetails.gameName}</h1>
                    <p>{gameDetails.releaseDate}</p>
                    <p>{gameDetails.genreName}</p>
                    <p>{gameDetails.gameRating}</p>
                    {finishedGameStats}
                </div>
            </div>
        );
    }
}

function renderFinishedGame(gameDetails) {
    return (
        <div>
            <p>Finished in {gameDetails.finishedGameDate}</p>
            <p>Took {gameDetails.hoursPlayed} spanning {gameDetails.daysPlayed} days</p>
        </div>
    );
}

class GameDetailData {
    id: number = 0;
    gameName: string = "";
    genreName: string = "";
    releaseDate: string = "";
    imagePath: string = "";
    isFavourite: boolean = false;
    gameRating: string = "";    
    hasFinishedGame: boolean = false;
    finishedGameDate: string = "";
    hoursPlayed: number = 0;
    daysPlayed: number = 0;
}

export default GameDetails;