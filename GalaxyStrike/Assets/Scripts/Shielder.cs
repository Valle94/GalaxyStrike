using UnityEngine;

public class Shielder : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        if (playerMovement.Shield < 3)
        {
            playerMovement.Shield = 3;
        }
        Debug.Log(playerMovement.Shield);
    }
}
