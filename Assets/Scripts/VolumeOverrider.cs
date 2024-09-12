using System;
using System.IO;
using UnityEngine;


public class VolumeOverrider : MonoBehaviour
{
    //public float actual_volume = 1.0f;
    public double volume_mulitiplier = 1.0;
    private string volumeFileName = "VolumeMultiplier.txt";
    private string errorFileName = "Errors.txt";

    public void Start()
    {
        AdjustSystemVolume();
    }

    public void AdjustSystemVolume()
    {
        try
        {
            StreamReader sr = new StreamReader(volumeFileName);
            if (sr != null)
            {
                double currentVolume = AudioListener.volume;
                volume_mulitiplier = Convert.ToDouble(sr.ReadLine());

                double newVolume = (currentVolume * volume_mulitiplier);
                AudioListener.volume = (float)newVolume;

                string msg = string.Format("Cur Volumne: {0}    New Volume: {1}", currentVolume, newVolume);
                Debug.Log(msg);
            }
            else
            {
                Debug.Log("No volume file");
            }
            sr.Close();
        }
        catch (Exception e)
        {
            LogError(e.Message);
        }
    }

    private void LogError(string msg)
    { 
        try
        {
            StreamWriter sw = new StreamWriter(errorFileName);  // Open file for writing
            msg = "Volume Override Error: " + msg;
            sw.WriteLine(msg);
            sw.Close();  //Close the file
        }
        catch (Exception e)
        {
            Console.WriteLine("Error Reading Volume: " + e.Message);
        }
    }

}

