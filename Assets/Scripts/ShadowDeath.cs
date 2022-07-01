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
        if (PauseMenu.GameIsPaused == true) return;
        
        if (Physics2D.Raycast(transform.position, (playerTransform.position-transform.position).normalized, vecLength,640))
        {
            
            if (Physics2D.Raycast(transform.position, (playerTransform.position - transform.position).normalized, vecLength,
                                640).collider.name == "Player")
            {
                GameManager.instance.player.hitpoint -= 0.001f;
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
