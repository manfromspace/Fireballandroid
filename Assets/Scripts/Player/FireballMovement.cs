using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    private CharacterController controller;
    public GameObject destructible;
    public AudioSource BGSong;
    public AudioSource levelMusic;
    public AudioSource movement;
    public AudioSource DeathSong;
    private Vector3 moveVector;

    [SerializeField] float speed = 30.0f;

    private float verticalVelocity = 0.0f;


    public bool levelSong = true;
//    public bool deathSong = false;

    private bool isDead = false;

    private float starttime;
    public GameObject explosion;



    public void DeathMusic()
    {
        levelSong = true;
 //       deathSong = false;
        levelMusic.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    
        starttime = Time.time;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;
      
       moveVector = Vector3.zero;
       //X - left & right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;
        }

        //Y - up & down
        moveVector.y = verticalVelocity;
        //Z - forward & backward
        moveVector.z = speed;

        movement.Play();
        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier)
    {
        speed = speed + modifier*(2);
    }

    // its being called everytime our collider hits an object
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "EnemyPlanets")
        {
            Death();
            DeathMusic();
            BGSong.Stop();
            movement.Stop();
            DeathSong.Play();
          
        }
        if(hit.gameObject.tag == "ship")
        {
            Death();
            Destroy(hit.gameObject);
            DeathMusic();
            BGSong.Stop();
            movement.Stop();
            DeathSong.Play();
        }
       
    }
    
   private void Death()
    {
        isDead = true;
        Destroy(destructible);
        GetComponent<Score>().OnDeath();
        Instantiate(explosion, transform.position, transform.rotation);
     
        
        //Debug.Log("Death");
    }
}
