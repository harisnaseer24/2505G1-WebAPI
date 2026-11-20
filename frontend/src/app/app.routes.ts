import { Routes } from '@angular/router';
import { Player } from './player/player';
import { AddPlayer } from './add-player/add-player';

export const routes: Routes = [


    {
    path: '',
    redirectTo: 'players',
    pathMatch: 'full'
  },

  {
    path: 'players',
    component: Player
  },

  {
    path: 'players/add',
    component: AddPlayer
  }
];
