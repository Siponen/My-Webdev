import * as React from 'react';

class BacklogGameForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
                game: new GameData(), id: 0, name: '', releaseDate: '', genreId: 0, imagePath: 'default.png',
                statusValue: 0, statusName: 'Default'
            };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleUpdate = this.handleUpdate.bind(this);
        this.handleStatusChange = this.handleStatusChange.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);
        fetch('api/Backlog/Game/CreateBacklogGame',
            {
                method: 'POST', body: data
            })
            .then(response => response.json())
            .catch(error => console.error('Error:', error))
            .then(response => this.props.history.push('/backlog/index'));
    }

    handleUpdate(event) {
        event.preventDefault();
        const data = new FormData(event.Target);
        fetch('api/Backlog/Game/Update',
            {
                method: 'POST', body: data
            })
            .then(response => response.json())
            .catch(error => console.error('Error:', error))
            .then(response => this.props.history.push('backlog/index'));
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({ [name]: value });
    }

    handleStatusChange(event) {
        const target = event.target;
        const value = target.value;
        this.setState({ statusValue: value });
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                    <label>
                        Game name:
                        <input type="text" name="name" value={this.state.name} onChange={this.handleInputChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Release Date:
                        <input type="text" name="releaseDate" value={this.state.releaseDate} onChange={this.handleInputChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Genre:
                        <input type="text" name="genreId" value={this.state.genreId} onChange={this.handleInputChange} />
                    </label>
                </div>
                <div>
                    <label>
                        Image path:
                        <input type="text" name="imagePath" value={this.state.imagePath} onChange={this.handleInputChange} />
                    </label>
                    <div>
                        <label>
                            Game status:
                            <select value={this.state.statusValue} onChange={this.handleStatusChange}>
                                <option value="1">Unfinished</option>
                                <option value="2">Finished</option>
                                <option value="3">Low priority</option>
                                <option value="4">Broken</option>
                            </select>
                        </label>
                    </div>
                </div>
                <div><input type="submit" value="Submit game" /></div>
            </form >
        );
    }
}

export default BacklogGameForm;

class GameData {
    id: number = 0;
    name: string = "";
    releaseDate: string = "";
    genreId: number = 0;
    imagePath: string = "";
}