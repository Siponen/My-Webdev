package com.volund;

import java.util.ArrayList;
import java.util.Optional;

import javax.validation.Valid;

import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import com.volund.models.Game;
import com.volund.models.UnfinishedGame;
import com.volund.repositories.GameRepository;
import com.volund.viewmodels.AddUnfinishedGameForm;
import com.volund.viewmodels.UnfinishedGameViewElement;
import com.volund.repositories.UnfinishedGameRepository;

public class UnfinishedGameController {
	private GameRepository gameRepository;
	private UnfinishedGameRepository unfinishedGameRepository;

	@GetMapping("/backlog/addUnfinishedGame")
	public String addUnfinishedGame(Model model)
	{
		model.addAttribute("gameForm", new AddUnfinishedGameForm());
		return "backlog/addUnfinishedGame";
	}

	@PostMapping("/backlog/addUnfinishedGame")
	public String validateUnfinishedGame(@Valid @ModelAttribute AddUnfinishedGameForm gameForm,
			BindingResult bindingResult)
	{
		if (bindingResult.hasErrors()) {
			return "/";
		}

		Optional<Game> optGame = gameRepository.findById(gameForm.getGameId());
		if (optGame.isEmpty())
			return "/";

		UnfinishedGame entity = new UnfinishedGame();
		entity.setGame(optGame.get());
		unfinishedGameRepository.save(entity);

		return "redirect:/backlog/unfinishedGames?page=0";
	}

	@GetMapping("/backlog/unfinishedGames")
	public String unfinishedGames(@RequestParam int page, Model model)
	{
		Iterable<UnfinishedGame> unfinishedGameArray = unfinishedGameRepository.findAll();

		ArrayList<UnfinishedGameViewElement> gameList = new ArrayList<UnfinishedGameViewElement>();
		for (UnfinishedGame unfinishedGame : unfinishedGameArray) {
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
}
