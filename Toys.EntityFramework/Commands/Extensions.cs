using Toys.Domain.Models;
using Toys.EntityFramework.DTOs;

namespace Toys.EntityFramework.Extensions
{
    public static class Extensions
    {
        public static ToyDto ToToyDto(this Toy toy) =>
            new ToyDto()
            {
                Id = toy.Id,
                Description = toy.Description,
                Name = toy.Name,
                Size = toy.Size,
                IsValid = toy.IsValid,
            };

        public static Toy ToToy(this ToyDto toyDto) => 
            new Toy(toyDto.Id, toyDto.Name, toyDto.Description, toyDto.Size, toyDto.IsValid);

    }
}
