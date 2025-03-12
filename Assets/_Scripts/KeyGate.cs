using UnityEngine;

public class KeyGate : MonoBehaviour
{
    int keyPos = 0; //impostare in base alla posizione dell'item key nell'array di PickUp
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && other.GetComponent<PickUp>().objectNumber[keyPos] != 0)
        {
            //play animation
        }
    }
}
