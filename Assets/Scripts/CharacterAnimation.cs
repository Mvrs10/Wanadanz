using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public CharacterMovement player;
    private Animator anim;
    private int waitingState = Animator.StringToHash("isWaiting");
    private int danceIndex = 0;
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        int selectedDance = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedDance = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) selectedDance = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) selectedDance = 3;
        if (Input.GetKeyDown(KeyCode.Alpha4)) selectedDance = 4;

        if (selectedDance > 0 && selectedDance != danceIndex)
        {
            danceIndex = selectedDance;
            anim.SetInteger("danceIndex", danceIndex);
        }
    }
    public void UpdateAnimation(Vector3 input)
    {
        float walkZ = input.z;
        float walkX = input.x;
        anim.SetFloat("walkZ", walkZ);
        anim.SetFloat("walkX", walkX);
    }

    public void SetWaiting()
    {
        anim.SetTrigger(waitingState);
    }
}
