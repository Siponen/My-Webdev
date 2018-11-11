package com.volund;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.annotation.Secured;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

import com.volund.models.Game;
import com.volund.repositories.GameRepository;
import com.volund.viewmodels.AddGameForm;

@Controller
@Secured(value = { "ROLE_USER" })
public class BacklogController
{
	@Autowired
	private GameRepository gameRepository;
	
	@GetMapping("backlog/addGame")
	public String addGame(Model model)
	{
		model.addAttribute("gameForm", new AddGameForm());
		return "backlog/addGame";
	}
	
	@PostMapping("backlog/addGame")
	public String validateAddGame(@Valid @ModelAttribute AddGameForm gameForm, BindingResult bindingResult) {
		if(bindingResult.hasErrors()) {
			return "/";
		}
		
		Game game = new Game();
		game.setGameName(gameForm.getGameName());
		game.setGenre(gameForm.getGenre());
		game.setReleaseYear(gameForm.getReleaseYear());
		gameRepository.save(game);
		return "redirect:/backlog/library";
	}
	
	@GetMapping("/backlog/removeGame")
	public String deleteGame(@RequestParam int gameId)
	{
		return "/backlog/removeGame";
	}
		
	@GetMapping("/backlog/library")
	public String gameList(Model model)
	{
		model.addAttribute("games", gameRepository.findAll());
		return "/backlog/gameLibrary";
	}
		
	@GetMapping("/beaten")
	public String beatenGames()
	{
		return "beatenGames";
	}
	
	@GetMapping("/gameLibrary")
	public @ResponseBody Iterable<Game> gameLibrary()
	{
		return gameRepository.findAll();
	}
}
