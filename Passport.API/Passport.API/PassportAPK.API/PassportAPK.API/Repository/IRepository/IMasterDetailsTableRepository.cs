using PassportAPK.API.DTO_s;
using PassportAPK.API.Models;

namespace PassportAPK.API.Repository.IRepository
{
    public interface IMasterDetailsTableRepository : IRepository<MasterDetailsTable>
    {
        Task<MasterDetailsTable> AddMasterDetailsAsync(MasterDetailsTable masterDetailsTable);

        Task<TrackPassportDetailsDTO> GetPassportDetailByPassportNumber(TrackPassportStatusDTO trackPassportStatusDTO);

        Task ConfirmPassportPayment(PaymentDTO paymentDTO);
    }
}
