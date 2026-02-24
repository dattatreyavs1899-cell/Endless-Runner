using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject clickText;
    [SerializeField] GameObject fullButton;
    [SerializeField] GameObject animCam;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject menuControl;

    [SerializeField] AudioSource FirstButtonFx;
    [SerializeField] AudioSource secButtonFx;

    public static bool hasClicked;
    [SerializeField] GameObject staticCam;
    [SerializeField] GameObject fadeIn;

    void Start()
    {

        StartCoroutine(FadeInOff());

        if (hasClicked)
        {
            staticCam.SetActive(true);
            animCam.SetActive(false);
            menuControl.SetActive(true);
            clickText.SetActive(false);
            fullButton.SetActive(false);
            
        }
    }

    void Update()
    {
        
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimeCam());
    }

    public void StartGame()
    {
        StartCoroutine(startButton());
    }

    IEnumerator startButton()
    {
        secButtonFx.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }

    IEnumerator AnimeCam()
    {
        FirstButtonFx.Play();
        animCam.GetComponent<Animator>().Play("AnimeMenuCam");
        clickText.SetActive(false);
        fullButton .SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
        mainCam.SetActive(true);
        animCam.SetActive(false);
        menuControl.SetActive(true);
        hasClicked = true;

    }

    IEnumerator FadeInOff()
    {
        yield return new WaitForSeconds(1.5f);
        fadeIn.SetActive(false);
    }

}
