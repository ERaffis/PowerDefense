using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public bool isInRound;
    public Image powerEnemies;
    public Image powerCable;
    public float powerAmount;
    public float dmg;

    public Cable[] listCable;
    public GameObject replay;
    public TMP_Text finalScore;
    public TMP_Text timer;

    public LevelTransition transition;
    public bool lost;



    // Start is called before the first frame update
    void Start()
    {
        isInRound = false;
        lost = false;
        powerCable.fillAmount = 0;

        /*TimeTickSystem.OnTick += delegate (object sender, TimeTickSystem.OnTickEventArgs e)
        {
            CMDebug.TextPopupMouse("Tick : " + e.tick);
        };*/
    }

    // Update is called once per frame
    void Update()
    {
        powerAmount = powerCable.fillAmount;
        powerEnemies.fillAmount = powerCable.fillAmount + dmg;

        if (powerEnemies.fillAmount >= 0.98f && lost == false)
        {
            lost = true;
            Time.timeScale = 0;
            replay.SetActive(true);
            finalScore.SetText("Score : " + timer.text);
        }
    }

    public void DamageCore()
    {
        dmg += 0.05f;
        if (powerEnemies.fillAmount >= 1)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }

    public void DamageCore(float value)
    {
        dmg += value;
        if (powerEnemies.fillAmount >= 1)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }

    public void ShutDownCable()
    {
        foreach (var item in listCable)
        {
            if (item.isActive)
            {
                item.DisableCable();
                break;
            }
        }
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        Time.timeScale = 1;
        transition.StartCoroutine(transition.LoadLevel(1));
    }
}
