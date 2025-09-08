import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminApprovalComponent } from './admin-approval.component';
import { AdminService } from "../../../core/services/admin.services";
import { of, throwError } from 'rxjs';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('AdminApproveComponent', () => {
  let component: AdminApprovalComponent;
  let fixture: ComponentFixture<AdminApprovalComponent>;
  let mockAdminService: jasmine.SpyObj<AdminService>;

  beforeEach(async () => {
    const adminServiceSpy = jasmine.createSpyObj('AdminService', [
      'getPendingQuestions',
      'getPendingAnswers',
      'approveQuestion',
      'rejectQuestion',
      'approveAnswer',
      'rejectAnswer'
    ]);

    await TestBed.configureTestingModule({
      declarations: [AdminApprovalComponent],
      imports: [HttpClientTestingModule],
      providers: [
        { provide: AdminService, useValue: adminServiceSpy }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(AdminApprovalComponent);
    component = fixture.componentInstance;
    mockAdminService = TestBed.inject(AdminService) as jasmine.SpyObj<AdminService>;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should load pending questions and answers on init', () => {
    const dummyQuestions = [{ questionId: 1, questionTitle: 'Test', questionText: 'Test content' }];
    const dummyAnswers = [{ answerId: 1, answerText: 'Answer content' }];

    mockAdminService.getPendingQuestions.and.returnValue(of(dummyQuestions));
    mockAdminService.getPendingAnswers.and.returnValue(of(dummyAnswers));

    component.ngOnInit();

    expect(mockAdminService.getPendingQuestions).toHaveBeenCalled();
    expect(mockAdminService.getPendingAnswers).toHaveBeenCalled();
    expect(component.pendingQuestions).toEqual(dummyQuestions);
    expect(component.pendingAnswers).toEqual(dummyAnswers);
  });

  it('should approve a question', () => {
    mockAdminService.approveQuestion.and.returnValue(of({}));
    spyOn(component, 'loadPendingContent');

    component.approveQuestion(1);

    expect(mockAdminService.approveQuestion).toHaveBeenCalledWith(1);
    expect(component.loadPendingContent).toHaveBeenCalled();
  });

  it('should reject a question', () => {
    mockAdminService.rejectQuestion.and.returnValue(of({}));
    spyOn(component, 'loadPendingContent');

    component.rejectQuestion(1);

    expect(mockAdminService.rejectQuestion).toHaveBeenCalledWith(1);
    expect(component.loadPendingContent).toHaveBeenCalled();
  });

  it('should approve an answer', () => {
    mockAdminService.approveAnswer.and.returnValue(of({}));
    spyOn(component, 'loadPendingContent');

    component.approveAnswer(1);

    expect(mockAdminService.approveAnswer).toHaveBeenCalledWith(1);
    expect(component.loadPendingContent).toHaveBeenCalled();
  });

  it('should reject an answer', () => {
    mockAdminService.rejectAnswer.and.returnValue(of({}));
    spyOn(component, 'loadPendingContent');

    component.rejectAnswer(1);

    expect(mockAdminService.rejectAnswer).toHaveBeenCalledWith(1);
    expect(component.loadPendingContent).toHaveBeenCalled();
  });

  it('should handle errors in loadPendingContent()', () => {
    mockAdminService.getPendingQuestions.and.returnValue(throwError(() => new Error('Error')));
    mockAdminService.getPendingAnswers.and.returnValue(throwError(() => new Error('Error')));

    // This should not throw an error
    component.loadPendingContent();

    expect(mockAdminService.getPendingQuestions).toHaveBeenCalled();
    expect(mockAdminService.getPendingAnswers).toHaveBeenCalled();
  });
});
