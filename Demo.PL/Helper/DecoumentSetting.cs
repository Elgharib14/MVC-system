namespace Demo.PL.Helper
{
    public static class DecoumentSetting
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            string FolderPath =Path.Combine( Directory.GetCurrentDirectory(), "wwwroot" , folderName);

            string FileName = $"{Guid.NewGuid()}{file.FileName}"; 

            string filePath = Path.Combine(FolderPath,FileName);    

           using var fs = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fs);

            return FileName;
            
        }

        public static void DeledFile(string FileName , string folderName)
        {
            if(FileName is not null && folderName is not null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            
        }
    }
}
