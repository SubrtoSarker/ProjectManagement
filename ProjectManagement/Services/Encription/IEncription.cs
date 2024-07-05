namespace ProjectManagement.Services.Encription
{
    public interface IEncription
    {
        public string EncryptString(string text);
        public string DecryptString(string cipherText);

    }
}
