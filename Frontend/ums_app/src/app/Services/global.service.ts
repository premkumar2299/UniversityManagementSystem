import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GlobalService {
  webapi = 'https://localhost:7049/';
  constructor(private http: HttpClient) {}

  //For Student details:

  PoststudData(data: any) {
    return this.http.post(this.webapi + 'api/Student', data);
  }

  GetstudData() {
    return this.http.get(this.webapi + 'api/Student');
  }

  UpdatestudData(rollno: string, data: any) {
    return this.http.put(this.webapi + 'api/Student?rollNum=' + rollno, data);
  }

  DeletestudData(studRoll: number) {
    return this.http.delete(
      this.webapi + 'api/Student/id?StudRoll=' + studRoll
    );
  }

  StudPaginator(pgNo: number) {
    return this.http.get(this.webapi + `api/Student/pagedGet?pgno=${pgNo}`);
  }

  StudentSearch(name: string) {
    return this.http.get(this.webapi + `api/Student/search?name=${name}`);
  }
  //For Faculty Details:

  PostfacultyData(data: any) {
    return this.http.post(this.webapi + 'api/Teacher', data);
  }

  GetfacultyData() {
    return this.http.get(this.webapi + 'api/Teacher');
  }

  UpdatefacultyData(id: string, data: any) {
    return this.http.put(this.webapi + 'api/Teacher?EmpId=' + id, data);
  }

  DeletefacultyData(empId: number) {
    return this.http.delete(this.webapi + 'api/Teacher/id?empId=' + empId);
  }

  FacultyPaginator(pgNo: number) {
    return this.http.get(this.webapi + `api/Teacher/pagedfaculty?pgno=${pgNo}`);
  }

  FacultySearch(name: string) {
    return this.http.get(this.webapi + `api/Teacher/Fsearch?name=${name}`);
  }
}
