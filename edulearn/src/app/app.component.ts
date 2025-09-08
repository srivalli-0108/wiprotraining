import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <h1>EduLearn Course Management</h1>
    <app-course-list
      [courses]="courses"
      (courseSelected)="onCourseSelected($event)">
    </app-course-list>
    <app-course-detail
      [course]="selectedCourse">
    </app-course-detail>
  `,
})
export class AppComponent {
  courses = [
    { id: 1, title: 'Angular Basics' },
    { id: 2, title: 'TypeScript Fundamentals' },
    { id: 3, title: 'RxJS in Practice' },
  ];

  selectedCourse = this.courses[0];

  onCourseSelected(course: any) {
    this.selectedCourse = course;
  }
}
