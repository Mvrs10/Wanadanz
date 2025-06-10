using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    public void UpdateAnimation(Vector3 input)
    {
        float walkZ = input.z;
        float walkX = input.x;
        anim.SetFloat("walkZ", walkZ);
        anim.SetFloat("walkX", walkX);
    }
}
