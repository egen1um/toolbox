using System.IO;
using UnityEngine;

public class Tools
{
    public static Texture2D LoadImageToTexture(string filePath, bool compress = false)
    {
        Texture2D tex = null;

        if (File.Exists(filePath))
        {
            var fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            if (compress)
                tex.Compress(false);
        }

        return tex;
    }
}