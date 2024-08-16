import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuotationReportMultipleItemComponent } from './quotation-report-multiple-item.component';

describe('QuotationReportMultipleItemComponent', () => {
  let component: QuotationReportMultipleItemComponent;
  let fixture: ComponentFixture<QuotationReportMultipleItemComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [QuotationReportMultipleItemComponent]
    });
    fixture = TestBed.createComponent(QuotationReportMultipleItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
