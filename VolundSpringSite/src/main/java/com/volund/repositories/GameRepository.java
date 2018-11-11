package com.volund.repositories;

import org.springframework.data.repository.CrudRepository;

import com.volund.models.Game;

public interface GameRepository extends CrudRepository<Game, Integer> {
}
