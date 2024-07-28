import { TestBed } from '@angular/core/testing';

import { PrintDownloadService } from './print-download.service';

describe('PrintDownloadService', () => {
  let service: PrintDownloadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrintDownloadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
