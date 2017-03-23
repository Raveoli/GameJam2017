using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {

    public Animation anime;

    // Use this for initialization
	void Start () {
        anime = GetComponent<Animation>();
        
	}
	
	 void Update()
    {
            if (!anime.isPlaying)
            {
                anime.Play();


            }

        
     
    }

}
