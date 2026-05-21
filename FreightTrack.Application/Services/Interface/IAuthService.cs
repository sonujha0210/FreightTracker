using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.DTO.Response;


namespace FreightTrack.Application.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
