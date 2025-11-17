using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationFloat : MonoBehaviour
{
    public Animator anim;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical"); ;

        if(Vertical > 0 || Vertical <0 )
        {
            anim.SetFloat("velocidad", Vertical);
        }

        
    }
}
