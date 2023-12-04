namespace Demo.Interfaces
{
    public interface IApiKeyValidationService
    {
        bool IsValidApiKey(string userApiKey);
    }
}