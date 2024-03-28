using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    [SerializeField] GameObject preview;
    [SerializeField] GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "Plane")
            {
                preview.transform.position = hit.point + new Vector3(0, 0.5f, 0);
            }
            if (hit.transform.tag == "item" & Input.GetMouseButtonDown(1))
            {
                BreakBlock(hit.collider.gameObject);
            }
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBlock(preview.transform.position);
            }


        }
    }

    public void PlaceBlock(Vector3 place)
    {
        GameObject thingy = Instantiate(item);
        thingy.transform.position = place;
    }

    public void BreakBlock(GameObject thingy)
    {
        Destroy(thingy);
    }

}
