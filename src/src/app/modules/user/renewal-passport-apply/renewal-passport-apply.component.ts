import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { formTabs } from '../../../core/constants/form-tab';
import { IAddressForm, IApplicantForm, IDeclarationForm, IEmergencyForm, IFeedbackForm, IQuestionsForm, IReNewForm, IServiceRequestForm } from '../../../core/interfaces/IReNewForm';
import Swal from 'sweetalert2';
import { PassportApplyService } from '../../../core/services/passport-apply.service';
import { PassportStatus } from '../../../core/constants/PassportStatus';
import { Payment } from '../../../core/constants/Payment';
import { IApplicantDetailsForm, IEmergencyContactDetailsForm, IFamilyDetailsForm, INewPassportForm, IOtherDetailsForm, IResidentailDetailsForm, ISelfDeclarationForm } from '../../../core/interfaces/INewPassportForm';
import { ILoggedInUser } from '../../../core/interfaces/ILoggedInUser';
import { PassportType } from '../../../core/constants/PassportType';

@Component({
  selector: 'app-renewal-passport-apply',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './renewal-passport-apply.component.html',
  styleUrls: ['./renewal-passport-apply.component.css']
})
export class RenewalPassportApplyComponent implements OnInit {
  serviceRequestForm: FormGroup = <FormGroup>{};
  applicantForm: FormGroup = <FormGroup>{};
  feedbackForm: FormGroup = <FormGroup>{};
  addressForm: FormGroup = <FormGroup>{};
  emergencyForm: FormGroup = <FormGroup>{};
  questionsForm: FormGroup = <FormGroup>{};
  declarationForm: FormGroup = <FormGroup>{};
  LoggedInUserData:ILoggedInUser = {} as ILoggedInUser;

  districts: string[] = [
    'Ahmednagar', 'Akola', 'Amravati', 'Aurangabad', 'Beed', 'Bhandara', 'Buldhana',
    'Chandrapur', 'Dhule', 'Gadchiroli', 'Gondia', 'Hingoli', 'Jalgaon', 'Jalna',
    'Kolhapur', 'Latur', 'Mumbai City', 'Mumbai Suburban', 'Nagpur', 'Nanded',
    'Nandurbar', 'Nashik', 'Osmanabad', 'Palghar', 'Parbhani', 'Pune', 'Raigad',
    'Ratnagiri', 'Sangli', 'Satara', 'Sindhudurg', 'Solapur', 'Thane', 'Wardha',
    'Washim', 'Yavatmal'
  ];

  states: string[] = [
    'Andhra Pradesh', 'Arunachal Pradesh', 'Assam', 'Bihar', 'Chhattisgarh', 'Goa',
    'Gujarat', 'Haryana', 'Himachal Pradesh', 'Jharkhand', 'Karnataka', 'Kerala',
    'Madhya Pradesh', 'Maharashtra', 'Manipur', 'Meghalaya', 'Mizoram', 'Nagaland',
    'Odisha', 'Punjab', 'Rajasthan', 'Sikkim', 'Tamil Nadu', 'Telangana', 'Tripura',
    'Uttar Pradesh', 'Uttarakhand', 'West Bengal'
  ];
  countries: string[] = ['United States',
    'China',
    'India',
    'Brazil',
    'Nigeria',
    'United Kingdom',
    'Germany',
    'France',
    'Japan',
    'Canada'];
  
  constructor(private fb: FormBuilder, private router: Router,private service:PassportApplyService) {}

  ngOnInit(): void {
    this.serviceRequestForm = this.createServiceRequestForm();
    this.applicantForm = this.createApplicantForm();
    this.feedbackForm = this.createFeedbackForm();
    this.addressForm = this.createAddressForm();
    this.emergencyForm = this.createEmergencyForm();
    this.questionsForm = this.createQuestionsForm();
    this.declarationForm = this.createDeclarationForm();
  }

  
  private createServiceRequestForm(): FormGroup {
    return this.fb.group({
      ApplicationType: ['', Validators.required],
      PagesRequired: ['', Validators.required],
      ValidityRequired: ['', Validators.required],
      reasonForReNewal:['',Validators.required],
      changeInAppreance:[]
    });
  }

