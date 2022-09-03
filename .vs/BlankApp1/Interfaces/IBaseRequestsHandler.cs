using BlankApp1.Dto;
using System.Threading.Tasks;

namespace BlankApp1.Interfaces
{
    public interface IBaseRequestsHandler
    {
        Task<string> GetAsync(string url);
        Task AddAsync(string url, CustomerRequestDto dto);
        Task DeleteAsync(string url);
    }
}
