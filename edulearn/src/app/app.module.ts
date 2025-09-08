import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { CourseListComponent } from './components/course-list/course-list.component';
import { CourseDetailComponent } from './components/course-detail/course-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    CourseListComponent,
    CourseDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule  // ✅ Required for ngModel
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
