
using EcoTech.Domain.Entities;
using EcoTech.Domain.FeatureEntities;

namespace EcoTech.Application.FeaturesHandler.Users;

public class VerifyOtpHandler : IRequestHandler<VerifyOtpRequestDto, Response<VerifyOtpResponseDto>>
{

    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public VerifyOtpHandler(IAuthService authService,IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }
    public async ValueTask<Response<VerifyOtpResponseDto>> Handle(VerifyOtpRequestDto request, CancellationToken cancellationToken)
    {
        string jwtToken=string.Empty;
        OtpSpResponse response = await _userRepository.ManageOtp(request.Contact, request.Otp, SpConstants.Verify);


        if (request.Purpose.Equals(AppConstants.Verification))
        {
            return new(new(response.Result, response.Message));
        }
        else if (response.Result && request.Purpose.Equals(AppConstants.Login))
        {

            jwtToken= _authService.CreateJwtToken(20, [AppConstants.EncryptedGroupAdminRole, AppConstants.EncryptedUserRole]);

           // return (new(new(false,string.Empty),message:AppConstants.OtpInvalidMessage,isSuccess:false));
        }
        return new(new(true, jwtToken));
    }


}


