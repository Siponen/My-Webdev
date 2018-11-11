package com.volund.models;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;

@Entity
public class Game {
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	private Integer id;
	private String gameName;
	private String genre;
	private Integer releaseYear;
	
	public Game() {};
	public Game(Integer id, String gameName, String genre, Integer releaseYear) {
		this.id = id;
		this.gameName = gameName;
		this.genre = genre;
		this.releaseYear = releaseYear;
	};
	
	@OneToOne(mappedBy = "game", cascade = CascadeType.ALL)
	private UnfinishedGame unfinishedGame;
	
	public Integer getId() {
		return id; }
	
	public void setId(Integer gameId) {
		this.id = gameId;}
	
	public String getGameName() {
		return this.gameName;}

	public void setGameName(String gameName) {
		this.gameName = gameName;}
	
	public String getGenre() {
		return this.genre;}
	
	public void setGenre(String genre) {
		this.genre = genre;}
	
	public Integer getReleaseYear() {
		return this.releaseYear;}
	
	public void setReleaseYear(int releaseYear) {
		this.releaseYear = releaseYear;}
}
