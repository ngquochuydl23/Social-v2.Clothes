using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Stores
{
    public class StockLocationEntity: Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [NotNull]
        public string Id { get; set; }

        [NotNull]
        public string Name { get;set; }

        [NotNull]
        public string Address { get;set; }

        [NotNull]
        [MaxLength(StockLocationConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [NotNull]
        [MaxLength(StockLocationConstants.DetailAddressMaxLength)]
        public string DetailAddress { get; set; }

        [NotNull]
        [MaxLength(StockLocationConstants.ProvinceOrCityMaxLength)]
        public string ProvinceOrCity { get; set; }

        [NotNull]
        [MaxLength(StockLocationConstants.DistrictMaxLength)]
        public string District { get; set; }

        [NotNull]
        [MaxLength(StockLocationConstants.WardOrCommuneMaxLength)]
        public string WardOrCommune { get; set; }
    }
}
