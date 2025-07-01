using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameObject promptCanvas;
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
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            player.position = new Vector3(0f, 4.4f, 0f);
            player.rotation = Quaternion.Euler(0f, 90f, 0f);
            //promptCanvas.SetActive(false);

            camera.DisableFollow();
            Camera.main.transform.position = new Vector3(5f,6f,0f);
            Camera.main.transform.LookAt(player.position + Vector3.up * 1.5f);
        }
    }
}
