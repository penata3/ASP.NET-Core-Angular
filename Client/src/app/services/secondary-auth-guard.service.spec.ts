import { TestBed } from '@angular/core/testing';

import { SecondaryAuthGuardService } from './secondary-auth-guard.service';

describe('SecondariAuthGuardService', () => {
  let service: SecondaryAuthGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SecondaryAuthGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
