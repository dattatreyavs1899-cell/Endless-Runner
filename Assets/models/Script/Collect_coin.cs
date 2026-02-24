using UnityEngine;

public class Collect_coin : MonoBehaviour
{
    [SerializeField] GameObject coinRotate;

    private void OnTriggerEnter(Collider other)
    {
        masterLvlInfo.instance.OnCoinCollected();
        this.gameObject.SetActive(false);
    }

}
