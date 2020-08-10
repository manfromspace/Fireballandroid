using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    public float minscale = .8f;
    public float maxscale = 1.2f;
    [SerializeField] float rotationOffset = 100f;

    public static float destructionDelay = 1.0f;

    Transform MyT;
    Vector3 randomRotation;

    private void Awake()
    {
        MyT = transform;
    }

    private void Start()
    {
        
        //random rotation
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }
    private void Update()
    {
        MyT.Rotate(randomRotation * Time.deltaTime);
    }

   
}
