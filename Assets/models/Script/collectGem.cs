using UnityEngine;

public class collectGem : MonoBehaviour
{
    [SerializeField] GameObject coinRotate;

    private void OnTriggerEnter(Collider other)
    {
        
        masterLvlInfo.instance.OnGemCollected();
        this.gameObject.SetActive(false);
    }

}
