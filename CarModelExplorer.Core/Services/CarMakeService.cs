using AutoMapper;
using CarModelExplorer.Core.Dtos;
using CarModelExplorer.Core.Interfaces;
using CarModelExplorer.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarModelExplorer.Core.Services
{
    public class CarMakeService : ICarMake
    {
        protected readonly ICarMakeRepo carMakeRepo;
        protected readonly IMapper _mapper;

        public CarMakeService(ICarMakeRepo carMakeRepo, IMapper Mapper)
        {
            this.carMakeRepo = carMakeRepo;
            this._mapper = Mapper;
        }

        public async Task<CarMakeReadDto> GetModels(int modelYear, string make)
        {
            var cars = await carMakeRepo.GetModels(make);

            if (cars==null)
            {
                throw new Exception($"this make not exists");
            }
            var models =await GetModelsForMakeIdYear(cars.MakeId, modelYear);
            
             CarMakeReadDto carModels = new CarMakeReadDto() { Models = models.Results.MakeModels.Select(x => x.Model_Name).ToList() };



            return carModels;
        }

        public async Task<ApiResponse> GetModelsForMakeIdYear(int makeId,int modelYear)
        {
            string apiUrl = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{modelYear}";
            ApiResponse apiResponse=new ApiResponse();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Stream stream = await response.Content.ReadAsStreamAsync();
                        XmlSerializer serializer = new XmlSerializer(typeof(ApiResponse));

                        apiResponse = (ApiResponse)serializer.Deserialize(stream);

                    }
                    else
                    {

                        throw new Exception($"API call failed with status code {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
            return apiResponse;
        }
    }
}
