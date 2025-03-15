using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float rayLenght = 5;
    private Camera _camera;

    private NoteController _noteController;

    [Header("Raycast Features")]
    [SerializeField] private Image crosshair;

    [Header("Raycast Features")]
    [SerializeField] private KeyCode interctKey;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLenght))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                _noteController = readableItem;
                HighLightCrosshair(true);
            }
            else
            {
                ClearNote();
            }
        }
        else 
        {
            ClearNote();
        }

        if(_noteController != null)
        {
            if (Input.GetKeyDown(interctKey))
            {
                _noteController.ShowNote();
            }
        }
    }

    void ClearNote()
    {
        if(_noteController != null)
        {
            HighLightCrosshair(false); 
            _noteController = null;
        }
    }

    void HighLightCrosshair(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }
}
