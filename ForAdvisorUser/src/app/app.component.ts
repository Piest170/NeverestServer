import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CharacterSkill } from '../models/characterskill.model';
import { CharacterskillService } from '../services/characterskill.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'For Advisor User';

  characterskills?: Observable<CharacterSkill[]>
  form = new FormGroup({
    status: new FormControl('', Validators.required)
  })
  stringtext: string = '';
  status: string = '';

  constructor(private characterskillService: CharacterskillService) {}

  ngOnInit(): void {
    this.getCheck();
    this.getAllCharacterSkill();
  }

  getCheck() {
    return this.form.controls;
  }

  getAllCharacterSkill() {
    this.characterskills = this.characterskillService.getAllCharacterSkill()
      //.subscribe((data: any) => {
      //  console.log(data);
      //  this.characterskills = data.data;
      //});
  }

  OnApproved(id: number) {
    this.characterskillService.UpdateCharacterSkill(id).subscribe(() => this.getAllCharacterSkill());
      //.subscribe((data: any) => {
      //  console.log(data)
      //  this.characterskills = data.data
      //});
  }

  OnSearch(stringtext: string, status: string) {
    this.characterskills = this.characterskillService.getCharacterSkill(stringtext, status);
  }
}
