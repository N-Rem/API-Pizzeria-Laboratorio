﻿using App.Models;
using App.Models.Rrequest;
using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("getAll")]
        public IActionResult getAllUser()
        {
            return Ok(_userServices.GetAll());
        }

        [HttpGet("GetById{id}")]
        public IActionResult getUser(int id) {
        
            return Ok(_userServices.GetById(id));

        }

        [HttpDelete ("DeleteId{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userServices.DeleteUser(id);
            return Ok();
        }
        //crud

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] UserDto user)
        {
            _userServices.CreateUserAdmin(user);
            return Ok();
        }

        [HttpPost("CreateClient")]
        public IActionResult CreateClient([FromBody] UserDto user)
        {
            _userServices.CreateUserClient(user);
            return Ok();
        }


        [HttpPut("IdUserUpdate{id}")]
        public IActionResult UpdateUser([FromRoute] int idUser, [FromBody] UserDto user)
        
        {
            _userServices.UpdateUser(idUser, user);
            return Ok();
        }

        [HttpPost("AddProduct")]
        public IActionResult CreateReservationProduct([FromBody] UserProductCreateRequest dto)
        {
            _userServices.AddToBuy(dto);
            return Ok();
        }

    }
}