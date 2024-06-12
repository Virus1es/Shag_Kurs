import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Query04Component } from './query04.component';

describe('Query04Component', () => {
  let component: Query04Component;
  let fixture: ComponentFixture<Query04Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Query04Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Query04Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
