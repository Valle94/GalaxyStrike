using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDestroyVFX;

    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerMovement.Shield <= 0)
        {
            Instantiate(playerDestroyVFX, gameObject.transform.position, Quaternion.identity);
            Debug.Log($"Hit {other.name}");
        }
        else
        {
            playerMovement.Shield -= 1;
            Debug.Log(playerMovement.Shield);
        }
    }
}
