using Database.DTOs.Requests;
using Database.DTOs.Responses;
using System.Threading.Tasks;

namespace Services
{
    public interface IArtistManageService
    {
        public Task<ArtistChangePerformanceDateResponse> ChangePerfomanceDate(ArtistChangePerformanceDateRequest command);
    }
}