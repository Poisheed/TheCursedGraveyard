using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{


    string[] objectName = new string[] {};
    public Text[] objectText = new Text[] { };
    public int[] objectNumber = new int[] { 0, 0, 0 };
    

    

    private void OnTriggerEnter(Collider other)
    {
        int n = 0;
        //illumina tasto
        //is tasto premuto
        foreach (string a in objectName)
        {
            if (other.name == objectName[n])
            {
                objectNumber[n] += other.GetComponent<Amount>().amount;
                objectText[n].text = objectNumber[n].ToString();
            }
            else n++;
        }
    }
}
