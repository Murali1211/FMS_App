namespace FMS_App.Interfaces
{
    public interface IUploadFile
    {
        Task<bool> UploadFile(IFormFile file);
        bool SearchText(string fileName, string inputText);
    }
}
