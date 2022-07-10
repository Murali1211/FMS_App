using FMS_App.Interfaces;

namespace FMS_App.Services
{
    public class FileUploadLocalService : IUploadFile
    {
        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
        public bool SearchText(string file_Name, string inputText)
        {
            string directory = @"D:\files";
            string fileName = file_Name + ".txt";
            string filePath = Path.Combine(directory, fileName);
            string data = File.ReadAllText(filePath);
            string[] words = data.Split(' ');
            bool wordMatched = false;
            foreach (var str in words)
            {
                if (inputText == str)
                {
                    wordMatched = true;
                    break;
                }                
            }           
            return wordMatched;
        }
    }
}
