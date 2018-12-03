import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SpecializationService } from 'src/app/services/specializationService';

@Component({
  selector: 'app-end-test',
  templateUrl: './end-test.component.html',
  styleUrls: ['./end-test.component.css']
})
export class EndTestComponent implements OnInit {

  private _userId: string;
  constructor(private _router: ActivatedRoute,
            private _specialService: SpecializationService) {
    this._userId = this._router.snapshot.params['userId'];
   }

  ngOnInit() {
    this._specialService.getFinalResult(this._userId).subscribe(response => console.log(response));
  }
}