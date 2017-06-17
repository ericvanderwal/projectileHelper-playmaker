// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Determine the velocity needed to hit a target position in exactly the given amount of time.")]
    public class ComputeVelocityToHitTargetAtTime : FsmStateAction
    {

	    public FsmVector3 startPosition;
	    public FsmVector3 targetPosition;
	    public FsmFloat gravityNegative;
	    public FsmFloat timeToTargetPosition;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmVector3 nessesaryVelocity;
	    
	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {
		    
		    startPosition = null;
		    targetPosition = null;
		    timeToTargetPosition = null;
		    nessesaryVelocity = null;
		    gravityNegative = null;
			everyFrame = false;

	    }


	    public override void OnEnter()
	    {

		    if (!everyFrame.Value)
		    {
			    doCalculations();
			    Finish();
		    }
		    
	    }
	    
	    
	    public override void OnUpdate()
	    {
		    if (everyFrame.Value)
		    {
			    doCalculations();
		    }
	    }
	    
	   
	    void doCalculations()
	    
	    {
		    nessesaryVelocity.Value = ProjectileHelper.ComputeVelocityToHitTargetAtTime(startPosition.Value, targetPosition.Value, gravityNegative.Value, timeToTargetPosition.Value);
		    
        }

    }
}
