using mnpd_dispatch_viewer.Models;

namespace mnpd_dispatch_viewer.Services
{
    public interface IRestService
    {
        Task<List<DispatchItem>> RefreshDataAsync();
    }
}
