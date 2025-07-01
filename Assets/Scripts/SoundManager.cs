using UnityEngine;

public enum SoundType
{
    BACKGROUND,
    WALK,
    MUSIC
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] soundClips;
    private static SoundManager instance;
    private AudioSource sfxSource;
    private AudioSource bgSource;
    [SerializeField, Range(0, 1)]
    private float bgVolume = 0.1f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        sfxSource = GetComponent<AudioSource>();
        bgSource = gameObject.AddComponent<AudioSource>();
        bgSource.loop = true;
    }

    private void Start()
    {        
        bgSource.clip = soundClips[(int)SoundType.BACKGROUND];        
        bgSource.volume = bgVolume;
        bgSource.Play();
    }

    public static void PlaySound(SoundType type, float volume = 1)
    {
        instance.sfxSource.PlayOneShot(instance.soundClips[(int)type], volume);
    }

}
