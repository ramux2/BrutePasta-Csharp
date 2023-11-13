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

namespace BrutePasta.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private BrutePastaDbContext _context;
    private readonly ILogger<ClientController> _logger;
    public ClientController(BrutePastaDbContext context, ILogger<ClientController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    [Route("authenticate")]
    public async Task<ActionResult<Client>> Authenticate(Client clientObj)
    {
        if (clientObj == null)
            return BadRequest();

        var client = await _context.Client.FirstOrDefaultAsync(x => x.Email == clientObj.Email);

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
        if (clientObj == null)
            return BadRequest();

        if (!Client.IsCpf(clientObj.Cpf))
            return BadRequest("CPF inválido!");

        var email = await _context.Client.FirstOrDefaultAsync(x => x.Email == clientObj.Email);
        var cpf = await _context.Client.FirstOrDefaultAsync(x => x.Cpf == clientObj.Cpf);

        if (email != null)
            return BadRequest("Email ja cadastrado");

        if (cpf != null)
            return BadRequest("CPF Ja cadastrado");

        clientObj.Password = PasswordHasher.HashPassword(clientObj.Password);

        await _context.Client.AddAsync(clientObj);
        await _context.SaveChangesAsync();

        return Created("Usuario criado", clientObj);
    }

    [HttpGet()]
    [Route("clients")]
    public async Task<ActionResult<IEnumerable<Client>>> Get()
    {
        if (_context.Client is null)
            return NotFound();
        return await _context.Client.ToListAsync();
    }

    [HttpGet()]
    [Route("client/{id}")]
    public async Task<ActionResult<Client>> SearchCpf([FromRoute] int id)
    {
        if (_context.Client is null)
            return NotFound();
        var client = await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
        if (client is null)
            return NotFound();
        return client;
    }

    [HttpPut()]
    [Route("client")]
    public async Task<ActionResult> Change(Client client)
    {
        if (_context is null)
            return NotFound();

        if (_context.Client is null)
            return NotFound();

        // Carregue o cliente existente do banco de dados com o mesmo CPF
        var existingClient = await _context.Client.AsNoTracking().FirstOrDefaultAsync(x => x.Id == client.Id);

        if (existingClient is null)
            return NotFound();

        if (!Client.IsCpf(existingClient.Cpf))
            return BadRequest("CPF inválido!");

        _context.Entry(client).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return Ok();
    }


    [HttpDelete()]
    [Route("client/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_context is null) 
            return NotFound();

        if (_context.Client is null)
            return NotFound();

        var clientTemp = await _context.Client.FindAsync(id);

        if (clientTemp is null) 
            return NotFound();

        _context.Remove(clientTemp);
        await _context.SaveChangesAsync();
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
