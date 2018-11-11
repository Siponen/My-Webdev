package com.volund.models;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class GameRating {
	@Id
	private Integer id;
	private String rating;
	
	public Integer getId() {
		return id;
	}
	
	public void setId(Integer id) {
		this.id = id;
	}
	
	public String getRating() {
		return rating;
	}
	
	public void setRating(String rating) {
		this.rating = rating;
	}
}
