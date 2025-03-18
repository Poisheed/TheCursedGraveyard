using UnityEngine;

public class CancelloOpen : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Transform objectToRotate1;  // L'oggetto che ruoterà
    public Transform objectToRotate2;  // L'oggetto che ruoterà
    public Vector3 rotationAngles = new Vector3(0, 90, 0);  // Di quanti gradi ruotare
    public float rotationSpeed = 5f; // Velocità della rotazione
    public GameObject Collider_cancello;
    private Collider col;

    private bool shouldRotate = false;
    private Quaternion targetRotation1;
    private Quaternion targetRotation2;

    private void Start()
    {
       if (Collider_cancello != null)
        {
            col = Collider_cancello.GetComponent<Collider>();
        }

        /*if (objectToRotate == null)
        {
            objectToRotate = transform; // Se non assegnato, usa l'oggetto stesso
        }*/
    }

    private void Update()
    {
        if (shouldRotate)
        {
            objectToRotate1.rotation = Quaternion.Lerp(objectToRotate1.rotation,targetRotation1,Time.deltaTime * rotationSpeed);
            objectToRotate2.rotation = Quaternion.Lerp(objectToRotate2.rotation, targetRotation2, Time.deltaTime * rotationSpeed);

            // Ferma la rotazione quando è quasi completa
            if (Quaternion.Angle(objectToRotate1.rotation, targetRotation1) < 0.1f)
            {
                shouldRotate = false;
                Destroy(this);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assicurati che il Player abbia il tag "Player"
        {
            targetRotation1 = Quaternion.Euler(objectToRotate1.eulerAngles + rotationAngles);
            targetRotation2 = Quaternion.Euler(objectToRotate2.eulerAngles - rotationAngles);
            shouldRotate = true;
            if (col != null)
            {
                col.enabled = false;
            }
        }
    }
}
