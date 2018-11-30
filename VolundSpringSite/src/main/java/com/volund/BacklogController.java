package com.volund;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.util.Pair;
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
import com.volund.util.GamePair;
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
	
	@GetMapping("/backlog/library")
	public String gameList(Model model)
	{
		model.addAttribute("games", gameRepository.findAll());
		return "/backlog/gameLibrary";
	}
	
	@ModelAttribute("selectGameList")
	public List<GamePair> getGameIdsFromString(String gameName)
	{
		List<Game> games = gameRepository.findGameByGameName(gameName);
		List<GamePair> gameList = new ArrayList<GamePair>();
				
		if(games == null || games.size() == 0) {
			return gameList;
		}
		
		for(Game game : games) {
			gameList.add(new GamePair(game.getId(),game.getGameName()));
		}
		
		return gameList;
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
