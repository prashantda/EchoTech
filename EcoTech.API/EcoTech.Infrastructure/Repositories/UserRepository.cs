using EcoTech.Domain.Entities;
using EcoTech.Shared.Constants;
using EcoTech.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoTech.Infrastructure.Repositories;

internal class UserRepository : GenericRepository, IUserRepository
{
    public UserRepository(IApplicationManager applicationManager) : base(applicationManager)
    { }

    public async ValueTask<AvailableUserSpResponse> CheckUserAvailability(AvailableUserSpRequest spRequest)
    {
        DomainAppConstants.SpResponse[] returnObjects = [DomainAppConstants.SpResponse.AvailableUserSpResponse];
        var response = await ExecuteSpToObjects(SpConstants.USP_Check_User_Availability, returnObjects: returnObjects, spEntity: spRequest);
        return (AvailableUserSpResponse)response[1][0];
    }

    public async ValueTask<OtpSpResponse> ManageOtp(string contact, string otp, string operation)
    {
        OtpSpRequest dbRequest = new()
        {
            Contact = contact,
            Otp = otp,
            Operation = operation
        };
        DomainAppConstants.SpResponse[] returnObjects = [DomainAppConstants.SpResponse.OtpSpResponse];
        var response = await ExecuteSpToObjects(SpConstants.USP_Manage_OTP, returnObjects: returnObjects, spEntity: dbRequest);
        return (OtpSpResponse)response[1][0];
    }


    public async ValueTask<SignUpSpResponse> SignUpUser(SignUpSpRequest spRequest)
    {
        DomainAppConstants.SpResponse[] returnObjects = [DomainAppConstants.SpResponse.SignUpSpResponse];
        var response = await ExecuteSpToObjects(SpConstants.USP_Client_SignUp, returnObjects: returnObjects, spEntity: spRequest);
        return (SignUpSpResponse)response[1][0];
    }
}

