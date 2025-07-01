using UnityEngine;

public class WalkSound : StateMachineBehaviour
{
    [SerializeField]
    private SoundType type;
    [SerializeField, Range(0, 1)]
    private float volume = 1;
    [SerializeField, Range(0, 1)]
    private float interval = 0.7f;
    private float timer = 0f;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SoundManager.PlaySound(type, volume);
            timer = 0f;
        }
    }
}
