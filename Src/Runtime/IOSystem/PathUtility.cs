 
using System.IO; 
using UnityEngine;

namespace LD
{
   
    public static class PathUtility 
    {

        /// <summary>
        /// 유니티 경로인지 확인 
        /// </summary> 
        public static bool IsAbolustePath(this string path)
        {
            return Path.IsPathRooted(path);
        }
        
        /// <summary>
        /// 유니티 경로로 변경
        /// </summary>
        /// <param name="validTargetPath">절대 경로 혹은 확인하고 싶은 경로 (절대경로가 아니어도 됨)</param>
        /// <returns></returns>
        public static string ConvertToUnityPath(this string validTargetPath)
        {
            if (IsAbolustePath(validTargetPath))
            {
                var projectPath = Application.dataPath; 
                var relativePath = validTargetPath.Substring(projectPath.Length); 
                var result =  relativePath.Replace("\\", "/"); 
                return "Assets/" + result;
            }

            if (validTargetPath.StartsWith("Assets"))
            {
                return validTargetPath;
            }
            else
            {
                return "Assets/" + validTargetPath.Replace("\\", "/"); 
            } 
        } 
    }
}
