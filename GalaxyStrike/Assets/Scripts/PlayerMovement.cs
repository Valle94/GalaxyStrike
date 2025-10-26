using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 50f;
    [SerializeField] private float boostFactor = 2f;
    [SerializeField] private float xClampRange = 10f;
    [SerializeField] private float yClampRange = 10f;

    [SerializeField] private float controlRollFactor = 30f;
    [SerializeField] private float controlPitchFactor = 15f;
    [SerializeField] private float rotationSpeed = 10f;

    Vector2 movement;
    float boost;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    public void OnBoost(InputValue value)
    {
        boost = value.Get<float>();
        if (boost >= 0.5f)
        {
            controlSpeed *= boostFactor;    
        }
        else
        {
            controlSpeed = 50f;
        }
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float pitch = controlPitchFactor * -movement.y;
        float roll = controlRollFactor * -movement.x;
        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}