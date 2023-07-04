using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject gameTitle;
    [SerializeField] private GameObject clipoard;
    [SerializeField] private GameObject settingsUI;

    void Start() => StartCoroutine((StartAnimation()));

    public void OpenSettings() => LeanTween.moveLocalX(settingsUI, 538.0f, 0.8f).setEaseSpring();
    
    public void CloseSettings() => LeanTween.moveLocalX(settingsUI, 1500.0f, 0.8f).setEaseSpring();

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        LeanTween.moveLocalX(gameTitle, -725.0f, 0.8f).setEaseSpring();
        LeanTween.moveLocalX(clipoard, 527.0f, 0.8f).setEaseSpring();
    }

    public void CloseMainMenuUI()
    {
        LeanTween.moveLocalX(gameTitle, -1230.0f, 0.8f).setEaseSpring();
        LeanTween.moveLocalX(clipoard, 1496.0f, 0.8f).setEaseSpring();
    }
}