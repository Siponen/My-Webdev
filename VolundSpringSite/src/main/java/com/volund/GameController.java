package com.volund;

import java.util.Optional;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import com.volund.models.Game;
import com.volund.repositories.GameRepository;
import com.volund.viewmodels.AddGameForm;
import com.volund.viewmodels.RemoveGameForm;
import com.volund.viewmodels.UpdateGameForm;

@Controller
public class GameController 
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
}