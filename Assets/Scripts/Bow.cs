using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    
    public float cooldown;
    static float lastShot;
    
    private Transform playerTransform;


    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Start()
    {
        playerTransform = GameManager.instance.player.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = playerTransform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        Vector2 dirVec = new Vector3(direction.magnitude * (1 / mousePosition.magnitude),0,0);
        transform.right = direction.normalized;
        

        anim.SetFloat("Distance",direction.magnitude);

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        
        Vector3 playerSpeed = Vector3.one;
        GameObject newArrow2 = Instantiate(arrow, shotPoint.position, shotPoint.rotation*Quaternion.Euler(0,0f,0));
        newArrow2.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, 0) * transform.right*launchForce; 
        
        /**
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation*Quaternion.Euler(0,0f,30));
        newArrow.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, 30) * transform.right*launchForce + playerSpeed/2; 
        
        GameObject newArrow3 = Instantiate(arrow, shotPoint.position, shotPoint.rotation*Quaternion.Euler(0,0f,-30));
        newArrow3.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, -30) * transform.right*launchForce + playerSpeed/2; **/


        lastShot = Time.time;
    }
    
}
