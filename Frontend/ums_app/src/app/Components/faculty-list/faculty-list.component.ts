import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { facultyDetails } from '../../facultyDetails.model';
import { GlobalService } from '../../Services/global.service';

@Component({
  selector: 'University-faculty-list',
  templateUrl: './faculty-list.component.html',
  styleUrls: ['./faculty-list.component.scss'],
})
export class FacultyListComponent implements OnInit {
  constructor(private service: GlobalService, private router: Router) {}

  form = new FormGroup({
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

  public facultyArray: Array<any> = [];

  ngOnInit(): void {
    this.GetFacultyPaged(this.pageNumber);
  }

  facultyList = new facultyDetails();

  GetFacultyData(data: any) {
    this.service.GetfacultyData().subscribe((res: any) => {
      this.facultyArray = res;
    });
  }

  setData(data: any) {
    this.form.controls['facultyName'].setValue(data.facultyName);
    this.form.controls['facultyFname'].setValue(data.facultyFname);
    this.form.controls['empId'].setValue(data.empId);
    this.form.controls['address'].setValue(data.address);
    this.form.controls['dob'].setValue(data.dob);
    this.form.controls['email'].setValue(data.email);
    this.form.controls['phone'].setValue(data.phone);
    this.form.controls['education'].setValue(data.education);
    this.form.controls['department'].setValue(data.department);
  }

  updateData() {
    this.service
      .UpdatefacultyData(this.form.controls['empId'].value, this.form.value)
      .subscribe((res: any) => {
        this.facultyArray = [];
        this.GetFacultyPaged(this.pageNumber);
      });
  }
  DeleteData(empId: number) {
    this.service.DeletefacultyData(empId).subscribe((res: any) => {
      alert('Are you Sure to Delete this ID=' + empId);
      this.GetFacultyPaged(this.pageNumber);
    });
  }

  GetFacultyPaged(pgNo: any) {
    this.pageNumber = pgNo;
    this.service.FacultyPaginator(pgNo).subscribe((res: any) => {
      this.facultyArray = res.faculty;
      this.totalElements = res.totalElements;
      this.totalPages = res.totalPages;
    });
  }

  SearchFaculty(name: string) {
    if (name.length > 0) {
      this.service.FacultySearch(name).subscribe(
        (res: any) => {
          this.facultyArray = res;
          this.totalElements = 0;
          this.totalPages = 0;
        },
        (error) => {
          alert('No Match Found with your Input');
        }
      );
    } else {
      this.GetFacultyPaged(1);
      this.pageNumber = 1;
    }
  }
}
