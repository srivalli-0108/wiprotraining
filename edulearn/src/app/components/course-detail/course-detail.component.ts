import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.component.html',
})
export class CourseDetailComponent {
  @Input() course: any;
}
