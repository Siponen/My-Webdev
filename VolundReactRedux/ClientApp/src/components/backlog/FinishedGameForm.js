import * as React from 'react';

class FinishedGameForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            gameId: 0, name: '', imagePath: '', releaseDate: '', genreId: 0,
            gameStartDate: '', gameEndDate: '', hoursPlayed: 0, daysPlayed: 0, gameRatingId: 0,
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleGameRatingChange = this.handleGameRatingChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        fetch('api/Backlog/Game/CreateFinishedGame',
            {
                method: 'POST', body: data
            })
            .then(response => response.json())
            .catch(error => console.error('Error: ', error))
            .then(response => this.props.history.push('/backlog/index'));
    }

    handleChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        this.setState({ [target.name]: value });
    }

    handleGameRatingChange(event) {
        this.setState({ gameRatingId: event.target.value });
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                    <label>
                        Game name:
                        <input type="text" name="name" value={this.state.name} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Release Date:
                        <input type="text" name="releaseDate" value={this.state.releaseDate} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Genre:
                        <input type="text" name="genreId" value={this.state.genreId} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Image path:
                        <input type="text" name="imagePath" value={this.state.imagePath} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Game start date:
                            <input type="text" name="gameStartDate" value={this.state.gameStartDate} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Game end date:
                            <input type="text" name="gameEndDate" value={this.state.gameEndDate} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Hours played:
                            <input type="text" name="hoursPlayed" value={this.state.hoursPlayed} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Days played:
                            <input type="text" name="daysPlayed" value={this.state.daysPlayed} onChange={this.handleChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Game rating:
                            <select value={this.state.statusValue} onChange={this.handleChange}>
                            <option value="1">Abomination</option>
                            <option value="2">Bad</option>
                            <option value="3">Not good</option>
                            <option value="4">Ok</option>
                            <option value="5">Good</option>
                            <option value="6">Great</option>
                            <option value="7">Awesome</option>
                            <option value="8">EPIC AWESOME</option>
                        </select>
                    </label>
                </div>
                <input type="submit" value="Submit" />
            </form>
        );
    }
}

export default FinishedGameForm;