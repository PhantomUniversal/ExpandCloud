/*
 * day : 2023-08-23
 * write : phantom
 * email : chho1365@gmail.com
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Phantom
{
    public class PhantomLog : MonoBehaviour
    {
        public static string log = "";

        public static readonly string logPath = Application.persistentDataPath + "/" + "Phantom";

        public static readonly string logFile = "Log.txt";
        
        public static void Write(string message)
        {
            if(string.IsNullOrEmpty(log))
            {
                log = Read();
            }
            
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(logPath));
            if(!directoryInfo.Exists)
            {
                directoryInfo.Create();             
            }

            FileStream fileStream = new FileStream(logPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8);

            if (string.IsNullOrEmpty(log))
            {
                writer.WriteLine(log += "[ Enter : " + DateTime.Now + " ]" + "\n" + DateTime.Now + " : " + message);
            }
            else
            {
                writer.WriteLine(log += "\n" + DateTime.Now + " : " + message);
            }
        
            writer.Close();
        }

        public static string Read()
        {
            FileInfo fileInfo = new FileInfo(logPath);

            var text = "";
            if (fileInfo.Exists)
            {
                StreamReader reader = new StreamReader(logPath);
                var read = reader.ReadToEnd();
                if(!string.IsNullOrEmpty(read))
                {
                    text += read + "\n" + "[ Enter : " + DateTime.Now + " ]";
                }
                reader.Close();            
            }

            return text;
        }
    }   
}