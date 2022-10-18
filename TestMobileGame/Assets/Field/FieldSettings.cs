using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class FieldSettings : MonoBehaviour
{
    [SerializeField] int fieldDimension;
    [SerializeField] Pocket pocket;
    static Dictionary<Pocket, (int, int)> pocketsDictionary;
    static GameObject eventWindowPanel;


    private void Awake()
    {
        eventWindowPanel = GameObject.FindGameObjectWithTag("EventWindow");
        eventWindowPanel.SetActive(false);
        CreateField();
        FillField(4, 6);
    }

    private void CreateField()
    {
        pocketsDictionary = new Dictionary<Pocket, (int, int)>();
        for (int i = 0; i < fieldDimension * fieldDimension; i++)
        {
            var newPocket = Instantiate(pocket, transform.position, Quaternion.identity, transform);
            pocketsDictionary.Add(newPocket, (i / fieldDimension, i % fieldDimension));
        }
    }

    private void FillField(params int[] pocketsToSpawn)
    {
        foreach (var index in pocketsToSpawn)
            transform.GetChild(index - 1).GetComponent<Pocket>().SpawnBlock();
    }

    public static void CheckMatch(Pocket newPocket)
    {
        if (pocketsDictionary
            .Where(pocket => pocket.Value.Item1 == pocketsDictionary[newPocket].Item1)
            .All(pocket => pocket.Key.transform.childCount > 0))
        {
            foreach (var pocket in pocketsDictionary)
                if (pocket.Value.Item1 == pocketsDictionary[newPocket].Item1)
                    pocket.Key.transform.GetChild(0).GetComponent<Block>().StartDestroyAnimation();

        }
        else if (pocketsDictionary
            .Where(pocket => pocket.Value.Item2 == pocketsDictionary[newPocket].Item2)
            .All(pocket => pocket.Key.transform.childCount > 0))
        {
            foreach (var pocket in pocketsDictionary)
                if (pocket.Value.Item2 == pocketsDictionary[newPocket].Item2)
                    pocket.Key.transform.GetChild(0).GetComponent<Block>().StartDestroyAnimation();
        }
        else OpenEventWindow("Œÿ»¡ ¿");
    }

    public static void OpenEventWindow(string text)
    {
        eventWindowPanel.SetActive(true);
        eventWindowPanel.transform.GetChild(0).GetComponentInChildren<Text>().text = text;
    }
}
