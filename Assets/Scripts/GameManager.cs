using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;
    
    public static List<Vector3> doorsList;
    //public static List<GameObject> secret;

    public int pesos;
    public int experience;
    
    public bool secretBool = false;

    private void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += LoadState;
    }



    public void Update()
    {
        GameObject[] secret = GameObject.FindGameObjectsWithTag("SecretRoom");
        
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");

        if (rooms.Length >= 15)
        {
            GameObject[] sps = GameObject.FindGameObjectsWithTag("SpawnPoint");
            foreach (GameObject sp in sps)
            {
                Destroy(sp);
            }
        }
        
        
        if (GameObject.FindGameObjectsWithTag("SpawnPoint").Length == 0&&!secretBool)
        {
            SecretRoomSpawn(secret[Random.Range(0, secret.Length - 1)]);
            secretBool = true;
        }
    }

    public void SecretRoomSpawn(GameObject secret)
    {
        Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[0],secret.transform.position,
            Quaternion.identity);
    }
    
    
    public void SaveState()
    {
        
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        
        PlayerPrefs.SetString("SaveState",s);
        Debug.Log("SaveState");
    }
    
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;
        
        
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        
        Debug.Log("LoadState");
    }
    
}
