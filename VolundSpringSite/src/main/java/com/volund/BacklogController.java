package com.volund;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

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

import com.volund.models.FinishedGame;
import com.volund.models.Game;
import com.volund.models.UnfinishedGame;
import com.volund.repositories.FinishedGameRepository;
import com.volund.repositories.GameRepository;
import com.volund.repositories.UnfinishedGameRepository;
import com.volund.viewmodels.AddGameForm;
import com.volund.viewmodels.AddUnfinishedGameForm;
import com.volund.viewmodels.RemoveGameForm;
import com.volund.viewmodels.UpdateGameForm;
import com.volund.viewmodels.UnfinishedGameViewElement;

@Controller
@Secured(value = { "ROLE_USER" })
public class BacklogController
{
	@Autowired
	private GameRepository gameRepository;
	@Autowired
	private UnfinishedGameRepository unfinishedGameRepository;
	@Autowired
	private FinishedGameRepository finishedGameRepository;
	
	// Game CRUD (Move to GameController later)
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
	
	@GetMapping("backlog/updateGame")
	public String updateGame(@RequestParam int id, Model model) {
		Optional<Game> game = gameRepository.findById(id);
		if(game.isEmpty()) // TODO Should return "Game doesnt exist", but head back to root site for now.
			return "redirect:/backlog/library";
		
		model.addAttribute("gameForm", game.get());
		return "/backlog/updateGame";
	}
	
	@PostMapping("backlog/updateGame")
	public String validateUpdateGame(@Valid @ModelAttribute UpdateGameForm gameForm, BindingResult bindingResult) {
		if(bindingResult.hasErrors()) {
			return "/";
		}
		
		Game game = new Game(gameForm.getId(),gameForm.getGameName(),
				gameForm.getGenre(),gameForm.getReleaseYear());
		gameRepository.save(game);
		return "redirect:/backlog/library";
	}
	
	@GetMapping("/backlog/removeGame")
	public String removeGame(@RequestParam int id, Model model)
	{
		Optional<Game> game = gameRepository.findById(id);
		if(game.isEmpty())
			return "/";
		
		model.addAttribute("gameForm", game.get());
		return "/backlog/removeGame";
	}
	
	@PostMapping("backlog/removeGame")
	public String deleteGame(@Valid @ModelAttribute RemoveGameForm gameForm)
	{
		Optional<Game> game = gameRepository.findById(gameForm.getId());
		if(game.isEmpty())
			return "/";
		
		gameRepository.deleteById(gameForm.getId());
		return "redirect:/backlog/library";
	}
	
	
	//UnfinishedGames CRUD
	@GetMapping("/backlog/addUnfinishedGame")
	public String addUnfinishedGame(Model model) {
		model.addAttribute("gameForm", new AddUnfinishedGameForm());
		return "backlog/addUnfinishedGame";
	}
	
	@PostMapping("/backlog/addUnfinishedGame")
	public String validateUnfinishedGame(@Valid @ModelAttribute AddUnfinishedGameForm gameForm, 
			BindingResult bindingResult) {
		if(bindingResult.hasErrors()) {
			return "/";
		}
		
		Optional<Game> optGame = gameRepository.findById(gameForm.getGameId());
		if(optGame.isEmpty())
			return "/";
		
		UnfinishedGame entity = new UnfinishedGame();
		entity.setGame(optGame.get());
		unfinishedGameRepository.save(entity);
		
		return "redirect:/backlog/unfinishedGames?page=0";
	}
	
	@GetMapping("/backlog/library")
	public String gameList(Model model)
	{
		model.addAttribute("games", gameRepository.findAll());
		return "/backlog/gameLibrary";
	}
	
	@GetMapping("/backlog/unfinishedGames")
	public String unfinishedGames(@RequestParam int page, Model model) {
		Iterable<UnfinishedGame> unfinishedGameArray = unfinishedGameRepository.findAll();
		
		ArrayList<UnfinishedGameViewElement> gameList = new ArrayList<UnfinishedGameViewElement>();
		for(UnfinishedGame unfinishedGame : unfinishedGameArray) {
			Game rawGame = unfinishedGame.getGame();
			UnfinishedGameViewElement game = new UnfinishedGameViewElement();
			game.setGameName(rawGame.getGameName());
			game.setGenre(rawGame.getGenre());
			game.setId(rawGame.getId());
			game.setReleaseYear(rawGame.getReleaseYear());
			game.setPhotoName("");
			gameList.add(game);
		}
		
		model.addAttribute("games", gameList);
		return "/backlog/unfinishedGames";
	}
	
	@GetMapping("/backlog/finishedGames")
	public String finishedGames(@RequestParam int page, Model model) {
		Iterable<FinishedGame> games = finishedGameRepository.findAll();
		model.addAttribute("games", games);
		
		return "/backlog/finishedGames";
	}
	
	@GetMapping("/gameLibrary")
	public @ResponseBody Iterable<Game> gameLibrary()
	{
		return gameRepository.findAll();
	}
}
