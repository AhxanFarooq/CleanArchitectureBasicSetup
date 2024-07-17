import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddQuotationComponent } from './add-quotation.component';

describe('AddQuotationComponent', () => {
  let component: AddQuotationComponent;
  let fixture: ComponentFixture<AddQuotationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddQuotationComponent]
    });
    fixture = TestBed.createComponent(AddQuotationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
