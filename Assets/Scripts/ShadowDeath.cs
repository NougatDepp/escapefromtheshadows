using UnityEngine;
using Random = UnityEngine.Random;

public class ShadowDeath : MonoBehaviour
{
    public float vecLength = 0;
    private Transform playerTransform;
    
    private void Start()
    {
        playerTransform = playerTransform = FindObjectOfType<GameManager>().player.transform;
    }
    
    void Update()
    {
        if (Physics2D.Raycast(transform.position, (playerTransform.position-transform.position).normalized, vecLength,768))
        {
            
            if (Physics2D.Raycast(transform.position, (playerTransform.position - transform.position).normalized, vecLength,
                                768).collider.name == "Player")
            {
                Player.darkness -= 0.013f;
                Camera.main.transform.position = Camera.main.transform.position + Random.onUnitSphere/300;
            }

            
            Debug.DrawRay(transform.position, (playerTransform.position-transform.position).normalized*vecLength, Color.yellow);
            
        }
        else
        {
            Debug.DrawRay(transform.position, (playerTransform.position-transform.position).normalized * vecLength, Color.white, 0);
            
        }
    }
}
