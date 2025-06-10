using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character;
    public Vector3 behindOffset = new Vector3(-0.4f, 2.9f, -3.8f);
    public Vector3 frontOffset = new Vector3(-0.4f, 2.9f, 3.8f);
    private Vector3 currentOffset;
    public float smoothMovement = 5f;

    private void Start()
    {
        currentOffset = behindOffset;
        transform.position = character.position + currentOffset;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentOffset == behindOffset)
            {
                currentOffset = frontOffset;
            }
            else
            {
                currentOffset = behindOffset;
            }
        }
    }
    void LateUpdate()
    {
        if (character != null)
        {
            Vector3 targetPosition = character.position + currentOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothMovement *  Time.deltaTime);
            transform.LookAt(character.position + Vector3.up * 1.5f);
        }
    }
}
