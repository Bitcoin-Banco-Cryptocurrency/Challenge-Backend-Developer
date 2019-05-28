using AutoMapper;
using BitCoinChallange.Domain.Kernel.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoinChallange.Infra.CrossCutting.MapperConfigs
{
	public class Mapping : ICustomMapper
	{
		private IMapper _map = CustomMapper.Mapper;

		public IMapper Custom
		{
			get { return _map; }
			set { _map = value; }
		}
	}
	public static class CustomMapper
	{
		private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = AutoMapperConfig.RegisterMappings();
			var mapper = config.CreateMapper();
			return mapper;
		});
		public static IMapper Mapper => Lazy.Value;
	}
}
