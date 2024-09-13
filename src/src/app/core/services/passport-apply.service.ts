import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { INewPassportForm } from '../interfaces/INewPassportForm';
import { catchError, map, Observable, of, switchMap } from 'rxjs';
import { IReNewForm } from '../interfaces/IReNewForm';
import { environment } from '../../environment/environment';
import { AdminNewPassportList } from '../interfaces/AdminNewPassportList';

@Injectable({
  providedIn: 'root'
})
export class PassportApplyService {

  myURL = environment.apiUrl;
  backendAPIURL = environment.backendUrl;

  constructor(private http:HttpClient) { }

  SaveNewPassportForm = (data:INewPassportForm):Observable<INewPassportForm> =>{
    console.log(data);
    return this.http.post<INewPassportForm>(`${this.backendAPIURL}/NewPassport/NewPassportApply`,data);
  }
  GetAllNewPassportData = ():Observable<AdminNewPassportList[]> =>{
    return this.http.get<AdminNewPassportList[]>(`${this.backendAPIURL}/Admin/GetNewPassportDetail`);
  }
 
 
  SaveReNewPassportForm = (data:INewPassportForm):Observable<INewPassportForm> =>{
    return this.http.post<INewPassportForm>(`${this.backendAPIURL}/ReNewPassport/CreateReNewPassport`,data);
  }

  GetAllReNewPassportData = ():Observable<AdminNewPassportList[]> =>{
    return this.http.get<AdminNewPassportList[]>(`${this.backendAPIURL}/Admin/GetReNewPassportDetail`);
  }
  GetAllPassportData = (): Observable<INewPassportForm[] | IReNewForm[]> => {
    return this.http.get<INewPassportForm[]>(this.myURL+"/NewPassportApply").pipe(
      switchMap(response1 => {
        if (response1 && response1.length > 0) {
          return of(response1 as INewPassportForm[]);
        } else {
          return this.http.get<IReNewForm[]>(this.myURL+"/Re-NewPassport");
        }
      }),
      catchError(error => {
        console.error('Error fetching data', error);
        return of([] as INewPassportForm[] | IReNewForm[]);
      })
    );
  }
  getNewPassportById(id: number): Observable<AdminNewPassportList> {
     return this.http.get<AdminNewPassportList>(`${this.backendAPIURL}/Admin/GetNewPassportDetailById?id=${id}`);
  }

  editNewPassportData = (id:number,data:AdminNewPassportList):Observable<AdminNewPassportList> =>{
    return this.http.put<AdminNewPassportList>(`${this.backendAPIURL}/Admin/UpdateNewPassportData?id=${id}`,data);
  }
  getReNewPassportById = (id:string):Observable<AdminNewPassportList> =>{
    return this.http.get<AdminNewPassportList>(`${this.myURL}/Re-NewPassport/${id}`)
  }

  editReNewPassportData = (id:number,data:AdminNewPassportList):Observable<AdminNewPassportList> =>{
    return this.http.put<AdminNewPassportList>(`${this.backendAPIURL}/Admin/UpdateReNewPassportData?id=${id}`,data);
  }
}
