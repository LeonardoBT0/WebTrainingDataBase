using AutoMapper;

namespace WebTrainingDataBase.Infrestructura
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            //Aqui se va a crear el mapeo

        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<WebProfile>();
            });
        }
    }
}