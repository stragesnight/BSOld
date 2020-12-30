using UnityEngine;

public class GatheringBuildingBehaviour : MonoBehaviour
{
    public ConstructionSO type;
    float timer = 0f;


    void Start()
    {
        type = Resources.Load<GatheringBuildingSO>("Buildings/BuildingSO/GatheringBuildingTest.asset");
    }


    void Update()
    {
        timer += Time.deltaTime;
        //print(timer);
    }
}
