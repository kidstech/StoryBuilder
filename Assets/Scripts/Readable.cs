//Add this on uses;
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class Readable : MonoBehaviour
{
    //Function to speak in default windows voice
    public static void Speak(string texto)
    {
        //create the containing folder
        if (!Directory.Exists("C:/TempSpeak"))
        {
            System.IO.Directory.CreateDirectory("C:/TempSpeak");
            var di = new DirectoryInfo("C:/TempSpeak");
            di.Attributes = FileAttributes.Hidden;
        }

        string Rand = UnityEngine.Random.Range(000000, 999999).ToString("D6");
        //Create Temp.vbs
        String Voice = "C:/TempSpeak/Temp" + Rand + ".vbs";
        AddTextToFile(Voice, "\r\nCreateObject(\"SAPI.Spvoice\").Speak\"" + texto + "\"");
        AddTextToFile(Voice, "Set obj = CreateObject(\"Scripting.FileSystemObject\")");
        AddTextToFile(Voice, "obj.DeleteFile(\"C:\\TempSpeak\\Temp" + Rand + ".vbs\")");
        //     Call the vbs file
        Process scriptProc = new Process();
        scriptProc.StartInfo.FileName = @"cscript";
        //        scriptProc.StartInfo.WorkingDirectory = @"c:\scripts\"; //<---very important
        scriptProc.StartInfo.Arguments = "//B //Nologo " + "C://TempSpeak//Temp" + Rand + ".vbs";
        scriptProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //evita de mostrar a janela de prompt
        scriptProc.Start();
        //Voila
    }

    //Add text to text files
    public static void AddTextToFile(string adress, string value)
    {
        FileStream fs = new FileStream(adress, FileMode.Append, FileAccess.Write, FileShare.Write);
        fs.Close();
        StreamWriter sw = new StreamWriter(adress, true, Encoding.Unicode);
        string NextLine = "\r\n" + value;
        sw.Write(NextLine);
        sw.Close();
    }

}