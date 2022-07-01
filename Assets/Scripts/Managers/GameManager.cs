using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GridTemplates temps;

    public Player player;
    
    public static List<Vector3> doorsList;

    public int pesos;
    public int experience;
    
    GameObject[] secret;
    

    public float t;
    public float r;
    public float b;
    public float l;
    

    public Vector3 Checkpoint;
    public bool moving = false;

    
    
    private void Start()
    {
        t = Random.Range(0.0f,0.8f);
        r = Random.Range(0.0f,0.8f);
        b = 1-t;
        l = 1-r;
        
        Invoke("SpawnEnd",2f);
    }

    private void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += LoadState;
    }

    public void SpawnEnd()
    {
        if (GameObject.FindGameObjectsWithTag("Room").Length < 8) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        GameObject[] special = GameObject.FindGameObjectsWithTag("SpecialRoom");

        int i = Random.Range(0, special.Length - 1);

        GameObject[] secret = GameObject.FindGameObjectsWithTag("Secret");

        if (secret.Length > 0)
        {
            SpecialRoomSpawn(secret[Random.Range(0, secret.Length - 1)]);
        }
        else
        {
            SpecialRoomSpawn(special[Random.Range(0, special.Length - 1)]);
        }
            

    }
    public void Update()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");

        if (rooms.Length >= 15)
        {
            GameObject[] sps = GameObject.FindGameObjectsWithTag("SpawnPoint");
            foreach (GameObject sp in sps)
            {
                Destroy(sp);
            }
        }
    }

    public void SpecialRoomSpawn(GameObject secret)
    {
       // Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[1],GameObject.FindGameObjectWithTag("Treasure").transform.position, Quaternion.identity);
       // Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[0],secret.transform.position, Quaternion.identity);
        Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[2],GameObject.FindGameObjectWithTag("Boss").transform.position, Quaternion.identity);
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
