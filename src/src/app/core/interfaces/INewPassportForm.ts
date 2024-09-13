import { PassportStatus } from "../constants/PassportStatus";
import { PassportType } from "../constants/PassportType";
import { Payment } from "../constants/Payment";

// Interface for Service Request Form
export interface IServiceRequestForm {
    ApplicationType: string;
    PagesRequired: string;
    ValidityRequired: string;
    reasonForReNewal?: string;
    changeInAppreance?: string;
  }
  
  // Interface for Applicant Form
  export interface IApplicantDetailsForm {
    FirstName: string;
    LastName: string;
    IsAliasName: boolean;
    IsChangedName: boolean;
    DateOfBirth: Date;
    PlaceOfBirth: string;
    Gender: string;
    ChangedName?:string;
    AliasName?:string;
    District: string;
    State: string;
    Country: string;
    PanCardNumber: string;
    VoterId: string;
    MaritialStatus: string;
    EmployeementType: string;
    OrganizationalName: string;
    parentOrSpouseGovServant: boolean;
    EducationQualification: string;
    IsNonECR: boolean;
    DistinguishMark: string;
    AdharCardNumber: string;
    passportNumber?: string;
    dateOfIssue?: string;
    placeOfIssue?: string;
  }
  
  // Interface for Feedback Form
  export interface IFamilyDetailsForm {
    FatherFirstName: string;
    FatherLastName: string;
    MotherFirstName: string;
    MotherLastName: string;
    LegalGuardianFirstName: string;
    LegalGuardianLastName: string;
    SpouceFirstName?: string;
    SpouceLastName?: string;
    // fatherPassportNumber?: string;
    // fatherNationality?: string;
    // motherPassportNumber?: string;
    // motherNationality?: string;
  }
  
  // Interface for Address Form
  export interface IResidentailDetailsForm {
    HouseNoAndName: string;
    Street: string;
    AddressLane1: string;
    City: string;
    MobileNumber: string;
    TelephoneNumber: string;
    District: string;
    State?: string;
    Country : string;
    PinCode : string; 
  }
  
  // Interface for Emergency Form
  export interface IEmergencyContactDetailsForm {
    ContactName: string;
    Address: string;
    MobileNumber: string;
    EmailAddress: string;
    City: string;
    PinCode: string;
    District : string;
    State : string;
  }
  
  // Interface for Questions Form
  export interface IOtherDetailsForm {
    IsCriminalProceedings: boolean;
    IsWarrantSummons: boolean;
    IsArrestWarrant: boolean;
    IsDepartureOrder: boolean;
    IsConviction: boolean;
    IsPassportRefusal: boolean;
    IsPassportImpounded: boolean;
    IsPassportRevoked: boolean;
    IsForeignCitizenship: boolean;
    IsOtherPassport: boolean;
    IsSurrenderedPassport: boolean;
    IsRenunciation: boolean;
    IsEmergencyCertificate: boolean;
    IsDeported: boolean;
    IsRepatriated: boolean;
  }
  
  // Interface for Declaration Form
 export interface ISelfDeclarationForm {
  IsAcceptTermsAndCondition: boolean;
  Place: string;
  DateOfApplied: string;
  ApplicantPhoto: File | null;  // Type changed to File
  Signature: File | null;       // Type changed to File
  AadharCard: File | null;      // Type changed to File
  PanCard: File | null;         // Type changed to File
  
}

  
// Combined Interface for All Forms
export interface INewPassportForm {
    id:string;
    userId:number
    PassportNumber:string;
    PassportType:PassportType;
    PassportApplicationStatus:PassportStatus;
    PaymentStatus:Payment;
    ServiceRequired: IServiceRequestForm;
    ApplicantDetails: IApplicantDetailsForm;
    FamilyDetails: IFamilyDetailsForm;
    ResidentailDetails: IResidentailDetailsForm;
    EmergencyContactDetails: IEmergencyContactDetailsForm;
    OtherDetails: IOtherDetailsForm;
    SelfDeclaration : ISelfDeclarationForm;
  } 
  