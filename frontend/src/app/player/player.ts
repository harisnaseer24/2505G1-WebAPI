import { Component, inject, signal } from '@angular/core';
import { PlayerService } from '../services/player-service';
import { PlayerModel } from '../models/player';
import { RouterLink } from '@angular/router';

@Component({
  imports: [RouterLink],
  selector: 'app-player',
  styleUrl: './player.css',
  templateUrl: './player.html',
})
export class Player {

private playerService = inject(PlayerService);

  players = signal<PlayerModel[]>([]);
  loading = signal(false);
  errorMessage = signal('');
  successMessage = signal('');

  ngOnInit(): void {
    this.loadPlayers();
  }

  loadPlayers(): void {

    this.loading.set(true);
    this.errorMessage.set('');
    this.playerService.getPlayers().subscribe({
      next: (data) => {
        this.players.set(data);
        this.loading.set(false);
      },
      error: (error) => {
        console.error(error);
        this.errorMessage.set('Failed to load players.');
        this.loading.set(false);
      }

    });
  }

  deletePlayer(id: number): void {

    if (!confirm('Are you sure you want to delete this player?')) {
      return;
    }

    this.errorMessage.set('');
    this.successMessage.set('');

    this.playerService.deletePlayer(id).subscribe({

      next: () => {
        this.successMessage.set('Player deleted successfully.');
        this.loadPlayers();
      },

      error: (error) => {
        console.error(error);
        this.errorMessage.set('Unable to delete player.');
      }

    });
  }

}