  private createApplicantForm(): FormGroup {
    return this.fb.group({
      FirstName: ['', [Validators.required, Validators.pattern(/^[A-Za-z\s]+$/)]],
      LastName: ['', [Validators.required, Validators.pattern(/^[A-Za-z\s]+$/)]],
      IsAliasName: ['', Validators.required],
      IsChangedName: ['', Validators.required],
      DateOfBirth: ['', Validators.required],
      PlaceOfBirth: ['', Validators.required],
      Gender: ['', Validators.required],
      District: ['', Validators.required],
      State: ['', Validators.required],
      Country: ['', Validators.required],
      PanCardNumber: ['', [Validators.required, Validators.pattern(/^[A-Z]{5}[0-9]{4}[A-Z]{1}$/)]],
      VoterId: ['', ],
      MaritialStatus: ['', Validators.required],
      EmployeementType: ['', Validators.required],
      OrganizationalName: [''],
      parentOrSpouseGovServant: ['', Validators.required],
      EducationQualification: ['', Validators.required],
      IsNonECR: ['', Validators.required],
      DistinguishMark: ['', Validators.required],
      AdharCardNumber: ['', [Validators.required, Validators.pattern(/^[0-9]{12}$/)]],
      ChangedName:[''],
      AliasName:[''],
      passportNumber:['',Validators.required],
      dateOfIssue:['',Validators.required],
      placeOfIssue:['',Validators.required]
    });
  }

  private createFeedbackForm(): FormGroup {
    return this.fb.group({
      FatherFirstName: ['', [Validators.required]],
      FatherLastName: ['', [Validators.required]],
      MotherFirstName: ['', [Validators.required]],
      MotherLastName: ['', [Validators.required]],
      LegalGuardianFirstName: ['', [Validators.required]],
      LegalGuardianLastName: ['', [Validators.required]],
      SpouceFirstName: ['', ],
      SpouceLastName: ['',],
      fatherPassportNumber: ['', ],
      fatherNationality: ['', ],
      motherPassportNumber: ['', ],
      motherNationality: ['',]
    });
  }

