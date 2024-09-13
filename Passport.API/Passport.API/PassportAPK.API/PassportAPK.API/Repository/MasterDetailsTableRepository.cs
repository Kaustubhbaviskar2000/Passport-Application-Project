using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PassportAPK.API.Data;
using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;
using PassportAPK.API.Repository.IRepository;

namespace PassportAPK.API.Repository
{
    public class MasterDetailsTableRepository : Repository<MasterDetailsTable> , IMasterDetailsTableRepository
    {
        private readonly AppDbContext _context;

        public MasterDetailsTableRepository(AppDbContext context) : base(context)
        {
            _context = context;   
        }

        public async Task<MasterDetailsTable> AddMasterDetailsAsync(MasterDetailsTable masterDetailsTable)
        {
            await _context.MasterDetailsTables.AddAsync(masterDetailsTable);
            await _context.SaveChangesAsync();
            return masterDetailsTable;
        }

        public async Task<TrackPassportDetailsDTO> GetPassportDetailByPassportNumber(TrackPassportStatusDTO trackPassportStatusDTO)
        {
            try
            {
                var user = await _context.MasterDetailsTables.Include(x => x.ApplicantDetails).Include(x => x.ServiceRequired).FirstOrDefaultAsync(passNo => passNo.PassportNumber == trackPassportStatusDTO.PassportNumber);
                TrackPassportDetailsDTO trackPassportDetailsDTO = new TrackPassportDetailsDTO
                {
                    ApplicationType = trackPassportStatusDTO.ApplicationType,
                    DateOfBirth = user.ApplicantDetails.DateOfBirth,
                    FirstName = user.ApplicantDetails.FirstName,
                    LastName = user.ApplicantDetails.LastName,
                    PassportApplicationStatus = user.PassportApplicationStatus,
                    PassportNumber = user.PassportNumber,
                    PaymentStatus = user.PaymentStatus
                };
                return trackPassportDetailsDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task ConfirmPassportPayment(PaymentDTO paymentDTO)
        {
            try
            {
                var payment = await _context.MasterDetailsTables
                                        .FirstOrDefaultAsync(user => user.PassportNumber == paymentDTO.PassportNumber);
                if (payment.PaymentStatus == "Unpaid")
                {
                    payment.PaymentStatus = "Paid";
                    payment.UpdatedOn = DateTime.Now;
                }
                _context.MasterDetailsTables.Update(payment);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                
            }
        }
    }
}
