using System.Collections;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    public float Timeinterval = 6;
    public GameObject[] sec;
    [SerializeField] int zPos = 0;
    [SerializeField] int coinPos = 50;
    [SerializeField] bool creatingSec = false;
    [SerializeField] int secCount;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log("start");
        if (creatingSec == false)
        {
            Debug.Log("if");
            creatingSec = true;
            StartCoroutine(SegGen());
        }
        Debug.Log("endif");
    }

    IEnumerator SegGen()
    {
        Debug.Log("couroutine");
        secCount = Random.Range(0, 2);
        Instantiate(sec[secCount], new Vector3(0, 0, zPos), Quaternion.Euler(0, 90, 0));
        zPos += 50;
        yield return new WaitForSeconds(Timeinterval);
        creatingSec = false;
    }
}
