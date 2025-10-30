using UnityEngine;

public class Shielder : MonoBehaviour
{
    [SerializeField] GameObject player;

    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        if (playerMovement.Shield == 0)
        {
            playerMovement.Shield += 3;
        }
        Debug.Log(playerMovement.Shield);
    }
}
