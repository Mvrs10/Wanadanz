using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movement = transform.right * moveX + transform.forward * moveZ;
    }

    private void FixedUpdate()
    {
        Vector3 newPostion = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPostion);
    }
}
