import { TestBed } from '@angular/core/testing';

import { ShintoCoinsService } from './shinto-coins.service';

describe('ShintoCoinsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ShintoCoinsService = TestBed.get(ShintoCoinsService);
    expect(service).toBeTruthy();
  });
});
