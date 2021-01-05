using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldRightHand : MonoBehaviour
{
    public GameObject serber;
    public GameObject rightHand;
    private Vector3 handle = new Vector3(0, 0.15f, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = rightHand.transform.rotation * Quaternion.Euler(90, 0, 0) * handle;
        serber.transform.position = rightHand.transform.position + offset;
        serber.transform.rotation = rightHand.transform.rotation * Quaternion.Euler(90, 0, 0);
    }
}