  private createAddressForm(): FormGroup {
    return this.fb.group({
      HouseNoAndName: ['', Validators.required],
      City: ['', Validators.required],
      District: ['', Validators.required],
      State: ['', Validators.required],
      PinCode: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]],
      MobileNumber: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      TelephoneNumber: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
      AddressLane1: ['',]
    });
  }

  private createEmergencyForm(): FormGroup {
    return this.fb.group({
      ContactName: ['', Validators.required],
      Address: ['', Validators.required],
      MobileNumber: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      EmailAddress: ['', [Validators.required, Validators.email]],
      City: ['', Validators.required],
      State: ['', Validators.required]
    });
  }

  private createQuestionsForm(): FormGroup {
    return this.fb.group({
      IsCriminalProceedings: ['', Validators.required],
      IsWarrantSummons: ['', Validators.required],
      IsArrestWarrant: ['', Validators.required],
      IsDepartureOrder: ['', Validators.required],
      IsConviction: ['', Validators.required],
      IsPassportRefusal: ['', Validators.required],
      IsPassportImpounded: ['', Validators.required],
      IsPassportRevoked: ['', Validators.required],
      IsForeignCitizenship: ['', Validators.required],
      IsOtherPassport: ['', Validators.required],
      IsSurrenderedPassport: ['', Validators.required],
      IsRenunciation: ['', Validators.required],
      IsEmergencyCertificate: ['', Validators.required],
      IsDeported: ['', Validators.required],
      IsRepatriated: ['', Validators.required]
    });
  }

  private createDeclarationForm(): FormGroup {
    return this.fb.group({
      IsAcceptTermsAndCondition: [false, Validators.requiredTrue],
      Place: ['', Validators.required],
      DateOfApplied: ['', Validators.required]
      // ApplicantPhoto: [null],
      // Signature: [null],
      // AadharCard:[null],
      // PanCard:[null]
    });
  }

  onFileChange(event: Event, controlName: string): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      this.declarationForm.patchValue({
        [controlName]: input.files[0]
      });
      this.declarationForm.get(controlName)?.markAsTouched();
      this.declarationForm.get(controlName)?.updateValueAndValidity();
    }
  }

  GenerateNewPassportNumber = () =>{
    let passportNumber= Math.floor(Math.random() * 10000000000).toString();

    while (passportNumber.length < 10) {
        passportNumber = '0' + passportNumber;
    };
    return passportNumber;
  }

  generateRandomID = () =>{
    let passportNumber= Math.floor(Math.random() * 10000000000).toString();

    while (passportNumber.length < 4) {
        passportNumber = '0' + passportNumber;
    };
    return passportNumber;
  }
  GetUserId = ():number =>{
    if(typeof window !== 'undefined' && window.localStorage){
      const data = localStorage.getItem('loggedUser');
      if(data){
        this.LoggedInUserData = JSON.parse(data);
      }          
    }
    return this.LoggedInUserData.userId;
  }
  onSubmit(): void {
    if(this.declarationForm.invalid){
      this.declarationForm.markAllAsTouched();
    }
    if (this.serviceRequestForm.valid && this.emergencyForm.valid && this.declarationForm.valid && this.questionsForm.valid &&
        this.applicantForm.valid && this.addressForm.valid && this.feedbackForm.valid
    ) {
      const passportAppNumber =  this.GenerateNewPassportNumber();
      const _id = this.generateRandomID();
      const ReNewPassportApply:INewPassportForm = {
        id:_id,
        userId:this.GetUserId(),
        PassportNumber:passportAppNumber,
        PassportApplicationStatus:PassportStatus.New,
        PaymentStatus:Payment.Unpaid,
        PassportType:PassportType.ReNew,
        ServiceRequired: this.serviceRequestForm.value as IServiceRequestForm,
        ApplicantDetails: this.applicantForm.value as IApplicantDetailsForm,
        FamilyDetails: this.feedbackForm.value as IFamilyDetailsForm,
        ResidentailDetails: this.addressForm.value as IResidentailDetailsForm,
        EmergencyContactDetails: this.emergencyForm.value as IEmergencyContactDetailsForm,
        OtherDetails: this.questionsForm.value as IOtherDetailsForm,
        SelfDeclaration: this.declarationForm.value as ISelfDeclarationForm
      };
      console.log(ReNewPassportApply);
      Swal.fire({
        title: "Application Submitted",
        text: `Your application has been submitted successfully!  Make payment for application no ${passportAppNumber}`,
        icon: "success"
      }).then((res)=>{
        if(res.isConfirmed){
          this.service.SaveReNewPassportForm(ReNewPassportApply).subscribe((data)=>{
            this.router.navigate(['user']);
          }) 
        }
      });
    }else{
      Swal.fire({
        title: "In-complete form fields.",
        text: "Please fill the remaining form fields.",
        icon: "info"
      })
    }
  }

  private navigateToNextTabIfValid(form: FormGroup, tabId: string): void {
    let activeTab = document.querySelector('.nav-tabs .nav-link.active');
    if (activeTab?.id.toString() === tabId && form.invalid) {
      form.markAllAsTouched();
      return;
    }
    if (activeTab) {
      let nextTab = activeTab.parentElement?.nextElementSibling;
      if (nextTab) {
        (nextTab.querySelector('.nav-link') as HTMLElement).click();
      }
    }
  }

  showNextTab(index: number): void {
    switch (index) {
      case 1:
        this.navigateToNextTabIfValid(this.serviceRequestForm, formTabs.servicetab);
        break;
      case 2:
        this.navigateToNextTabIfValid(this.applicantForm, formTabs.applicanttab);
        break;
      case 3:
        this.navigateToNextTabIfValid(this.feedbackForm, formTabs.familytab);
        break;
      case 4:
        this.navigateToNextTabIfValid(this.addressForm, formTabs.residentialtab);
        break;
      case 5:
        this.navigateToNextTabIfValid(this.emergencyForm, formTabs.emergencytab);
        break;
      case 6:
        this.navigateToNextTabIfValid(this.questionsForm, formTabs.othertab);
        break;
      case 7:
        this.navigateToNextTabIfValid(this.declarationForm, formTabs.declarationtab);
        break;
      default:
        break;
    }
  }
  showPreviousTab() {
    let activeTab = document.querySelector('.nav-tabs .nav-link.active');
    if (activeTab) {
        let previousTab = activeTab.parentElement?.previousElementSibling;
        if (previousTab) {
            (previousTab.querySelector('.nav-link') as HTMLElement).click();
        }
    }
}
}
