using System.IO;  

namespace LD
{
    public static class DirectoryUtility
    {
        public static void CreateDirectory(string path)
        {
            path = path.ConvertToUnityPath();
            Directory.CreateDirectory(path);
        }

        public static DirectoryInfo GetDirectory(string path, bool notExistCreate = false)
        {
            path = path.ConvertToUnityPath();
            if (notExistCreate && !Directory.Exists(path)) 
                Directory.CreateDirectory(path); 
            return new DirectoryInfo(path);
        } 
    }
}