namespace ProCeur.API.Shared.Interface
{
    public interface IPasswordSecurityHelper
    {
        string Encrypt(string key, string data);
        string Decrypt(string key, string data);
        string EncryptURL(string key, string data);
        string DecryptURL(string key, string data);
        string CreateRandomPassword();
    }
}
