import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { PlayerModel } from '../models/player';
import { PlayerService } from '../services/player-service';

@Component({
  imports: [ReactiveFormsModule, RouterLink],
  selector: 'app-add-player',
  styleUrl: './add-player.css',
  templateUrl: './add-player.html',
})
export class AddPlayer {

 private fb = inject(FormBuilder);
  private playerService = inject(PlayerService);
  private router = inject(Router);

  saving = signal(false);
  errorMessage = signal('');

  playerForm = this.fb.nonNullable.group({
    name: ['', Validators.required],
    style: ['', Validators.required],
    type: ['', Validators.required],
    runs: [0, [Validators.required, Validators.min(0)]],
    strikeRate: [0, [Validators.required, Validators.min(0)]],
    average: [0, [Validators.required, Validators.min(0)]],
    teamId: [1, [Validators.required, Validators.min(1)]]
  });

  addPlayer(): void {
    if (this.playerForm.invalid) {
      this.playerForm.markAllAsTouched();
      return;
    }
    if (this.saving()) return;

    this.saving.set(true);
    this.errorMessage.set('');

    const newPlayer: PlayerModel = {
      playerId: 0,
      ...this.playerForm.getRawValue()
    };

    this.playerService.addPlayer(newPlayer).subscribe({

      next: () => {
        this.router.navigate(['/players']);
      },

      error: (error) => {
        console.error(error);
        this.errorMessage.set('Unable to add player.');
        this.saving.set(false);
      }

    });
  }


}
