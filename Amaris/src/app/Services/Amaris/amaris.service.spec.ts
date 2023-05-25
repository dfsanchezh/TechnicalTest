import { TestBed } from '@angular/core/testing';

import { AmarisService } from './amaris.service';

describe('AmarisService', () => {
  let service: AmarisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AmarisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
