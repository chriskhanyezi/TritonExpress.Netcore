using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.DAL.Entities;
using TritonExpress.Models.ViewModels;

namespace TritonExpress.Logic.Http
{
    public class DataHttpClient : IDataHttpClient
    {
        private readonly HttpClient _httpClient;
        private Uri baseUri = new Uri("https://localhost:5001/");

        public DataHttpClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<VehicleViewModel> GetVehicle(int VehicleID)
        {
            var result = await _httpClient.GetAsync(baseUri + "Vehicle/GetVehicle?VehicleID="+ VehicleID).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                var resultObjAsString = result.Content.ReadAsStringAsync();

                var item = JsonConvert.DeserializeObject<VehicleViewModel>(resultObjAsString.Result);

                return item;
            }

            return null;
        }
        public async Task<IEnumerable<VehicleViewModel>> SearchVehicle(VehicleViewModel vehicle)
        {
            var _vehicle = new Vehicle
            {
                LicensePlateNumber = vehicle.LicensePlateNumber,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Type = vehicle.Type
            };

            string obj = JsonConvert.SerializeObject(_vehicle);

            var result = await _httpClient.PostAsync(baseUri + "Vehicle/SearchVehicle", new StringContent(obj, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                var resultObjAsString = result.Content.ReadAsStringAsync();

                var items = JsonConvert.DeserializeObject<IEnumerable<VehicleViewModel>>(resultObjAsString.Result);

                return items;
            }

            return null;
        }
        public async Task<bool> AddVehicle(VehicleViewModel vehicle)
        {
            var _vehicle = new Vehicle 
            {
                LicensePlateNumber = vehicle.LicensePlateNumber,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Type = vehicle.Type
            };

            string obj = JsonConvert.SerializeObject(_vehicle);

            await _httpClient.PostAsync(baseUri + "Vehicle/AddVehicle", new StringContent(obj, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            return true;
        }

        public async Task<bool> UpdateVehicle(VehicleViewModel vehicle)
        {
            var _vehicle = new Vehicle
            {
                Id = vehicle.Id,
                LicensePlateNumber = vehicle.LicensePlateNumber,
                Model = vehicle.Model,
                Make = vehicle.Make,
                Type = vehicle.Type
            };

            string obj = JsonConvert.SerializeObject(_vehicle);

            await _httpClient.PostAsync(baseUri + "Vehicle/UpdateVehicle", new StringContent(obj, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            return true;
        }

        public async Task<bool> AddWayBill(WayBillViewModel model)
        {
            string obj = JsonConvert.SerializeObject(model);

            await _httpClient.PostAsync(baseUri + "WayBill/AddWayBill", new StringContent(obj, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            return true;
        }

        public async Task<IEnumerable<WayBill>> ViewWayBills(int VehicleID)
        {
            var result = await _httpClient.GetAsync(baseUri + "WayBill/GetWayBillsAssigned?VehicleID=" + VehicleID).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                var resultObjAsString = result.Content.ReadAsStringAsync();

                var item = JsonConvert.DeserializeObject<IEnumerable<WayBill>>(resultObjAsString.Result);

                return item;
            }

            return null;
        }

        public async Task<WayBillViewModel> GetWayBill(int WayBillID)
        {
            var result = await _httpClient.GetAsync(baseUri + "WayBill/GetWayBill?WayBillID=" + WayBillID).ConfigureAwait(false);

            if (result.IsSuccessStatusCode)
            {
                var resultObjAsString = result.Content.ReadAsStringAsync();

                var item = JsonConvert.DeserializeObject<WayBillViewModel>(resultObjAsString.Result);

                return item;
            }

            return null;
        }

        public async Task<bool> UpdateWayBill(WayBillViewModel model)
        {
            string obj = JsonConvert.SerializeObject(model);

            await _httpClient.PostAsync(baseUri + "WayBill/UpdateWayBill", new StringContent(obj, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            return true;
        }
    }

    public interface IDataHttpClient
    {
        Task<bool> AddVehicle(VehicleViewModel vehicle);
        Task<IEnumerable<VehicleViewModel>> SearchVehicle(VehicleViewModel vehicle);
        Task<VehicleViewModel> GetVehicle(int VehicleID);
        Task<bool> UpdateVehicle(VehicleViewModel vehicle);
        Task<bool> AddWayBill(WayBillViewModel model);
        Task<IEnumerable<WayBill>> ViewWayBills(int VehicleID);
        Task<WayBillViewModel> GetWayBill(int WayBillID);
        Task<bool> UpdateWayBill(WayBillViewModel model);
    }
}
