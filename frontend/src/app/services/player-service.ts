import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PlayerModel } from '../models/player';
import { API_BASE_URL } from './api-config';

@Injectable({
  providedIn: 'root'
})


export class PlayerService {

  private http = inject(HttpClient);



  
  private apiUrl = `${API_BASE_URL}/Players`;

  getPlayers(): Observable<PlayerModel[]> {
    return this.http.get<PlayerModel[]>(this.apiUrl);
  }

 deletePlayer(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  
addPlayer(player: Omit<PlayerModel, 'playerId'>): Observable<PlayerModel> {
    return this.http.post<PlayerModel>(this.apiUrl, player);
  }

   updatePlayer(id: number, player: PlayerModel): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, player);
  }


  
  


}
