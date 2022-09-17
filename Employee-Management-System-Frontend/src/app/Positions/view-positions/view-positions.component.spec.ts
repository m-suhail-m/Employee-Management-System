import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewPositionsComponent } from './view-positions.component';

describe('ViewPositionsComponent', () => {
  let component: ViewPositionsComponent;
  let fixture: ComponentFixture<ViewPositionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewPositionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewPositionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
