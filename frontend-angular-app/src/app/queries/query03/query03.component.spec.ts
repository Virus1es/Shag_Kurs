import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Query03Component } from './query03.component';

describe('Query03Component', () => {
  let component: Query03Component;
  let fixture: ComponentFixture<Query03Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Query03Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Query03Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
