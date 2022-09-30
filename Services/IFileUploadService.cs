namespace EmployeeManagementSystem.Services
{
    public interface IFileUploadService
    {        
        string? FileName { get; set; }
        Task<bool> UploadFile(IFormFile file);
    }

    public class FileUploadService : IFileUploadService
    {
        public string? FileName { get; set; }

        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if(file.Length>0)
                {
                    path=Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/images"));
                    //above statement gets directory path where we will store the image:
                    //Environment.CurrentDirectory gets our project folder
                    //so the full path you get now is: ~/wwwroot/images (~ represents project directory)

                    //in the following statement we do path.combine again to add filename to directory. Eg: ~/wwwroot/images/abc.jpg
                    using (FileStream fileStream=new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        this.FileName = file.FileName;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("File copy failed",ex);
            }
        }
    }
}
