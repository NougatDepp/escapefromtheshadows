using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    
    public void SetVolume(float v)
    {
        UnityEngine.PlayerPrefs.SetFloat("volume",v);
    }
    
    public void SetDiff(int v)
    {
        UnityEngine.PlayerPrefs.SetInt("diff",v);
    }
    
    public void SetLives(int v)
    {
        UnityEngine.PlayerPrefs.SetInt("lives",v);
    }
    
    
}
