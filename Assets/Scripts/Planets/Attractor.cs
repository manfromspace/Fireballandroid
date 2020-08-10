using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private List<GameObject> pullObjects;
    public Vector3 pullDirection;
    public float pullSpeed;
    public AudioSource bhole;
    void Start()
    {
        pullObjects = new List<GameObject>();
    }

    void FixedUpdate()
    {
        foreach (GameObject obj in pullObjects)
        {
            obj.transform.Translate(Time.deltaTime * pullSpeed * pullDirection);
            
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("object entered");
        pullObjects.Add(col.gameObject);
        bhole.Play();
    }


    public void OnTriggerExit(Collider col)
    {
        pullObjects.Remove(col.gameObject);
        bhole.Stop();
    }

}
