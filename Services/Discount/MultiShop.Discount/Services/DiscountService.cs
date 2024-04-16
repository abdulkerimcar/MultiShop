﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
	public class DiscountService : IDiscountService
	{
		private readonly DapperContext _context;

		public DiscountService(DapperContext context)
		{
			_context = context;
		}

		public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
		{
			string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) " +
				"values (@code,@rate,@isActive,@validDate)";
			var patameters = new DynamicParameters();
			patameters.Add("@code", createCouponDto.Code);
			patameters.Add("@rate", createCouponDto.Rate);
			patameters.Add("@isActive", createCouponDto.IsActive);
			patameters.Add("@validDate", createCouponDto.ValidDate);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, patameters);
			}
		}

		public async Task DeleteDiscountCouponAsync(int id)
		{
			string query = "Delete From Coupons where CouponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("couponId", id);
			using(var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
		{
			string query = "Select * From Coupons";
			using(var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
		{
			string query = "Select * From Coupons Where CouponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("@couponId", id);
			using(var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
				return values;
			}
		}

		public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
		{
			string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
			var patameters = new DynamicParameters();
			patameters.Add("@code", updateCouponDto.Code);
			patameters.Add("@rate", updateCouponDto.Rate);
			patameters.Add("@isActive", updateCouponDto.IsActive);
			patameters.Add("@validDate", updateCouponDto.ValidDate);
			patameters.Add("@couponId", updateCouponDto.CouponId);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, patameters);
			}
		}

	}
}
