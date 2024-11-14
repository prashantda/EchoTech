
using EcoTech.Domain.FeatureEntities;

namespace EcoTech.Application.FeaturesHandler.Users;

public class VerifyOtpHandler : IRequestHandler<VerifyOtpRequestDto, Response<VerifyOtpResponseDto>>
{

    private readonly IAuthService _authService;

    public VerifyOtpHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public ValueTask<Response<VerifyOtpResponseDto>> Handle(VerifyOtpRequestDto request, CancellationToken cancellationToken)
    {
        AppUser appUser = _authService.GetAppUser();
        string tempJwtToken=string.Empty;
        if (appUser.Claims.TryGetValue(JwtRegisteredClaimNames.Sub,out string? encryptedOtp))
        {
             tempJwtToken = request.Otp.Equals(_authService.DecryptString(encryptedOtp))?
                               _authService.CreateJwtToken(20, [AppConstants.EncryptedGroupAdminRole,AppConstants.EncryptedUserRole]):
                               string.Empty;
        }
        if (string.IsNullOrWhiteSpace(tempJwtToken))
        {
            return ValueTask.FromResult<Response<VerifyOtpResponseDto>>(new(
                new(false,string.Empty),message:AppConstants.OtpInvalidMessage,isSuccess:false));
        }
        return ValueTask.FromResult<Response<VerifyOtpResponseDto>>(new(new(true,tempJwtToken)));
    }


}


