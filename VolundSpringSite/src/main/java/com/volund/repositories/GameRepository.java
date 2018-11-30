package com.volund.repositories;

import java.util.List;

import org.springframework.data.repository.CrudRepository;

import com.volund.models.Game;

public interface GameRepository extends CrudRepository<Game, Integer> {
	List<Game> findGameByGameName(String gameName);
	List<Game> findGameByGenre(String genre);
	List<Game> findGameByReleaseYear(int releaseYear);
}
