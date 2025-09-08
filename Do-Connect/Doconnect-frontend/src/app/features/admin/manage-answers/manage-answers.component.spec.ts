import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageAnswersComponent } from './manage-answers.component';

describe('ManageAnswers', () => {
  let component: ManageAnswersComponent;
  let fixture: ComponentFixture<ManageAnswersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageAnswersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManageAnswersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
