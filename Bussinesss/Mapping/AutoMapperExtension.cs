using System.Collections.Generic;
using System.Data;

namespace Bussiness.Mapping
{
    public static class AutoMapperExtension
    {

        public static List<T> ReadData<T>(DataTable dt)
        {
            AutomapperSettings mapper = new AutomapperSettings();
            return mapper.mapper.Map<IDataReader, List<T>>(dt.CreateDataReader());

            //return Mapper.DynamicMap<IDataReader, List<T>>(dt.CreateDataReader());
        }
        //static MapperConfiguration GetMapperConfiguration() 
        //{
        //    return new MapperConfiguration(cfg =>
        //        cfg.CreateMap<System.Data.DataRow, BussinesEntities.CampaignPoolDto>()
        //            .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => src.WaveId)));
        //}



    }   
}
