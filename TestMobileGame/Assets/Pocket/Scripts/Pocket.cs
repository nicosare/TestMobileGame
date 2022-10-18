using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pocket : MonoBehaviour, IDropHandler
{
    [SerializeField] Block block;
    GameObject Item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void SpawnBlock()
    {
        Instantiate(block, transform.localPosition, Quaternion.identity, transform);
        if (Item.GetComponent<Block>().OnField)
            Item.transform.gameObject.GetComponent<DragHandler>().enabled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!Item)
        {
            DragHandler.item.transform.SetParent(transform);
            if (Item.GetComponent<Block>().OnField)
            {
                Item.transform.gameObject.GetComponent<DragHandler>().enabled = false;
                FieldSettings.CheckMatch(this);
            }
            else
                transform.SetAsLastSibling();
        }
    }
}
