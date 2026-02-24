using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class masterLvlInfo : MonoBehaviour
{
    public static masterLvlInfo instance;

    public int coinCount = 0;
    public int health = 6;
    [SerializeField] TextMeshProUGUI coinDisplay;
    [SerializeField] TextMeshProUGUI distDisplay;
    //[SerializeField] int Dot = 5;

    [Header("Game Over Info")]
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject thePlayerAnim;
    
    [SerializeField] GameObject gameBgm;
    [SerializeField] AudioSource gameOvrBgm;
    [SerializeField] AudioSource emotionalDmg;
    [SerializeField] AudioSource coinCollectSFX;
    [SerializeField] AudioSource gemCollectSFX;

    [SerializeField] GameObject fadeOutAnim;
    [SerializeField] GameObject fadeOutText;
    [SerializeField] GameObject camShake;

    public float distanceRun = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        coinCount = 0;
        coinDisplay.text = "Coins: " + coinCount;
        distDisplay.text = "Distance: " + distanceRun;

       // health = 6;

        //  StartCoroutine(healthCount());
    }

    // Update is called once per frame
    void Update()
    {
        healthDisp.GetComponent<TMPro.TMP_Text>().text = "Health: " + (health);
        if (health <= 0)
        {
            StartCoroutine(idleAnim());
        }

        Debug.Log("Health: " + health);
    }


    //IEnumerator healthCount()
    //{
    //    while (health>0)
    //    {
    //        if (Dot >= 0)
    //        {
    //            health--;
    //        }
    //        yield return new WaitForSeconds(Dot);
    //    }
    //}

    IEnumerator idleAnim()
    {
        emotionalDmg.Play();
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

    public void OnCoinCollected()
    {
        coinCount += 1;
        coinDisplay.text = "Coins: " + coinCount;
        coinCollectSFX.Play();
    }

    public void OnGemCollected()
    {
        coinCount += 4;
        coinDisplay.text = "Coins: " + coinCount;
        gemCollectSFX.Play();
    }
}
