using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public interface IDeviceService
    {
        List<SelectListItem> DeviceSelectList();
        Task<List<Device>> GetDevices();
        Task AddDevice(Device device);
        Task DeleteDevice(int id);
        Task EditDevice(Device device);
        Task<Device> GetDeviceById(int id);
    }
}
