import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-end-test',
  templateUrl: './end-test.component.html',
  styleUrls: ['./end-test.component.css']
})
export class EndTestComponent implements OnInit {

  private _userId: string;
  constructor(private _router: ActivatedRoute) {
    this._userId = this._router.snapshot.params['userId'];
   }

  ngOnInit() {

  }
}