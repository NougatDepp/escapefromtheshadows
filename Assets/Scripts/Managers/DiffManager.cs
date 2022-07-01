using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffManager : MonoBehaviour
{
    [SerializeField] Slider diffSlider;
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("diff"))
        {
            PlayerPrefs.SetFloat("diff",1);
            Save();
        }
    }

    public void ChangeDiff()
    {
        Save();
    }
    
    private void Save()
    {
        PlayerPrefs.SetFloat("diff",diffSlider.value);
    }
}
