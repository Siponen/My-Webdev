package com.volund.repositories;

import org.springframework.data.repository.CrudRepository;

import com.volund.models.FinishedGame;

public interface FinishedGameRepository extends CrudRepository<FinishedGame, Integer> {
	
}
