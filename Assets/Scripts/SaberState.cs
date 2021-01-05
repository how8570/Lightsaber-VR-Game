using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberState : MonoBehaviour
{

    public bool isSaberOn;
    public GameObject saberBlade;
    public AudioClip turnOnSound;
    
    private CapsuleCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<CapsuleCollider>();
        isSaberOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool pre = isSaberOn;
        isSaberOn = Input.GetKey(KeyCode.Mouse0);
        if (!pre && isSaberOn)
        {
            AudioSource.PlayClipAtPoint(turnOnSound, transform.position);
        }

        saberBlade.SetActive(isSaberOn);
        collider.enabled = isSaberOn;

    }
}
