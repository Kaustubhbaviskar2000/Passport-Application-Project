import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { IUserRegistration } from '../interfaces/IUserRegistration';
import { IFeedbackForm } from '../interfaces/IFeedbackForm';
import { Feedback } from '../constants/Feedback';
import { environment } from '../../environment/environment';
import { ILoginCredentials } from '../interfaces/ILoginCredentials';
import { ILoggedInUser } from '../interfaces/ILoggedInUser';
import { ITrackPassportData } from '../interfaces/ITrackPassportData';
import { ITrackPassportDetails } from '../interfaces/ITrackPassportDetails';
import { IPaymentDetails } from '../interfaces/IPaymentDetails';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  myURL = environment.apiUrl;
  backendAPIURL = environment.backendUrl;
  // isLoggedIn$ = new BehaviorSubject<boolean>(this.isLoggedIn());

  constructor(private http:HttpClient) {   }

  RegisterUser = (user:IUserRegistration):Observable<IUserRegistration> =>{
    return this.http.post<IUserRegistration>(this.backendAPIURL+"/Auth/RegisterUser",user);
  }

  LoginUser = (credentials:ILoginCredentials):Observable<ILoggedInUser> =>{
    return this.http.post<ILoggedInUser>(`${this.backendAPIURL}/Auth/LoginUser`,credentials);
  }

  LoginIdExist = (loginId: string): Observable<boolean> => {
    return this.http.get<boolean>(`${this.backendAPIURL}/Auth/CheckLoginIdExist?loginId=${loginId}`);
  }

  GetAllUser = ():Observable<IUserRegistration[]> =>{
    return this.http.get<IUserRegistration[]>(`${this.backendAPIURL}/Admin/GetAllUser`);
  }

  SaveFeedback = (data:IFeedbackForm):Observable<IFeedbackForm> =>{
    return this.http.post<IFeedbackForm>(this.backendAPIURL+"/Feedback/CreateNewFeedback",data)
  }
  GetUserFeedback = (): Observable<IFeedbackForm[]> => 
    this.http.get<IFeedbackForm[]>(`${this.backendAPIURL}/Admin/GetAllFeedback`).pipe(
      map(data => data.filter(x => x.feedbackType === Feedback.Feedback))
  );

  GetUserComplaints = ():Observable<IFeedbackForm[]> =>
    this.http.get<IFeedbackForm[]>(`${this.backendAPIURL}/Admin/GetAllComplaints`).pipe(
      map(data => data.filter(x => x.feedbackType === Feedback.Complaint))
    );
  

  deleteUser = (id: string): Observable<IUserRegistration> =>{
      return this.http.delete<IUserRegistration>(`${this.backendAPIURL}/Admin/DeleteUser?id=${id}`);
  }

  getUserById = (id: string):Observable<IUserRegistration> =>{
    return this.http.get<IUserRegistration>(`${this.backendAPIURL}/Admin/GetUserById?id=${id}`);
  }
  editUser = (id: string,user: IUserRegistration):Observable<IUserRegistration> =>{
    return this.http.put<IUserRegistration>(`${this.backendAPIURL}/Admin/UpdateUser?id=${id}`,user)
  }

  deleteComplaintById = (id:string):Observable<IFeedbackForm> =>{
    return this.http.delete<IFeedbackForm>(`${this.backendAPIURL}/Admin/DeleteComplaint?id=${id}`);
  }

  getComplentById = (id:string):Observable<IFeedbackForm> =>{
    return this.http.get<IFeedbackForm>(`${this.backendAPIURL}/Admin/GetComplaintById?id=${id}`)
  }
  updateComplaintStatus = (id:string,feedbackData:IFeedbackForm):Observable<IFeedbackForm> =>{
    return this.http.put<IFeedbackForm>(`${this.backendAPIURL}/Admin/UpdateComplaint?id=${id}`,feedbackData)
  }

  TrackPassportStatus = (trackDetails:ITrackPassportData):Observable<ITrackPassportDetails> =>{
    return this.http.post<ITrackPassportDetails>(`${this.backendAPIURL}/User/TrackPassportStatus`,trackDetails);
  }

  MakePassportPayment = (paymentData:IPaymentDetails):Observable<any> =>{
    return this.http.post<any>(`${this.backendAPIURL}/User/MakePayment`,paymentData)
  }
  // isLoggedIn = () =>{
  //   if(typeof window !== 'undefined' && window.localStorage){
  //     return !!localStorage.getItem('loggedUser');
  //   }else{
  //     return false;
  //   }
  // }

}



