

using EcoTech.Application.Integrations;
using EcoTech.Domain.FeatureEntities;
using EcoTech.Domain.RepositoryContracts;

namespace EcoTech.Application.FeaturesHandler.Users;

public class SendOtpHandler : IRequestHandler<OtpRequestDto, Response<OtpResponseDto>>
{

    private readonly IUserRepository _otpRepository;

    public SendOtpHandler(IUserRepository otpRepository)
    {
        _otpRepository = otpRepository;
    }
    public async ValueTask<Response<OtpResponseDto>> Handle(OtpRequestDto request, CancellationToken cancellationToken)
    {
       
        string otp=Convert.ToString(Random.Shared.Next(10000,99999));
        OtpSpResponse response=await _otpRepository.ManageOtp(request.Contact,otp,SpConstants.Sent);
        string tempJwtToken=string.Empty;
        if (response.Result)
        {
          return (new(new(response.Result, response.Message)));
        }
        return new(new(response.Result, response.Message),isSuccess: response.Result, message:AppConstants.OtpGenerationFailed);
    }
   
 
}


