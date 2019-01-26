using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectPrefab;
    
    
    
    private bool _pointerOnThisItem = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_pointerOnThisItem && Input.GetMouseButtonDown(0))
        {
            GetComponentInParent<Inventory>().Close();
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newObject = Instantiate(objectPrefab, pos, Quaternion.identity);
            newObject.transform.SetParent(null);
            newObject.transform.Translate(0, 0, 0);
            newObject.GetComponent<DynamicObject>().SpawnDragging();
            newObject.SetActive(true);
            GetComponentInParent<Inventory>().DeleteItem(this.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointerOnThisItem = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pointerOnThisItem = false;
    }
}
