 using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void PlaySFX(AudioClip audioClip, float volume = 1f)
    {
        StartCoroutine(PlaySFXCoroutine(audioClip, volume));
    }

    IEnumerator PlaySFXCoroutine(AudioClip audioClip, float volume = 1f)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        yield return new WaitForSeconds(audioClip.length * 2f);

        Destroy(audioSource);
    }
}
