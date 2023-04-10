using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] soundClip;
    public int cuedSound;
    bool hasPlayed = false;
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if(!audioSource.isPlaying)
        {
            reset_hasPlayed();
        }
    }
    public void playAudio_oneShot()
    {
        if(!hasPlayed)
        {
            audioSource.PlayOneShot(soundClip[cuedSound]);
            Debug.Log("playing one shot " + cuedSound);
            hasPlayed = true;
        }
    }

    public void playAudio()
    {
        audioSource.Stop();
        audioSource.clip = soundClip[cuedSound];
        audioSource.Play();
    }

    private void reset_hasPlayed()
    {
        hasPlayed = false;
    }
}
