
using EcoTech.Domain.UtilityEntities;

namespace EcoTech.Domain.AppSetup;

public enum StringConstants
{
    
}

public static class DomainAppConstants
{
   

    #region DBConstants
   
    public static Type[] SpRequestModelTypeArray { get; } = [typeof(OtpSpRequest),typeof(SignUpSpRequest),
    typeof(LogErrorsSpRequest),typeof(AvailableUserSpRequest)];
    public enum SpRequest
    {
        OtpSpRequest, SignUpSpRequest, LogErrorsSpRequest, AvailableUserSpRequest
    }
    public static Type[] SpResponseModelTypeArray { get; } = [typeof(SkipResponse),typeof(OtpSpResponse),
    typeof(SignUpSpResponse),typeof(AvailableUserSpResponse)];
    public enum SpResponse
    {
        SkipResponse, OtpSpResponse, SignUpSpResponse, AvailableUserSpResponse
    }
    public static Type SpRequestEnumType { get; } = typeof(SpRequest);
    public static Type SpResponseEnumType { get; } = typeof(SpResponse);
    #endregion


}
