using MicroElectronic.DAL.Interfaces;
using MicroElectronic.Domain.Models;
using MicroElectronic.Domain.Response;
using MicroElectronic.Domain.ViewModels.Equipment;
using MicroElectronic.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroElectronic.Service.Implementations
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IBaseRepository<Equipment> _equipmentRepository;

        public EquipmentService(IBaseRepository<Equipment> equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
    
        public Task<IBaseResponse<Equipment>> Create(EquipmentViewModel equipment)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<IEnumerable<Equipment>>> GetEquipments(int categoryId)
        {
            try
            {
                var equipments = await _equipmentRepository.GetAll()
                    .Where(x => x.CategoryId == categoryId).ToListAsync();

                return new BaseResponse<IEnumerable<Equipment>>()
                {
                    Data = equipments,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Equipment>>()
                {
                    Description = $"[GetEquipments]: {ex.Message}",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<EquipmentViewModel>> GetEquipment(int id)
        {
            try
            {
                var equipment = await _equipmentRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if(equipment == null)
                {
                    return new BaseResponse<EquipmentViewModel>()
                    {
                        Description = "Оборудование не найдено",
                        StatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }

                var data = new EquipmentViewModel()
                {
                    Id = equipment.Id,
                    Name = equipment.Name,
                    Description = equipment.Description,
                    Price = equipment.Price,
                    Size = equipment.Size,
                    BodyMaterial = equipment.BodyMaterial,
                    WorkingArea = equipment.WorkingArea,
                    Power = equipment.Power,
                    GuaranteePeriod = equipment.GuaranteePeriod,
                    FullDescription = equipment.FullDescription,
                    ImageUrl = equipment.ImageUrl
                };

                return new BaseResponse<EquipmentViewModel>()
                {
                    Data = data,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<EquipmentViewModel>
                {
                    Description = $"[GetEquipment]: {ex.Message}",
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<Equipment>> Update(int id, EquipmentViewModel equipment)
        {
            throw new NotImplementedException();
        }
    }
}
