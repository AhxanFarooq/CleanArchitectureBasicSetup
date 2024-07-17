import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndustryComponent } from './industry.component';

describe('IndustryComponent', () => {
  let component: IndustryComponent;
  let fixture: ComponentFixture<IndustryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [IndustryComponent]
    });
    fixture = TestBed.createComponent(IndustryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
