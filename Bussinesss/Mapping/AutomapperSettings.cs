using AutoMapper;
using Bussinesss.Mapping;
using DataAccess;
using System;
using System.Data;
using System.Linq;

namespace Bussiness.Mapping
{
    public class AutomapperSettings
    {
        public IMapper mapper;
        public AutomapperSettings()
        {
            mapper = new Mapper(GetAutomapperConfig());
        }
        private IConfigurationProvider GetAutomapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<double, int>().ConvertUsing(new DoubleToIntTypeConverter());
                cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());

                cfg.CreateMap<DataAccess.DBEntities.Columns, Parameters.ColumnsDto>()
                    .ForMember(d => d.ClassTypeBussiness, opt => opt.MapFrom(o => ByName(o.ComboClass + "Dto")))
                    .ForMember(d => d.ClassTypeDataBase, opt => opt.MapFrom(o => ByName(o.ComboClass)))
                    .ForMember(d => d.ClassTypeBussinessList, opt => opt.MapFrom(o => ByNameAsList(o.ComboClass + "Dto")))
                    .ForMember(d => d.ClassTypeDataBaseList, opt => opt.MapFrom(o => ByNameAsList(o.ComboClass)))
                    .ForMember(d => d.ComboDisplayMember, opt => opt.MapFrom(o => o.ComboDisplay))
                    .ForMember(d => d.ComboValueMember, opt => opt.MapFrom(o => o.ComboValue))
                    //.ForMember(d => d.ComboDisplayMember, opt => opt.MapFrom(o => "Name"))
                    //.ForMember(d => d.ComboValueMember, opt => opt.MapFrom(o => "ID"))
                ;


                cfg.CreateMap<DataAccess.DBEntities.Tables, Parameters.TablesDto>()
                    .ForMember(d => d.ClassTypeBussiness, opt => opt.MapFrom(o => ByName(o.Name + "Dto")))
                    .ForMember(d => d.ClassTypeDataBase, opt => opt.MapFrom(o => ByName(o.Name)))
                    .ForMember(d => d.ClassTypeBussinessList, opt => opt.MapFrom(o => ByNameAsList(o.Name + "Dto")))
                    .ForMember(d => d.ClassTypeDataBaseList, opt => opt.MapFrom(o => ByNameAsList(o.Name)))
                ;

                cfg.CreateMap<DataAccess.DBEntities.TestingInput, BussinesEntities.TestingInputDto>()

