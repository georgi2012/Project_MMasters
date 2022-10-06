import { TestBed } from '@angular/core/testing';

import { OrbsService } from './orbs.service';

describe('OrbsService', () => {
  let service: OrbsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrbsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
