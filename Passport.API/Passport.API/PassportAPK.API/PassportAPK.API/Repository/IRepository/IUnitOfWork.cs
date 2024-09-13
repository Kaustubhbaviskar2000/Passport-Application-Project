namespace PassportAPK.API.Repository.IRepository
{
    public interface IUnitOfWork 
    {
        public IUserRepository UserRepository { get; }

        public IServiceRequiredRepository ServiceRequiredRepository { get; }

        public IApplicantDetailsRepository ApplicantDetailsRepository { get;  }

        public IResidentailDetailsRepository ResidentailDetailsRepository { get; }

        public IFamilyDetailsRepository FamilyDetailsRepository { get; }
        public IEmergencyContactDetailsRepository EmergencyContactDetailsRepository { get; }
        public IOtherDetailsRepository OtherDetailsRepository { get; }
        public ISelfDeclarationRepository SelfDeclarationRepository { get; }
        public IMasterDetailsTableRepository MasterDetailsTableRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }

        public  IAdminRepository AdminRepository { get; }
    }
}
