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
    
    public float darkness = 1f;
    public int hearts = 3;
    public int lives = 3;
    public Vector3 Checkpoint;
    public bool moving = false;

    public bool lastBool = false;

    private void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += LoadState;
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
        
        if (GameObject.FindGameObjectsWithTag("SpawnPoint").Length == 0&&!lastBool)
        {
            GameObject[] special = GameObject.FindGameObjectsWithTag("SpecialRoom");

            int i = Random.Range(0, special.Length - 1);
            
            TreasureRoomSpawn(special[i]);

            GameObject[] secret = GameObject.FindGameObjectsWithTag("Secret");
            
            SecretRoomSpawn(secret[Random.Range(0, secret.Length - 1)]);

            BossRoomSpawn(special[(i+3)%(special.Length-1)]);
            

            temps = GameObject.FindGameObjectWithTag("Grids").GetComponent<GridTemplates>();
            
            foreach (var room in rooms)
            {
                var grid = Instantiate(temps.normalGridsA[Random.Range(0, temps.normalGridsA.Length - 1)], room.transform.position,
                    Quaternion.identity);
                grid.transform.parent = room.gameObject.transform.parent;
            }
            
            lastBool = true;
        }
    }

    public void SecretRoomSpawn(GameObject secret)
    {
        Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[0],secret.transform.position,
            Quaternion.identity);
    }

    public void TreasureRoomSpawn(GameObject treasure)
    {
        Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[1],treasure.transform.position,
            Quaternion.identity);
    }
    
    public void BossRoomSpawn(GameObject boss)
    {
        Instantiate(GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>().specialRooms[2],boss.transform.position,
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
