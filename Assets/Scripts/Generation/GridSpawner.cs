using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    private GridTemplates temps;
    
    void Start()
    {
        Invoke("Spawn",3f);
    }

    void Spawn()
    {
        temps = GameObject.FindGameObjectWithTag("Grids").GetComponent<GridTemplates>();

        bool trueOrFalse = (Random.value > 0.5);

        int rand;
        
        if (gameObject.transform.name.Contains("T")&&!gameObject.transform.name.Contains("R")&&!gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("L"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsT.Length);
                var grd = Instantiate(temps.normalGridsT[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }
       else if (gameObject.transform.name.Contains("R")&&!gameObject.transform.name.Contains("T")&&!gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("B"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsR.Length);
                var grd = Instantiate(temps.normalGridsR[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("T")&&!gameObject.transform.name.Contains("R"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsB.Length);
                var grd = Instantiate(temps.normalGridsB[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("T")&&!gameObject.transform.name.Contains("R")&&!gameObject.transform.name.Contains("B"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsL.Length);
                var grd = Instantiate(temps.normalGridsL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("T")&&gameObject.transform.name.Contains("R")&&!gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("L"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsTR.Length);
                var grd = Instantiate(temps.normalGridsTR[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("T")&&gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("R"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsTB.Length);
                var grd = Instantiate(temps.normalGridsTB[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("T")&&gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("R"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsTL.Length);
                var grd = Instantiate(temps.normalGridsTL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("R")&&gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("T"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsRB.Length);
                var grd = Instantiate(temps.normalGridsRB[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("R")&&gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("T")&&!gameObject.transform.name.Contains("B"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsRL.Length);
                var grd = Instantiate(temps.normalGridsRL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("B")&&gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("T")&&!gameObject.transform.name.Contains("R"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsBL.Length);
                var grd = Instantiate(temps.normalGridsBL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("T")&&gameObject.transform.name.Contains("R")&&gameObject.transform.name.Contains("B")&&!gameObject.transform.name.Contains("L"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsTRB.Length);
                var grd = Instantiate(temps.normalGridsTRB[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("T")&&gameObject.transform.name.Contains("R")&&gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("B"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsTRL.Length);
                var grd = Instantiate(temps.normalGridsTRL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("T")&&gameObject.transform.name.Contains("B")&&gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("R"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsTBL.Length);
                var grd = Instantiate(temps.normalGridsTBL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }else if (gameObject.transform.name.Contains("R")&&gameObject.transform.name.Contains("B")&&gameObject.transform.name.Contains("L")&&!gameObject.transform.name.Contains("T"))
        {
            if (trueOrFalse)
            {
                rand = Random.Range(0, temps.normalGridsRBL.Length);
                var grd = Instantiate(temps.normalGridsRBL[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
            else
            {
                rand = Random.Range(0, temps.normalGridsA.Length);
                var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
                grd.transform.parent = gameObject.transform;
            }
        }
        else
        {
            rand = Random.Range(0, temps.normalGridsA.Length);
            var grd = Instantiate(temps.normalGridsA[rand], transform.position, Quaternion.identity);
            grd.transform.parent = gameObject.transform;
        }
    }
}