                ;
                cfg.CreateMap<BussinesEntities.TestingInputDto, DataAccess.DBEntities.TestingInput>()
                    .ForMember(d => d.InsertedDate, opt => opt.MapFrom(o => o.ID == 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.InsertedUser, opt => opt.MapFrom(o => o.ID == 0 ? Environment.UserName : o.InsertedUser))
                    //.ForMember(d => d.LastUpdateDate, opt => opt.MapFrom(o => o.ID != 0 ? DateTime.Now : o.InsertedDate))
                    //.ForMember(d => d.LastUpdateUser, opt => opt.MapFrom(o => o.ID != 0 ? Environment.UserName : o.LastUpdateUser))
                ;
                cfg.CreateMap<DataAccess.DBEntities.Campaigns, BussinesEntities.CampaignsDto>()

                ;
                cfg.CreateMap<BussinesEntities.CampaignsDto, DataAccess.DBEntities.Campaigns>()
                    .ForMember(d => d.InsertedDate, opt => opt.MapFrom(o => o.ID == 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.InsertedUser, opt => opt.MapFrom(o => o.ID == 0 ? Environment.UserName : o.InsertedUser))
                    .ForMember(d => d.LastUpdateDate, opt => opt.MapFrom(o => o.ID != 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.LastUpdateUser, opt => opt.MapFrom(o => o.ID != 0 ? Environment.UserName : o.LastUpdateUser))
                    ;

               
                cfg.CreateMap<DataAccess.DBEntities.CampaignType, BussinesEntities.CampaignTypeDto>()
                ;
                cfg.CreateMap<BussinesEntities.CampaignTypeDto, DataAccess.DBEntities.CampaignType>()
                ;
                cfg.CreateMap<DataAccess.DBEntities.CampaignWaves, BussinesEntities.CampaignWavesDto>()
                ;
                cfg.CreateMap<BussinesEntities.CampaignWavesDto, DataAccess.DBEntities.CampaignWaves>()
                ;
                cfg.CreateMap<DataAccess.DBEntities.CampaignPool, BussinesEntities.CampaignPoolDto>()
                    //.ForMember(d => d.CampaignId, opt => opt.MapFrom(o => Helper.HelpingMethod.campaignID))
                    //.ForMember(d => d.WaveId, opt => opt.MapFrom(o => Helper.HelpingMethod.waveID))
                    //.ForMember(d => d.ReferenceId, opt => opt.MapFrom(o => Helper.HelpingMethod.ReferenceId))
                    //.ForMember(d => d.ActiveFlag, opt => opt.MapFrom(o => Helper.HelpingMethod.ActiveFlag))
                    .ForMember(d => d.InsertedDate, opt => opt.MapFrom(o => o.ID == 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.InsertedUser, opt => opt.MapFrom(o => o.ID == 0 ? Environment.UserName : o.InsertedUser))
                    .ForMember(d => d.LastUpdateDate, opt => opt.MapFrom(o => o.ID != 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.LastUpdateUser, opt => opt.MapFrom(o => o.ID != 0 ? Environment.UserName : o.LastUpdateUser))
                ;
                cfg.CreateMap<BussinesEntities.CampaignPoolDto, DataAccess.DBEntities.CampaignPool>()
                //.ForMember(d => d.CampaignId, opt => opt.MapFrom(o => Helper.HelpingMethod.campaignID))
                //.ForMember(d => d.WaveId, opt => opt.MapFrom(o => Helper.HelpingMethod.waveID))
                //.ForMember(d => d.ReferenceId, opt => opt.MapFrom(o => Helper.HelpingMethod.ReferenceId))
                //.ForMember(d => d.ActiveFlag, opt => opt.MapFrom(o => Helper.HelpingMethod.ActiveFlag))
                    .ForMember(d => d.InsertedDate, opt => opt.MapFrom(o => o.ID == 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.InsertedUser, opt => opt.MapFrom(o => o.ID == 0 ? Environment.UserName : o.InsertedUser))
                    .ForMember(d => d.LastUpdateDate, opt => opt.MapFrom(o => o.ID != 0 ? DateTime.Now : o.InsertedDate))
                    .ForMember(d => d.LastUpdateUser, opt => opt.MapFrom(o => o.ID != 0 ? Environment.UserName : o.LastUpdateUser))
                ;
                cfg.CreateMap<Object, BussinesEntities.CampaignPoolDto>()
                    //.ForMember(d => d.CampaignId, opt => opt.MapFrom(o => Bussiness.Helper.HelpingMethod.campaignID))
                    //.ForMember(d => d.WaveId, opt => opt.MapFrom(o => Bussiness.Helper.HelpingMethod.waveID))
                    .ForMember(d => d.ReferenceId, opt => opt.MapFrom(o => ((System.Data.Common.DbDataRecord)o)["ReferenceId"]))
                    .ForMember(d => d.ActiveFlag, opt => opt.MapFrom(o => true))
                    .ForMember(d => d.InsertedDate, opt => opt.MapFrom(o => DateTime.Now))
                    .ForMember(d => d.InsertedUser, opt => opt.MapFrom(o => Environment.UserName))
                ;
                //cfg.CreateMap<System.Data.DataRow, BussinesEntities.CampaignPoolDto>()
                //    .ForMember(d => d.InsertedDate, opt => opt.MapFrom(o => DateTime.Now))
                //    .ForMember(d => d.InsertedUser, opt => opt.MapFrom(o => Environment.UserName))
                //    .ForMember(d => d.ReferenceId, opt => opt.MapFrom(o => o.ItemArray[0].ToString()))
                //;


                //cfg.CreateMap<System.Data.DataRow, BussinesEntities.CampaignPoolDto>()
                //   .ConstructUsing(x => new Mapping.AutoMapperExtension(x.CampaignId));








            });
            
        }

        private static Type ByName(string name)
        {
            return
                AppDomain.CurrentDomain.GetAssemblies()
                    .Reverse()
                    .Select(assembly => assembly.GetType(name))
                    .FirstOrDefault(t => t != null)
                // Safely delete the following part
                // if you do not want fall back to first partial result
                ??
                AppDomain.CurrentDomain.GetAssemblies()
                    .Reverse()
                    .SelectMany(assembly => assembly.GetTypes())
                    .FirstOrDefault(t => t.Name.Contains(name));
        }
        private static Type ByNameAsList(string name)
        {
            Type listType = Type.GetType("System.Collections.Generic.List`1");
            Type elementType = listType.MakeGenericType(new[] { ByName(name) });
            return elementType;
        }

    }



    //    public class MapperConfig
    //    {
    //        public static Mapper InitializeAutomapper()
    //        {
    //            var config = new MapperConfiguration(cfg =>
    //            {

    //                cfg.CreateMap<System.Data.DataRow, BussinesEntities.CampaignPoolDto>()
    //                   .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => GetDto()))
    //                   ;




    //            });
    //            var mapper = new Mapper(config);
    //            return mapper;

    //        }
    //    }
    //    public static BussinesEntities.CampaignPoolDto GetDto (BussinesEntities.CampaignPoolDto campaignPoolDto)
    //    {
    //        BussinesEntities.CampaignPoolDto campaignPoolDto1 = new BussinesEntities.CampaignPoolDto();
    //        return campaignPoolDto1;
    //    }
    //}



}

