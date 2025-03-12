using UnityEngine;

public class WowColor : MonoBehaviour
{
    GameObject[] WillOWisp = new GameObject[3];
    int wColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wColor = Random.Range(0, 3);
        Instantiate(WillOWisp[wColor], transform.position, Quaternion.identity);
    }

}
