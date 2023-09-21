using GameZone.Data;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ApplicationDbContext _context;

        public DeviceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            try
            {
                await _context.AddAsync(device);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task DeleteDevice(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException("id is invalid");
            }
            try
            {
                var device = await GetDeviceById(id);
                _context.Remove(device);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public List<SelectListItem> DeviceSelectList()
        {
            try
            {
                var devices = _context.TbDevices
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .OrderBy(n => n.Text)
                    .AsNoTracking()
                    .ToList();
                return devices;
            }
            catch { throw new InvalidOperationException(); }
        }

        public async Task EditDevice(Device device)
        {
            try
            {
                _context.Entry(device).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Device> GetDeviceById(int id)
        {
            try
            {
                var device = await  _context.TbDevices.FindAsync(id);
                return device;
            }
            catch
            (Exception ex)
            {
               throw new Exception(ex.Message);
            }

        }
        public async Task<List<Device>> GetDevices()
        {
            try
            {
                return await _context.TbDevices.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
