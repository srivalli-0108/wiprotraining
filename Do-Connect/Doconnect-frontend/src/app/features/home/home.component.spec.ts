import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

describe('HomeComponent', () => {
  let fixture: ComponentFixture<HomeComponent>;
  let component: HomeComponent;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [CommonModule, RouterLink, RouterOutlet],
      declarations: [HomeComponent],
    });

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.autoDetectChanges();
  });

  it('should create the HomeComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should display the welcome message', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Welcome to Our Website');
  });

  it('should have a Learn More button', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    const button = compiled.querySelector('.cta-button');
    expect(button).toBeTruthy();
    expect(button?.textContent).toContain('Learn More About Us');
  });
});
