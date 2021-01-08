using System.Collections.Generic;
using UnityEngine;

public class GatheringBuildingBehaviour : ConstructionBehavoiur
{
    private List<Resource> _resourcesTouched;
    private int _amountGathered = 0;


    private void Start()
    {
        GetResourcesTouched();
    }


    private void Update()
    {
        if (_resourcesTouched.Count != 0)
            GatherResources();
    }


    private void GatherResources()
    {
        foreach (Resource resource in _resourcesTouched)
        {
            _amountGathered += resource.startingAmount;
        }
        print(_amountGathered);
    }


    private void GetResourcesTouched()
    {
        _resourcesTouched = new List<Resource>();

        Vector3Int gridPosition = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

        for (int x = -10; x < 10; x++)
        {
            for (int y = -10; y < 10; y++)
            {
                bool isResourcePresent = MapData.Instance.GetResourceAtPoint(new Vector3Int(gridPosition.x + x, gridPosition.y + y, 0), out Resource currResource);
                if (isResourcePresent)
                    _resourcesTouched.Add(currResource);
            }
        }

        print(_resourcesTouched.Count);
    }
}
