using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{

    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject thePlayerAnim;
    [SerializeField] AudioSource collisionFX;
    [SerializeField] GameObject gameBgm;
    [SerializeField] AudioSource gameOvrBgm;

    [SerializeField] GameObject fadeOutAnim;
    [SerializeField] GameObject fadeOutText;
    [SerializeField] GameObject camShake;



    private void OnTriggerEnter(Collider other)
    {
        

        
        StartCoroutine(idleAnim());
        

    }

    IEnumerator idleAnim()
    {
        collisionFX.Play();
        thePlayer.GetComponent<movement>().enabled = false;
        thePlayerAnim.GetComponent<Animator>().Play("Stumble Backwards");
        

        gameBgm.GetComponent<AudioSource>().enabled = false;
        camShake.GetComponent<Animator>().Play("CollisionCam");

        yield return new WaitForSeconds(2);
        //thePlayerAnim.GetComponent<Animator>().Play("Breathing Idle");
        gameOvrBgm.Play();
        yield return new WaitForSeconds(1);
        fadeOutAnim.gameObject.SetActive(true);
        fadeOutText.gameObject.SetActive(true);

        yield return new WaitForSeconds(11);
        SceneManager.LoadScene(0);

    }

}
