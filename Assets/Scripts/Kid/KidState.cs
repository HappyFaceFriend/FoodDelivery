using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidState : StateBase
{
    public KidBehaviour Kid { get; private set; }
    protected Transform transform { get { return Kid.transform; } }
    protected PlayerBehaviour Player { get { return Kid.Player; } }
    public KidState(string name, KidBehaviour kid) : base(name, kid)
    {
        Kid = kid;
    }
}
