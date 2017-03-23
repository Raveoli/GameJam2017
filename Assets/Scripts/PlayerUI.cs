using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    RectTransform contaminationFill;

    [SerializeField]
    RectTransform healthFill;

    [SerializeField]
    private GameObject pauseMenu;

    private Player player;

    [SerializeField]
    GameObject sponge;

    [SerializeField]
    public Text healthText;

    [SerializeField]
    public Text contaminationText;

    [SerializeField]
    private GameObject gameOverMenu;

    [SerializeField]
    private GameObject winMenu;

    [SerializeField]
    private Text healthTextBottom;

    [SerializeField]
    private Text contaminationTextBottom;

	void Start () {
        gameOverMenu.SetActive(false);
        winMenu.SetActive(false);
        sponge.transform.localScale = new Vector3(1f, 1f, 1f);

	}


	
	// Update is called once per frame
	void Update () {
        SetContaminationLevel(player.GetContaminaionPercent());
        SetHealthLevel(player.GetHealthPercent());
        SetBottomData();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
            
	}
    
    public void GameOver()
    {
        player.isPlaying = false;
        gameOverMenu.SetActive(!gameOverMenu.activeSelf);
    }

    public void Win()
    {
        player.isPlaying = false;
        winMenu.SetActive(!winMenu.activeSelf);
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if(pauseMenu.activeSelf)
        {
            player.isPlaying = false;
            SetData();
        }
        else
        {
            player.isPlaying = true;
        }
            
    }

    public void SetData()
    {
        double health = Math.Floor((double)player.GetHealthPercent()*100);
        healthText.text = "Health: "+health.ToString()+"%";
        double contamination = Math.Floor((double)player.GetContaminaionPercent()*100);
        contaminationText.text = "Contamination: "+contamination.ToString()+"%" ;
    }

    public void SetBottomData()
    {
        double health = Math.Floor((double)player.GetHealthPercent() * 100);
        healthTextBottom.text = "Health: " + health.ToString() + "%";
        double contamination = Math.Floor((double)player.GetContaminaionPercent() * 100);
        contaminationTextBottom.text = "Contamination: " + contamination.ToString() + "%";
    }

    public void SetPlayer(Player _player)
    {
        player = _player;
    }

    public void SetContaminationLevel(float _amount)
    {
        contaminationFill.localScale = new Vector3(1f, _amount, 1f);
    }

    public void SetHealthLevel(float _amount)
    {

        healthFill.localScale = new Vector3(1f, _amount, 1f);
    }

    public void BlowUpSponge(GameObject go)
    {
        go.transform.localScale += new Vector3(0.3f,0,0.3f);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Intro");
    }
}
;