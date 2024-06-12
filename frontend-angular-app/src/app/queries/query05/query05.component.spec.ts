import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Query05Component } from './query05.component';

describe('Query05Component', () => {
  let component: Query05Component;
  let fixture: ComponentFixture<Query05Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Query05Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Query05Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
