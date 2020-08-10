using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGsoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static BGsoundScript instance = null;
    public static BGsoundScript Instance
    {
        get { return instance; }
    }



    private void Awake()
    {
       if(instance!=null && instance!= this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
