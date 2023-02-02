import { FacultyListComponent } from './Components/faculty-list/faculty-list.component';
import { ContactComponent } from './Components/contact/contact.component';
import { AboutComponent } from './Components/about/about.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './Components/header/header.component';
import { HomeComponent } from './Components/home/home.component';
import { StudentListComponent } from './Components/student-list/student-list.component';
import { NgxPaginationModule } from 'ngx-pagination';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: 'header',
    component: HeaderComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'about',
    component: AboutComponent,
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    path: 'student-list',
    component: StudentListComponent,
  },
  {
    path: 'faculty-list',
    component: FacultyListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
