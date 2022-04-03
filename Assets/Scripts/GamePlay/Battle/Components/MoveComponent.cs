using System;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;
    private Action callback;

    private GenericGrid<GroundBlock> grid;

    public void Construct(GenericGrid<GroundBlock> grid)
    {
        this.grid = grid;
    }

    void Start()
    {
        startPosition = target = transform.position;
    }
    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
    }
    public void SetDestination(Vector2 destination, float time, Action callback)
    {
        this.callback = callback;
        var dest = new Vector3(destination.x, destination.y, transform.position.z);
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = dest;

        grid.GetGridObject(startPosition).Item = null;
        grid.GetGridObject(target).Item = gameObject.GetComponent<ItemComponent>();
        Invoke("InvokeCallback", time);
    }

    private void InvokeCallback()
    {
        var callback = this.callback;
        this.callback = null;
        callback?.Invoke();
    }
}
