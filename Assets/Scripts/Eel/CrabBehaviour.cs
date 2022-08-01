using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Crab))]
public class CrabBehaviour : MonoBehaviour
{
    public Crab crab { get; private set; }
    public float duration;
    private void Awake()
    {
        this.crab = GetComponent<Crab>();
        this.enabled = false;
    }
    public void Enable()
    {
        Enable(this.duration);
    }
    public virtual void Enable(float duration)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }
    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke();
    }
}
