using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winningText;
    public GameObject losingText;
    public GameObject retryPrompt;
    
    public GameObject playerCharacter;
    public GameObject winningParticles;

    void Start()
    {
        winningText.SetActive(false);
        losingText.SetActive(false);
        retryPrompt.SetActive(false);
        playerCharacter.SetActive(true);
        winningParticles.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    private void OnEnable()
    {
        ZoneTriggers.OnObjEnteredWin += HandleObjectEnteredWinningZone;
        ZoneTriggers.OnObjEnteredLava += HandleObjectEnteredLavaZone;
    }

    private void OnDisable()
    {
        ZoneTriggers.OnObjEnteredWin -= HandleObjectEnteredWinningZone;
        ZoneTriggers.OnObjEnteredLava -= HandleObjectEnteredLavaZone;
    }

    private void HandleObjectEnteredWinningZone(GameObject enteredObject)
    {
        Debug.Log(enteredObject.name + " has entered the Winning Zone!");
        winningText.SetActive(true);
        retryPrompt.SetActive(true);
        playerCharacter.SetActive(false);
        winningParticles.SetActive(false);
    }

    private void HandleObjectEnteredLavaZone(GameObject enteredObject)
    {
        Debug.Log(enteredObject.name + " dies on contact with lava.");
        losingText.SetActive(true);
        retryPrompt.SetActive(true);
        playerCharacter.SetActive(false);
        winningParticles.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}