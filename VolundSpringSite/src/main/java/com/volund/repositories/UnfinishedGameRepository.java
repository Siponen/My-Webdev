package com.volund.repositories;

import org.springframework.data.repository.CrudRepository;

import com.volund.models.UnfinishedGame;

public interface UnfinishedGameRepository extends CrudRepository<UnfinishedGame, Integer> {
	
}
