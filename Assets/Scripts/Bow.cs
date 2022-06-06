using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public float cooldown;
    
    
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

        if (Input.GetMouseButton(0)&&cooldown > 1)
        {
            Shoot();
            cooldown = 0;
        }

        cooldown += 0.05f;
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right *launchForce;

    }
    
}
