using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameObject promptCanvas;
    public GameObject piano, guitar, amp;
    public Transform player;
    public new CameraController camera;
    private bool isInteractable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptCanvas.SetActive(true);
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptCanvas.SetActive(false);
            isInteractable = false;
        }
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.F))
        {
            //Setup postion
            player.position = new Vector3(0f, 4.4f, 0f);
            player.rotation = Quaternion.Euler(0f, 90f, 0f);
            piano.SetActive(true);
            guitar.SetActive(true);
            amp.SetActive(true);           

            camera.DisableFollow();
            Camera.main.transform.position = new Vector3(5f,6f,0f);
            Camera.main.transform.LookAt(player.position + Vector3.up * 1.5f);

            //Freeze my player
            
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            CharacterMovement cm = player.GetComponent<CharacterMovement>();
            cm.SetDance();
            CharacterAnimation ca = player.GetComponent<CharacterAnimation>();
            ca.SetWaiting();
            //Start the music
            SoundManager.PlaySound(SoundType.MUSIC);
        }
    }
}
