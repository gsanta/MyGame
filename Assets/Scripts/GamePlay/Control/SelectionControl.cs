using UnityEngine;

public class SelectionControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("Ground");
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                if (hit.transform)
                {
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.black;
                }
            }
        }
    }
}
