using System.Collections.Generic;
using UnityEngine;

public class GatheringBuildingBehaviour : BuildingBehavoiur
{
    private List<Resource> resourcesTouched;
    private int amountGathered = 0;


    private void Start()
    {
        GetResourcesTouched();
    }


    private void Update()
    {
        if (resourcesTouched.Count != 0)
            GatherResources();
    }


    private void GatherResources()
    {
        foreach (Resource resource in resourcesTouched)
        {
            amountGathered += resource.startingAmount;
        }
        print(amountGathered);
    }


    private void GetResourcesTouched()
    {
        resourcesTouched = new List<Resource>();

        Vector3Int gridPosition = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

        for (int x = -10; x < 10; x++)
        {
            for (int y = -10; y < 10; y++)
            {
                bool isResourcePresent = MapData.Instance.GetResourceAtPoint(new Vector3Int(gridPosition.x + x, gridPosition.y + y, 0), out Resource currResource);
                if (isResourcePresent)
                    resourcesTouched.Add(currResource);
            }
        }

        print(resourcesTouched.Count);
    }
}
