import { Role } from "../constants/Role";

export interface IUserRegistration {
    userId:string;
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    emailAddress: string;
    loginId: string;
    password: string;
    phoneNumber:number;
    role:Role;
  }