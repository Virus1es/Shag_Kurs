import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Query01Component } from './query01.component';

describe('Query01Component', () => {
  let component: Query01Component;
  let fixture: ComponentFixture<Query01Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Query01Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Query01Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
