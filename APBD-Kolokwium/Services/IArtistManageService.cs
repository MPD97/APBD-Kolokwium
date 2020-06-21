using Database.DTOs.Requests;
using Database.DTOs.Responses;
using System.Threading.Tasks;

namespace Services
{
    public interface IArtistManageService
    {
        public Task<IResponseModel> ChangePerfomanceDate(ArtistChangePerformanceDateRequest command);
    }
}