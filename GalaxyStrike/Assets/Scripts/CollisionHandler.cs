using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDestroyVFX;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestroyVFX, gameObject.transform.position, Quaternion.identity);
        Debug.Log($"Hit {other.name}");
    }
}
