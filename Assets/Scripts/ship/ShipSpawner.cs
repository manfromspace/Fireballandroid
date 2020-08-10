using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject ship;
    public AudioSource shipSound;

    // Start is called before the first frame update
    void Start()
    {
        ship.SetActive(false);
    }



    // Update is called once per frame
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            ship.SetActive(true);
            Debug.Log("its colliding");
            shipSound.Play();
        }
    }
}
