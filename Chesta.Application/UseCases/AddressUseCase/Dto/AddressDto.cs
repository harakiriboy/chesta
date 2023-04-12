using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesta.Application.UseCases.AddressUseCase.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Region { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}