using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(Player))]
public class Controller : MonoBehaviour {

    
    Player player;
    PlayerUI playerUI;
    
    Waves wave;

    public GameObject girl;
    public GameObject puddle;
    public GameObject destination;

    const string contaminatorTag = "Contaminator";
    const string drainTag = "Drain";
    const string fireTag = "Fire";
    const string spongeTag = "Sponge";
    const string windTag = "Wind";
    const string healthkitTag = "Healthkit";
    const string destinationTag = "Destination";
    const string triggerTag = "Trigger";

    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    public Material material6;
    int hour;
   
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        player.SetDefaults();
        playerUI = GetComponent<PlayerUI>();
        playerUI.SetPlayer(player);
        
        

	}
	
	// Update is called once per frame
	void Update () {
        hour=DateTime.Now.Hour;
        switch(hour)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                RenderSettings.skybox = material1;
                break;
            case 4:
            case 5:
            case 6:
            case 7:
                RenderSettings.skybox = material2;
                break;
            case 8:
            case 9:
            case 10:
            case 11:
                RenderSettings.skybox = material3;
                break;
            case 12:
            case 13:
            case 14:
            case 15:
                RenderSettings.skybox = material4;
                break;
            case 16:
            case 17:
            case 18:
            case 19:
                RenderSettings.skybox = material5;
                break;
            case 20:
            case 21:
            case 22:
            case 23:
                RenderSettings.skybox = material6;
                break;
            default:
                RenderSettings.skybox = material2;
                break;

        }
        
	    
	}

    public void ImpactHealth()
    {
        player.DecreaseHealth(0.01f);
        if (player.GetHealthLevel() <= 0)
            playerUI.GameOver();
    }

    void OnCollisionEnter(Collision _collision)
    {
        if(player.isPlaying)
        {
            
            switch (_collision.gameObject.tag)
            {
                case contaminatorTag:
                    player.IncreaseContamination();
                    Destroy(_collision.gameObject);
                    break;

                case drainTag:
                    player.DecreaseHealth(5f);

                    break;

                case fireTag:
                    player.DecreaseHealth(100f);
                    break;

                case spongeTag:
                    player.DecreaseHealth(10f);
                    playerUI.BlowUpSponge(_collision.collider.gameObject);
                    break;

                case windTag:
                    this.transform.localPosition += new Vector3(-1f, 0f, 0f);
                    Destroy(_collision.gameObject);
                    break;

                case healthkitTag:
                    player.IncreaseHealth(5f);
                    Destroy(_collision.gameObject);
                    
                    break;

                case destinationTag:
                    Destroy(_collision.gameObject);
                    StartCoroutine(CreateWave());
                    
                    break;

                case triggerTag:
                    
                    Vector3 _pos = girl.transform.position;
                   
                    Destroy(_collision.collider.gameObject);
                    break;

            }
            if (player.GetContaminaionLevel() >= player.MaxContamination())
            {
                playerUI.GameOver();
            }
            if (player.GetHealthLevel() <= 0)
            {
                playerUI.GameOver();
            }
     
        }
           
    }

    IEnumerator MakePuddle(GameObject go)
    {
        
        yield return new WaitForSeconds(3);
        
        Destroy(go);
    }

    IEnumerator CreateWave()
    {
        Instantiate(destination);
        yield return new WaitForSeconds(5f);
        playerUI.Win();
    }
}
