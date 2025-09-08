import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
})
export class CourseListComponent {
  @Input() courses: any[] = [];
  @Output() courseSelected = new EventEmitter<any>();

  selectCourse(course: any) {
    this.courseSelected.emit(course);
  }
}
