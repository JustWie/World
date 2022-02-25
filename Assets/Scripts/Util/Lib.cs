using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace World
{
    public class Lib
    {
        static string fileUrl = Application.streamingAssetsPath + "\\property.json";

        public static void Load()
        {
            string fileText;
            using (StreamReader sr = File.OpenText(fileUrl))
            {
                fileText = sr.ReadToEnd();
                sr.Close();
            }
            var datas = Propertys.StringToDatas(fileText);
            Singleton<PlayerData>.ins.Load(datas);
            Singleton<BossData>.ins.Load(datas);
            Singleton<BagData>.ins.Load(datas);
        }

        public static void Save()
        {
            string datas = Propertys.DatasToString();
            using (StreamWriter sw = new StreamWriter(fileUrl))
            {
                sw.Write(datas);
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
