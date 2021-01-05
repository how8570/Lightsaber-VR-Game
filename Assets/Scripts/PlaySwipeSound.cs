using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySwipeSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip swipe;
    private Rigidbody rigidbody;
    private Vector3 preLoc;
    private SaberState saberState;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
        saberState = GameObject.Find("BlueSaber").GetComponent<SaberState>();
        preLoc = transform.position;
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!saberState.isSaberOn) return;
        speed = (transform.position - preLoc).magnitude / Time.deltaTime;
        if (speed > 2f && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(swipe, speed / (speed + 15));
        }
        preLoc = transform.position;
    }

}
