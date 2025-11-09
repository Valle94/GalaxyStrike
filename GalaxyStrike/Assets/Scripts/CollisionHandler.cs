using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDestroyVFX;

    PlayerMovement playerMovement;
    GameSceneManager gameSceneManager;

    void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerMovement.Shield <= 0)
        {
            gameSceneManager.ReloadLevel();
            Instantiate(playerDestroyVFX, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            playerMovement.Shield -= 1;
        }
    }

}