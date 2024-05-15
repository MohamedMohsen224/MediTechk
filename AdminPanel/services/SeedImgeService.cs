using Core.Models;

namespace AdminPanel.services
{
    public class SeedImgeService 
    {
        public static string UploadImage(IFormFile file, string foldername)
        {
            string Folderpath = Path.Combine("MediTech","wwwroot\\Uploadimage",foldername);
            string filename = $"{Guid.NewGuid()}{file.FileName}";
            string filepath = Path.Combine(Folderpath, filename);
            var FileS = new FileStream(filepath, FileMode.Create);
            file.CopyTo(FileS);
            return filepath;
        }

        public static void DeleteFile(string file, string foldername)
        {
            if (file is not null && foldername is not null)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", foldername, file);
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
            }

        }






    }
}
