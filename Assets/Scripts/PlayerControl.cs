using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


    [SerializeField]
    float speed = 5.0f;

    [SerializeField]
    private float lookSensitivity = 3.0f;
    Controller controller;
    private Player player;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if(player.isPlaying)
        {
            float xmove = Input.GetAxis("Horizontal");//-1 to 1
            float zmove = Input.GetAxis("Vertical");//-1 to 1

            Vector3 moveHorizontal = transform.right * xmove;//Using transform instead of Vector also takes into consideration the current rotation
            Vector3 moveVertical = transform.forward * zmove;
            Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            if (xmove != 0 || zmove != 0)
                controller.ImpactHealth();

            float yrot = Input.GetAxis("Mouse X");
            Vector3 rot = new Vector3(0f, yrot, 0f)*lookSensitivity;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rot));
                
        }
        
        
	}
}
