using System;
using AutoMapper;
using iknowscore.Services.ViewModels.Maps;

namespace iknowscore.TestX
{
    public class AutoMapperFixture
    {
        /// <summary>
        /// [YK]: Don't remove unused propery. It's really used to initialize AutoMapper
        /// </summary>
        private static readonly Lazy<AutoMapperFixture> AutoMapperCreator = new Lazy<AutoMapperFixture>(delegate
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            return new AutoMapperFixture();
        });

        public AutoMapperFixture()
        {
        }
    }
}
