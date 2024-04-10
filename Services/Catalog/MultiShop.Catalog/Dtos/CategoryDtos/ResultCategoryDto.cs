using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Dtos.CategoryDtos
{
	public class ResultCategoryDto
	{
		public string CategoryID { get; set; }
		public string CategoryName { get; set; }
	}
}
