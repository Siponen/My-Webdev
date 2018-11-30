import { Component } from '@angular/core';
import { PORTFOLIO_CARDS} from './portfolio/mock-portfolio-cards';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

//Make handler in the component and bind it to a DOM event

export class AppComponent {
  portfoliocards = PORTFOLIO_CARDS;
}
