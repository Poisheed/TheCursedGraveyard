using UnityEngine;

public class WillOWisp : MonoBehaviour
{
    [SerializeField]
    float minAppear;
    [SerializeField]
    float maxAppear;
    [SerializeField]
    float minDisappear;
    [SerializeField]
    float maxDisappear;
    float appearTime;
    float disappearTime;
    [SerializeField]
    GameObject collider;
    bool isAppear;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Resetter();
    }

    // Update is called once per frame
    void Update()
    {
        if (appearTime>0 && !isAppear) appearTime -= Time.deltaTime;
        if (appearTime < 0 && !isAppear) 
        { 
            isAppear = true;
            collider.SetActive(true); 
        }
        if (isAppear) disappearTime -= Time.deltaTime;
        if (disappearTime<0)
        {
            Resetter();
        }

    }

    float TimeRandomizer(float min, float max)
    {
        float rndTime = Random.Range(min, max);
        return rndTime;
    }

    void Resetter()
    {
        isAppear = false;
        collider.SetActive(false);
        appearTime = TimeRandomizer(minAppear, maxAppear);
        disappearTime = TimeRandomizer(minDisappear, maxDisappear);
    }
}
