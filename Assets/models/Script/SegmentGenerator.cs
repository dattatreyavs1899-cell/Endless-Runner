using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public float Timeinterval = 6;
    public GameObject[] segment;
    //public GameObject segmentMap02;
    //public GameObject segmentMap03;
    //public GameObject segmentMap04;
    //public GameObject segmentMap05;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegments = false;
    [SerializeField] int segmentCount;
    void Update()
    {
        if (creatingSegments == false)
        {
            creatingSegments = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentCount = Random.Range(0, 2);
        Instantiate(segment[segmentCount], new Vector3(0,0,zPos), Quaternion.Euler(0,90,0));
        zPos += 50;
        yield return new WaitForSeconds(Timeinterval);
        creatingSegments = false;

        //yield return new WaitForSeconds(Timeinterval);
        //segmentM.SetActive(true);
        //yield return new WaitForSeconds(Timeinterval); segmentMap03.SetActive(true);
        //yield return new WaitForSeconds(10); segmentMap04.SetActive(true);
        //yield return new WaitForSeconds(10); segmentMap05.SetActive(true);
    }
   
}
