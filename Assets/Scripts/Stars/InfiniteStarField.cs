using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStarField : MonoBehaviour
{
    private Transform tx;
    private ParticleSystem.Particle[] points;
    private ParticleSystem ps;

    public int starsMax = 100;
    public  float startSize = 0.2f;
    public float starDistance = 10;
    public float starClipDistance = 1;
    private float starDistanceSqr;

    private void Start()
    {
        tx = transform;
        starDistanceSqr = starDistance * starDistance;
        ps = tx.GetComponent<ParticleSystem>();
    }

    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];
        for(int i =0; i< starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].color = new Color(1, 1, 1);
            points[i].size = startSize;
        }
    }

    private void Update()
    {
        if (points == null) CreateStars();

        for (int i = 0; i < starsMax; i++)
        {
            if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr)
            {
                points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
            }
            if ((points[i].position - tx.position).sqrMagnitude <= starDistanceSqr)
            {
                float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistance;
                points[i].color = new Color(1, 1, 1, percent);
                points[i].size = percent * startSize;
            }
        }
        ps.SetParticles(points, points.Length);
    }
    
}
