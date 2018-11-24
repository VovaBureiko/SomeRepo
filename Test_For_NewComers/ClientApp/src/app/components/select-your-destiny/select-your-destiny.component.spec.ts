import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectYourDestinyComponent } from './select-your-destiny.component';

describe('SelectYourDestinyComponent', () => {
  let component: SelectYourDestinyComponent;
  let fixture: ComponentFixture<SelectYourDestinyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectYourDestinyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectYourDestinyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
