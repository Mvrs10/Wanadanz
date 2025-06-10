using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character;
    public Vector3 offset = new Vector3(-0.4f, 2.9f, -3.8f);
    public float smoothMovement = 5f;

    void LateUpdate()
    {
        if (character != null)
        {
            Vector3 targetPosition = character.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothMovement *  Time.deltaTime);
            transform.LookAt(character.position + Vector3.up * 1.5f);
        }
    }
}
