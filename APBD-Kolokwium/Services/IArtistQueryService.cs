using Database.DTOs.Responses;
using System.Threading.Tasks;

namespace Services
{
    public interface IArtistQueryService
    {
        public Task<ArtistQueryResponse> GetAsync(int id);
    }
}