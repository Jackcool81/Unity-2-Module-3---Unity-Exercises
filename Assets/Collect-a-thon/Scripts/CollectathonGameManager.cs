using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectathonGameManager : MonoBehaviour
{
    public List<Vector3> predefinedLocations;
    public float randomLocationRange = 30;

    public List<InvItem> levelItems;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelItems.Count; i++) {
            PlaceLocation(i, levelItems[i].gameObject);
        }
    }


    public void PlaceLocation(int index, GameObject go)
    {
        // Predefined Location
        if(index < predefinedLocations.Count)
        {
            go.transform.position = predefinedLocations[index];
        }
        // Random Location
        else
        {
            go.transform.position = new Vector3(
                Random.Range(-randomLocationRange,randomLocationRange),
                Random.Range(Mathf.Min(0,randomLocationRange),randomLocationRange),
                Random.Range(-randomLocationRange,randomLocationRange));
        }
    }
}
