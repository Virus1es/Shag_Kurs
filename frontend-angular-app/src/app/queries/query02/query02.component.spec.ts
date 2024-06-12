import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Query02Component } from './query02.component';

describe('Query02Component', () => {
  let component: Query02Component;
  let fixture: ComponentFixture<Query02Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Query02Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Query02Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
