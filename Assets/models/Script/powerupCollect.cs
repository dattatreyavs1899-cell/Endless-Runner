using System.Collections;
using UnityEngine;

public class collect_pwrUp : MonoBehaviour
{
    [SerializeField] AudioSource pwrFX;
    public int hP = 3;
    bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isCollected)
            {
                isCollected = true;
                pwrFX.Play();
                movement.instance.ApplyBoost();

                masterLvlInfo.instance.coinCount += 10;
                masterLvlInfo.instance.health += hP;
                Debug.Log("Hp" + hP);
                this.gameObject.SetActive(false);
            }
        }
    }
}