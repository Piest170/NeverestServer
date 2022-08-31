import { TestBed } from '@angular/core/testing';

import { CharacterskillService } from './characterskill.service';

describe('CharacterskillService', () => {
  let service: CharacterskillService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CharacterskillService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
