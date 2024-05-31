using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitchScript : MonoBehaviour
{
    private Transform player;
    private RaycastHit raycastHit;
    public float maxSelectionRange;

    void Start()
    {
        player = Camera.main.transform;
        maxSelectionRange = 3;
    }

    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            Transform target = raycastHit.transform;
            float distance = Vector3.Distance(player.position, target.position);

            if (target.CompareTag("Switch") && distance <= maxSelectionRange)
            {
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("Selected: " + target.name);
                }
            }
        }
    }
}
