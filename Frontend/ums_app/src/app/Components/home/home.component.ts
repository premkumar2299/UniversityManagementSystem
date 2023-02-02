import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { GlobalService } from '../../Services/global.service';

@Component({
  selector: 'University-Home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  Studentform = new FormGroup({
    studName: new FormControl(),
    studFname: new FormControl(),
    studRoll: new FormControl(),
    address: new FormControl(),
    dob: new FormControl(),
    email: new FormControl(),
    phone: new FormControl(),
    course: new FormControl(),
    branch: new FormControl(),
  });

  Facultyform = new FormGroup({
    facultyName: new FormControl(),
    facultyFname: new FormControl(),
    empId: new FormControl(),
    address: new FormControl(),
    dob: new FormControl(),
    email: new FormControl(),
    phone: new FormControl(),
    education: new FormControl(),
    department: new FormControl(),
  });

  constructor(private router: Router, private globalService: GlobalService) {}
  ngOnInit(): void {}

  AddStudent() {
    const notNull = document.getElementById('studentModel');
    if (notNull != null) {
      notNull.style.display = 'block';
    }
  }
  AddFaculty() {
    const notNull = document.getElementById('facultyModel');
    if (notNull != null) {
      notNull.style.display = 'block';
    }
  }
  CloseStudentModel() {
    const notNull = document.getElementById('studentModel');
    if (notNull != null) {
      notNull.style.display = 'none';
    }
  }
  CloseFacultyModel() {
    const notNull = document.getElementById('facultyModel');

    if (notNull != null) {
      notNull.style.display = 'none';
    }
  }

  PoststudData() {
    console.log(this.Studentform.value);
    this.globalService
      .PoststudData(this.Studentform.value)
      .subscribe((res: any) => {
        // console.log(this.GetData)
        //this.GetData = res
        this.router.navigateByUrl('student-list');
      });
  }

  PostfacultyData() {
    console.log(this.Facultyform.value);
    this.globalService
      .PostfacultyData(this.Facultyform.value)
      .subscribe((res: any) => {
        // console.log(this.GetData)
        //this.GetData = res
        this.router.navigateByUrl('faculty-list');
      });
  }
}
