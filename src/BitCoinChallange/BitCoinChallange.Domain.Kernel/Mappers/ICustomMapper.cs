using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitCoinChallange.Domain.Kernel.Mappers
{
	public interface ICustomMapper
	{
		IMapper Custom { get; set; }
	}
}
