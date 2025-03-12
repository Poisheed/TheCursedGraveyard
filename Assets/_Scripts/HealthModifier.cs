using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    /*
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioSource pickSound;

    public bool goUp;

    [Range(0, 3)]
    public float speed = 1;

    [Range(0, 100)]
    public float rotationSpeed = 25;

    private void OnValidate()
    {
        if (audioSource) { return; }
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(SwitchDirection());
    }

    // Update is called once per frame
    void Update()
    {
        if (goUp)
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0, speed * Time.deltaTime, 0);
        }
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
    IEnumerator SwitchDirection()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.5f);
            goUp = !goUp;
        }
    }*/

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnPicked(other);
            Destroy(gameObject, 2);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPicked(collision);
            //Destroy(gameObject, 2);
        }
    }


    protected virtual void OnPicked(Collider2D other)
    {
        //audioSource.Play();
        //HidePill();
        //GetComponent<Collider2D>().enabled = false;
        Debug.Log("Hai preso: " + gameObject.name);
    }

    void HidePill()
    {
        //GetComponent<Renderer>().enabled = false;
    }
}
