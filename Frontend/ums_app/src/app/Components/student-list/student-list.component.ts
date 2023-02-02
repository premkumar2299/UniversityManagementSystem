import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GlobalService } from '../../Services/global.service';
import { studentDetails } from '../../studentDetails.model';

@Component({
  selector: 'University-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss'],
})
export class StudentListComponent implements OnInit {
  constructor(private service: GlobalService, private router: Router) {}

  form = new FormGroup({
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

  pageNumber: number = 1;
  size: number = 7;
  totalElements: number = 0;
  totalPages: number = 0;

  AddStudent() {
    const notNull = document.getElementById('studentModel');
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

  webapi = 'https://localhost:7049/';
  public studentArray: Array<any> = [];

  ngOnInit(): void {
    this.GetPage(this.pageNumber);
  }

  studentList = new studentDetails();

  GetStudData() {
    this.service.GetstudData().subscribe((res: any) => {
      this.studentArray = res;
      console.log(res);
    });
  }

  setData(data: any) {
    this.form.controls['studName'].setValue(data.studName);
    this.form.controls['studFname'].setValue(data.studFname);
    this.form.controls['studRoll'].setValue(data.studRoll);
    this.form.controls['address'].setValue(data.address);
    this.form.controls['dob'].setValue(data.dob);
    this.form.controls['email'].setValue(data.email);
    this.form.controls['phone'].setValue(data.phone);
    this.form.controls['course'].setValue(data.course);
    this.form.controls['branch'].setValue(data.branch);
  }

  updateData() {
    this.service
      .UpdatestudData(this.form.controls['studRoll'].value, this.form.value)
      .subscribe((res: any) => {
        this.studentArray = [];
        this.GetPage(this.pageNumber);
      });
  }
  DeleteData(studRoll: number) {
    this.service.DeletestudData(studRoll).subscribe((res: any) => {
      alert('Are you Sure to Delete this ID=' + studRoll);
      this.GetPage(this.pageNumber);
    });
  }

  GetPage(pgNo: any) {
    this.pageNumber = pgNo;
    this.service.StudPaginator(pgNo).subscribe((res: any) => {
      this.studentArray = res.students;
      this.totalElements = res.totalElements;
      this.totalPages = res.totalPages;
    });
  }

  SearchStudent(name: string) {
    if (name.length > 0) {
      this.service.StudentSearch(name).subscribe(
        (res: any) => {
          this.studentArray = res;
          this.totalElements = 0;
          this.totalPages = 0;
        },
        (error) => {
          alert('No Match Found with your Input');
        }
      );
    } else {
      this.GetPage(1);
      this.pageNumber = 1;
    }
  }
}
