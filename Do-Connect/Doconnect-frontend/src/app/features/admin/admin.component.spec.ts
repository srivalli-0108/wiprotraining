import { TestBed } from '@angular/core/testing';

import { AdminComponent } from './admin.component';

describe('Admin', () => {
  let service: AdminComponent;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdminComponent);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
