const requestUnfinishedGamesType = 'REQUEST_UNFINISHED_GAMES';
const receiveUnfinishedGamesType = 'RECEIVE_UNFINISHED_GAMES';

const requestGamesType = 'REQUEST_GAMES';
const receiveGamesType = 'RECEIVE_GAMES';

const requestBeatenGamesType = 'REQUEST_BEATEN_GAMES';
const receiveBeatenGamesType = 'RECEIVE_BEATEN_GAMES';

const initialState = {
    games: [], isLoadingGames: false,
    unfinishedGames: [], isLoadingUnfinishedGames: false,
    beatenGames: [], isLoadingBeatenGames: false
};

export const actionCreators = {
    requestGames: page => async (dispatch, getState) => {
        if (page === getState().backlog.page) {
            return;
        }

        dispatch({ type: requestGamesType, page });
        const url = `api/Backlog/Games?page=${page}`;
        const response = await fetch(url);
        const games = await response.json();
        dispatch({ type: receiveGamesType, page, games });
    },

    requestUnfinishedGames: foo => async (dispatch, getState) => {
        if (foo === getState().backlog.foo) {
            return;
        }

        dispatch({ type: requestUnfinishedGamesType, foo });
        const url = `api/Backlog/UnfinishedGames?foo=${foo}`;
        const response = await fetch(url);
        const unfinishedGames = await response.json();
        dispatch({ type: receiveUnfinishedGamesType, foo, unfinishedGames });
    },

    requestBeatenGames: page => async (dispatch, getState) => {
        if (page === getState().backlog.page) {
            return;
        }

        dispatch({ type: requestBeatenGamesType, page });
        const url = `api/Backlog/FinishedGames?page=${page}`;
        const response = await fetch(url);
        const games = await response.json();
        dispatch({ type: receiveBeatenGamesType, page, games });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestBeatenGamesType) {
        return {
            ...state,
            page: action.page,
            isLoadingBeatenGames: true
        };
    }

    if (action.type === receiveBeatenGamesType) {
        return {
            ...state,
            page: action.page,
            beatenGames: action.beatenGames,
            isLoadingBeatenGames: false
        };
    }

    if (action.type === requestUnfinishedGamesType) {
        return {
            ...state,
            foo: action.foo,
            isLoadingUnfinishedGames: true
        };
    }

    if (action.type === receiveUnfinishedGamesType) {
        return {
            ...state,
            foo: action.foo,
            unfinishedGames: action.unfinishedGames,
            isLoadingUnfinishedGames: false
        };
    }

    if (action.type === requestGamesType) {
        return {
            ...state,
            page: action.page,
            isLoadingGames: true
        };
    }

    if (action.type === receiveGamesType) {
        return {
            ...state,
            page: action.page,
            games: action.games,
            isLoadingGames: false
        };
    }

    return state;
};