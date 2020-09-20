using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChange : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip beginning;
    public AudioClip pacMan_walk;
    public AudioClip bgm_normal;
    AudioSource audioController;
    float timer;
    IEnumerator Start()
    {
        timer = 0;
        audioController = GetComponent<AudioSource>();
        audioController.clip = beginning;
        audioController.Play();

        yield return new WaitForSeconds(audioController.clip.length);

        audioController.clip = bgm_normal;
        audioController.spatialBlend = 0.5f;
        audioController.volume = 1.0f;
        audioController.loop = true;
        audioController.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.6) {
            timer = 0;

            audioController.PlayOneShot(pacMan_walk,0.1f);
            //audioController.volume = 0.05f;
        }
        timer += Time.deltaTime;
    }
}
