using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
namespace Kaynak_Kod.Services
{
    public interface IEczaneListeOluşturServices
    {
        List<Eczane> Get_Eczane_By_City_Town_Id(List<City> cities,List<Town> towns);
        
    }
    public class EczaneListeOluşturServices :IEczaneListeOluşturServices
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public EczaneListeOluşturServices(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public List<Eczane> Get_Eczane_By_City_Town_Id(List<City> cities, List<Town> towns)
        {

            var Temp_List = _context.eczanes.ToList();
            var Eczaneler = (from Eczaneler_ in Temp_List
                            where cities.Select(o => o.CityID).Contains(Eczaneler_.Şehir) && towns.Select(o => o.TownID).Contains(Eczaneler_.İlçe) && Eczaneler_.Silinmişmi==0
                            select Eczaneler_
                            );

            IEnumerable<Eczane> Gönderilecek = Eczaneler.Select(o => new Eczane
            {
                Id=o.Id,
                Eczane_Adı = o.Eczane_Adı,
                Eczacı_Adı = o.Eczacı_Adı,
                Şehir = o.Şehir,
                İlçe = o.İlçe,
                Adres =o.Adres,
                Telefon=o.Telefon,
                Eposta=o.Eposta,
                Mediporf_Kodu=o.Mediporf_Kodu,
                Brick_500 = o.Brick_500,
                Eczane_Konum_Tipi = o.Eczane_Konum_Tipi,
                GLN_No= o.GLN_No,
            });

            return Gönderilecek.ToList();
        }
    }
}