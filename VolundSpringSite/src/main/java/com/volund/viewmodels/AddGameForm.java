package com.volund.viewmodels;

public class AddGameForm {
	private String gameName;
	private String genre;
	private int releaseYear;
	
	public String getGameName() {
		return gameName;}

	public void setGameName(String gameName) {
		this.gameName = gameName;}
	
	public String getGenre() {
		return genre;}
	
	public void setGenre(String genre) {
		this.genre = genre;}
	
	public int getReleaseYear() {
		return releaseYear;}
	
	public void setReleaseYear(int releaseYear) {
		this.releaseYear = releaseYear;}
	
	public String toString() {
        return "Game(Name: " + gameName + ", Genre: " + genre + "Year: " + releaseYear + ")";
    }
}
