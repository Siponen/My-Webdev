import { Component, OnInit } from '@angular/core';
import { PORTFOLIO_CARDS} from './mock-portfolio-cards';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.scss']
})

export class PortfolioComponent implements OnInit {
  portfoliocards = PORTFOLIO_CARDS;
  constructor() { }

  ngOnInit() {
  }
}
