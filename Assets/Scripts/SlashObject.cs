using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObject : MonoBehaviour
{
    public GameState gameState;
    public List<GameObject> hitEffects;
    public List<AudioClip> hitSounds;
    public List<AudioClip> bombSounds;

    private SaberState saberState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameManager").GetComponent<GameState>();
        saberState = GameObject.Find("BlueSaber").GetComponent<SaberState>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!saberState.isSaberOn) return;

        if (other.gameObject.CompareTag("Item"))
        {
            // display hit explosion effect
            int effectIndex = Random.Range(0, hitEffects.Count);
            GameObject explotion = Instantiate(hitEffects[effectIndex], other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(explotion, 3f);
            
            // add score by item (name to compare)
            switch (other.gameObject.name)
            {
                case "Item_0(Clone)":
                    gameState.score += 30;
                    break;
                case "Item_1(Clone)":
                    gameState.score += 10;
                    break;
                case "Item_2(Clone)":
                    gameState.score += 15;
                    break;
                case "Item_3(Clone)":
                    gameState.score += Random.Range(-10, 50 +1); // [min, max)
                    break;
                default:
                    break;
            }

            // play hit sounds
            int soundIndex = Random.Range(0, hitSounds.Count);
            AudioSource.PlayClipAtPoint(hitSounds[soundIndex], other.transform.position);
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            // display hit explosion effect
            int effectIndex = Random.Range(0, hitEffects.Count);
            GameObject explotion = Instantiate(hitEffects[effectIndex], other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(explotion, 3f);

            // add score by item (name to compare)
            switch (other.gameObject.name)
            {
                case "Bomb_01(Clone)":
                    gameState.score += -50;
                    break;
                default:
                    break;
            }

            // play bomb sounds
            int soundIndex = Random.Range(0, bombSounds.Count);
            AudioSource.PlayClipAtPoint(bombSounds[soundIndex], other.transform.position);

        }
    }

}
