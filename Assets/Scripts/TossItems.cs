using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossItems : MonoBehaviour
{

    private GameObject player;
    public List<GameObject> items;
    public List<GameObject> bombs;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("tossItem", 2f);
        player = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void tossItem()
    {
        
        GameObject item;
        if (Random.Range(0f,1f) > 0.2f)
        {
            int index = Random.Range(0, items.Count);
            item = Instantiate(items[index],
            new Vector3(Random.Range(-3f, 3f), 1, 7), Quaternion.Euler(0, 0, 0));
        }
        else
        {

            int index = Random.Range(0, bombs.Count);
            Debug.Log("index:" + index.ToString());
            item = Instantiate(bombs[index],
            new Vector3(Random.Range(-3f, 3f), 1, 7), Quaternion.Euler(0, 0, 0));
        }

        item.transform.LookAt(player.transform);
        Rigidbody rig = item.GetComponent<Rigidbody>();
        rig.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        rig.AddForce(
            Quaternion.Euler(50, 0, Random.Range(-10f, 10f)) * 
            Vector3.back * Random.Range(10.0f, 12.0f), ForceMode.Impulse);
        Destroy(item, 5f);

        Invoke("tossItem", 0.5f);
    }
}
