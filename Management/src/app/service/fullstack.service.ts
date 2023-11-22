import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { College } from '../models/College';
import { Student } from '../models/Student';
import { Teacher } from '../models/Teacher';

@Injectable({
  providedIn: 'root'
})
export class FullstackService {

  // userservice:User={
  //   userName:"",
  //   UserEmail:"",
  //   UserPhone:0,
  //   UserPassword:"",
  //   UserRepeatPassword:""
  // }

  constructor(private http:HttpClient) { 

  }
baseurl:string="https://localhost:7216/api";

//login
getLoginService(){
  return this.http.get<any>(`${this.baseurl}/login/getAll`);
}
createLoginService(user:User){
  let postLogin={
    "userName": user.userName,
    "userEmail": user.UserEmail,
    "userPassword": user.UserPassword,
    "userPhoneNumber": user.UserPhone
  }
  return this.http.post<any>(`${this.baseurl}/login/save`,postLogin,{responseType:'json'});
}
// college 
getCollegeService(){
  return this.http.get<any>(`${this.baseurl}/college/getAll`);
}

createCollegeService(clg:College){
  let postCollege={
    "collegeName":clg.collegeName,
    "collegeRank": clg.collegeRank,
    "collegeType": clg.collegeType
  }
  return this.http.post<any>(`${this.baseurl}/college/save`,postCollege,{responseType:'json'});
}

updateCollegeService(i:number,clg:College){
  let putCollege={
    "id": i,
    "collegeName": clg.collegeName,
    "collegeRank": clg.collegeRank,
    "collegeType": clg.collegeType
  }

  return this.http.put<any>(`${this.baseurl}/college/update/${i}`,putCollege,{responseType:'json'});
}

deleteCollegeService(i:number){
 return  this.http.delete<any>(`${this.baseurl}/college/delete/${i}`);
}
//student 

// {
//   "id": 0,
//   "studentName": "string",
//   "studentDepartment": "string",
//   "studentEmail": "string",
//   "studentAge": 0,
//   "studentPhone": "string",
//   "studentFees": 0
// }
getStudentService(){
  return this.http.get<any>(`${this.baseurl}/student/getAll`)
}

createStudentService(std:Student){
  let postStudent={
    "studentName": std.StudentName,
    "studentDepartment": std.studentDepartment,
    "studentEmail": std.studentEmail,
    "studentAge": std.studentAge,
    "studentPhone": std.studentPhone,
    "studentFees": std.studentFees
  }

  return this.http.post<any>(`${this.baseurl}/student/save`,postStudent,{responseType:'json'})
}

updateStudent(i:number,std:Student){
  let putStudent={
    "id":i,
    "studentName": std.StudentName,
    "studentDepartment": std.studentDepartment,
    "studentEmail": std.studentEmail,
    "studentAge": std.studentAge,
    "studentPhone": std.studentPhone,
    "studentFees": std.studentFees
  }

  return this.http.put<any>(`${this.baseurl}/student/update/${i}`,putStudent,{responseType:'json'});
}

removeStudentService(i:number){
  return this.http.delete<any>(`${this.baseurl}/student/delete/${i}`,{responseType:'json'})
}
//teacher

// {
//   "id": 0,
//   "teacherName": "string",
//   "teacherSubject": "string",
//   "teacherSalary": 0
// }

getTeacherService(){
  return this.http.get<any>(`${this.baseurl}/teacher/getAll`);
}
createTeacherService(teacher:Teacher){
  let postTeacher={
    "teacherName": teacher.teacherName,
    "teacherSubject": teacher.teacherSubjet,
    "teacherSalary": teacher.teacherSalary
  }

  return this.http.post<any>(`${this.baseurl}/teacher/save`,postTeacher,{responseType:"json"})
}

updateTeacherService(i:number,teacher:Teacher){
  let putTeacher={
    "id": i,
    "teacherName": teacher.teacherName,
    "teacherSubject": teacher.teacherSubjet,
    "teacherSalary": teacher.teacherSalary
  }
  return this.http.put<any>(`${this.baseurl}/teacher/update/${i}`,putTeacher,{responseType:'json'});
}

removeTeacherService(i:number){
  return this.http.delete<any>(`${this.baseurl}/teacher/delete/${i}`,{responseType:'json'});
}
}
