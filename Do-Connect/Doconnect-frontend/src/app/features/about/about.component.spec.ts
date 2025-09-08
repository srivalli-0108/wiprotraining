import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AboutComponent } from './about.component';
import { CommonModule } from '@angular/common';

describe('AboutComponent', () => {
  let fixture: ComponentFixture<AboutComponent>;
  let component: AboutComponent;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [CommonModule],
      declarations: [AboutComponent]
    });

    fixture = TestBed.createComponent(AboutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the AboutComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should display the About Us header', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('header h1')?.textContent).toContain('About Us');
  });

  it('should display the mission statement', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('article h2')?.textContent).toContain('Our Mission');
  });
});
