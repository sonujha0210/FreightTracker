using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.DTO.Response;
using FreightTrack.Application.Interface;
using FreightTrack.Application.Services.Interface;
using FreightTrack.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService : IAuthService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IConfiguration _configuration;

    public AuthService(ICustomerRepository customerRepository, IConfiguration configuration)
    {
        _customerRepository = customerRepository;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existing = await _customerRepository.GetByEmailAsync(dto.Email);
        if (existing != null)
            throw new Exception("Email already registered");

        var customer = new Customer
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = dto.Role ?? "Customer",
            CreatedAt = DateTime.UtcNow
        };

        await _customerRepository.AddAsync(customer);
        return new AuthResponseDto
        {
            Token = GenerateToken(customer),
            Role = customer.Role,
            Name = customer.Name
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var customer = await _customerRepository.GetByEmailAsync(dto.Email);
        if (customer == null || !BCrypt.Net.BCrypt.Verify(dto.Password, customer.PasswordHash))
            throw new Exception("Invalid credentials");

        return new AuthResponseDto
        {
            Token = GenerateToken(customer),
            Role = customer.Role,
            Name = customer.Name
        };
    }

    private string GenerateToken(Customer customer)
    {
        var secretKey = _configuration["JwtSettings:SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, customer.Email),
        new Claim(ClaimTypes.Role, customer.Role)
    };

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(
                int.Parse(_configuration["JwtSettings:ExpiryDays"]!)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}