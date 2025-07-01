using UnityEngine;

public class GuitarController : MonoBehaviour
{
    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particle.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particle.Stop();
        }
    }
}
