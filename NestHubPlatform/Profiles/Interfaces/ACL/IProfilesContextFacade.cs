namespace NestHubPlatform.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string name, string fatherName, string motherName, string dateOfBirth,
        string documentNumber, string phone,int userId);
}