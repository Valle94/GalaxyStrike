using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] ParticleSystem[] lasers;
    private bool isFiring = false;

    void Update()
    {
        ProcessFiring();
    }

    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    
    private void ProcessFiring()
    {
        foreach (ParticleSystem laser in lasers)
        {
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }
}
