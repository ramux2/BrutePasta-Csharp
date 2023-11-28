using Microsoft.AspNetCore.Mvc;
using BrutePasta.Models;
using BrutePasta.Data;
using BrutePasta.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using BrutePasta.Interfaces;

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpPost]
    [Route("authenticate")]
    public async Task<ActionResult<Client>> Authenticate(Client clientObj)
    {
        var client = await _clientRepository.GetClientByEmail(clientObj.Email);

        if (client == null)
            return NotFound("Cliente não encontrado");

        if (!PasswordHasher.VerifyPassword(clientObj.Password, client.Password))
            return BadRequest("Senha Incorreta");

        var token = CreateJwt(client);

        return Ok(new { token });
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<Client>> Register(Client clientObj)
    {
        if (!Client.IsCpf(clientObj.Cpf))
            return BadRequest("CPF inválido!");

        var email = await _clientRepository.GetClientByEmail(clientObj.Email);
        var cpf = await _clientRepository.GetClientByCpf(clientObj.Cpf);

        if (email != null)
            return BadRequest("Email ja cadastrado");

        if (cpf != null)
            return BadRequest("CPF Ja cadastrado");

        clientObj.Password = PasswordHasher.HashPassword(clientObj.Password);

        await _clientRepository.Create(clientObj);

        return Created("Usuario criado", clientObj);
    }

    [HttpGet()]
    [Route("client/{id}")]
    public async Task<ActionResult<Client>> SearchCpf([FromRoute] int id)
    {
        var client = await _clientRepository.GetClientById(id);

        if (client is null)
            return NotFound("Cliente não encontrado");

        return client;
    }

    [HttpPut()]
    [Route("client")]
    public async Task<ActionResult> Change(Client client)
    {
        if (client is null)
            return BadRequest("Dados inválidos");

        _clientRepository.Update(client);

        return Ok();
    }


    [HttpDelete()]
    [Route("client/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var clientTemp = await _clientRepository.GetClientById(id);

        if (clientTemp is null) 
            return NotFound("Cliente não encontrado");

        await _clientRepository.Remove(clientTemp);
        return Ok();
    }

    private string CreateJwt(Client client)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("B4GSg^]]7g~ep7%*3Xob;dqM(Xlcy$");
        var identity = new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.Name, $"{client.Email}")
        });

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var expirationTime = DateTime.Now.AddMinutes(30);
        var notbefore = DateTime.Now;
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = expirationTime,
            NotBefore = notbefore,
            SigningCredentials = credentials
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
    }
}
