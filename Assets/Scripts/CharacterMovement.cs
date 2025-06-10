using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody rb;
    private Vector3 movement;
    private CharacterAnimation characterAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterAnim = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = transform.right * moveX + transform.forward * moveZ;
        Vector3 inputDirection = new Vector3(moveX, 0, moveZ);
        characterAnim.UpdateAnimation(inputDirection);
    }

    private void FixedUpdate()
    {
        Vector3 newPostion = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPostion);
    }
}
