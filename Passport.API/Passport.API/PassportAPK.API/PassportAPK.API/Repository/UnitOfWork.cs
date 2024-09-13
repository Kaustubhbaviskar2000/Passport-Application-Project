using PassportAPK.API.Data;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository UserRepository { get; private set; }

        public IServiceRequiredRepository ServiceRequiredRepository { get; private set; }

        public IApplicantDetailsRepository ApplicantDetailsRepository { get; private set; }
        public IResidentailDetailsRepository ResidentailDetailsRepository { get; private set; }

        public IFamilyDetailsRepository FamilyDetailsRepository { get; private set; }
        
        public IEmergencyContactDetailsRepository EmergencyContactDetailsRepository { get; private set; }
        public IOtherDetailsRepository OtherDetailsRepository { get; private set; }
        public ISelfDeclarationRepository SelfDeclarationRepository { get; private set; }
        public IMasterDetailsTableRepository MasterDetailsTableRepository { get; private set; }

        public IAdminRepository AdminRepository { get; set; }
        public IFeedbackRepository FeedbackRepository { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ServiceRequiredRepository = new ServiceRequiredRepository(_context);
            ApplicantDetailsRepository = new ApplicantDetailsRepository(_context);
            ResidentailDetailsRepository = new ResidentailDetailsRepository(_context);
            FamilyDetailsRepository = new FamilyDetailsRepository(_context);
            EmergencyContactDetailsRepository = new EmergencyContactDetailsRepository(_context);
            OtherDetailsRepository = new OtherDetailsRepository(_context);
            SelfDeclarationRepository = new SelfDeclarationRepository(_context);
            MasterDetailsTableRepository = new MasterDetailsTableRepository(_context);
            FeedbackRepository = new FeedbackRepository(_context);
            AdminRepository = new AdminRepository(_context);
        }
    }
}
