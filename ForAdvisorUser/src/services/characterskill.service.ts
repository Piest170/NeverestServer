import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CharacterSkill } from '../models/characterskill.model';

@Injectable({
  providedIn: 'root'
})
export class CharacterskillService {

  URL = 'https://localhost:7094/api/Character/Skill';

  constructor(private http: HttpClient) { }

  getAllCharacterSkill(): Observable<CharacterSkill[]> {
    return this.http.get<CharacterSkill[]>(this.URL)
      .pipe(
        map((data: any) => {
          console.log('data: ', data);
          return data.data;
        }));
  }

  UpdateCharacterSkill(id: number): Observable<any> {
    return this.http.put(this.URL + `/${id}`, id);
  }

  getCharacterSkill(stringtext: string, status: string): Observable<CharacterSkill[]> {
    if (status === "All") {
      return this.getAllCharacterSkill()
    }
    return this.http.post<CharacterSkill[]>(this.URL + `/Search`, { searchText : stringtext, status : status })
      .pipe(
        map((data: any) => {
          console.log('data: ', data);
          return data.data;
        }));;
  }
}
