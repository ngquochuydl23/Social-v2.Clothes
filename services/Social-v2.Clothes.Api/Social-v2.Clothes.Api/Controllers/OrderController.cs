﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Order;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Orders;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<OrderEntity> _orderRepo;

        public OrderController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<OrderEntity> orderRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = UserConstants.AdministratorRole)]
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRepo
                .GetQueryableNoTracking()
                .Where(x => !x.IsDeleted)
                .ToList();

            return Ok(_mapper.Map<ICollection<OrderDto>>(orders));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
