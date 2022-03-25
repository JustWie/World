using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace World
{
    public class Lib
    {
        public static string GetPath(string path)
        {
            return Application.streamingAssetsPath + "\\" + path;
        }

        public static List<string> GetFileNames(string folderUrl)
        {
            List<string> ret = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(folderUrl);
            foreach (FileInfo fileInfo in folder.GetFiles())
            {
                if (fileInfo.Extension == ".json")
                {
                    ret.Add(fileInfo.Name);
                }
            }
            return ret;
        }

        public static string ReadFile(string fileUrl)
        {
            string fileText;
            using (StreamReader sr = File.OpenText(fileUrl))
            {
                fileText = sr.ReadToEnd();
                sr.Close();
            }
            return fileText;
        }

        public static void WriteFile(string fileUrl, string data)
        {
            using (StreamWriter sw = new StreamWriter(fileUrl))
            {
                sw.Write(data);
                sw.Close();
                sw.Dispose();
            }
        }

        public static bool Odds(float odds)
        {
            var number = Random.Range(0, 100);
            if (number < odds)
                return true;
            return false;
        }

        public static GameObject CreateGameObject(string path)
        {
            var obj = Object.Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
            return obj;
        }

        public static Sprite CreateSprite(string name)
        {
            Texture2D texture = Resources.Load(string.Format("Images/{0}", name)) as Texture2D;
            int width = texture ? texture.width : 0;
            int height = texture ? texture.height : 0;
            var sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0, 0));
            return sprite;
        }

        public static IEnumerator CallWithDelay(float delay, System.Action call)
        {
            yield return new WaitForSeconds(delay);
            call();
        }
    }
}
