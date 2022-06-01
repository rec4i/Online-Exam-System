using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaynak_Kod.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;

namespace Kaynak_Kod.Services
{
    public interface IŞehir_İlçeServices
    {
        Task<List<City>> Get_All_City();
        Task<List<Town>> Get_All_Town();
        Task<List<Town>> Get_By_CityID_Town(City city);

        List<City> Get_By_Word_City(StringRequest Request);
        List<Town> Get_By_Word_Town(StringRequest Request);
    }
    public class Şehir_İlçeServices : IŞehir_İlçeServices
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public Şehir_İlçeServices(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<List<City>> Get_All_City()
        {
            var Temp = await (_context.cityies.Select(o => o).ToListAsync());

            return Temp;
        }

        public async Task<List<Town>> Get_All_Town()
        {
            var Temp = await (_context.towns.Select(o => o).ToListAsync());

            return Temp;
        }
        public async Task<List<Town>> Get_By_CityID_Town(City city)
        {
            var Temp = await (_context.towns.Where(o => o.CityID == city.CityID).ToListAsync());

            return Temp;
        }

        public List<City> Get_By_Word_City(StringRequest Request)
        {
            var Temp_List = _context.cityies.ToList();
            var Şehirler = (from Şehirler_ in Temp_List
                            where Şehirler_.CityName.StartsWith(Request.StringReq, StringComparison.InvariantCultureIgnoreCase)
                            select new { Şehirler_.CityID, Şehirler_.CityName });

            IEnumerable<City> Gönderilecek = Şehirler.Select(o => new City
            {
                CityName = o.CityName,
                CityID = o.CityID
            });

            return Gönderilecek.ToList();
        }
       


        public List<Town> Get_By_Word_Town(StringRequest Request)
        {
            var Temp_List = _context.towns.ToList();
            var Şehirler = (from Şehirler_ in Temp_List
                            where Şehirler_.TownName.StartsWith(Request.StringReq, StringComparison.InvariantCultureIgnoreCase)
                            select new { Şehirler_.TownID, Şehirler_.TownName });

            IEnumerable<Town> Gönderilecek = Şehirler.Select(o => new Town
            {
                TownName = o.TownName,
                TownID = o.TownID
            });

            return Gönderilecek.ToList();
        }



    }
}