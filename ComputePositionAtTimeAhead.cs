// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Determine what position a projectile will be after a certain time, given its current position and velocity.")]
    public class ComputePositionAtTimeAhead : FsmStateAction
    {

	    public FsmVector3 currentPosition;
	    public FsmVector3 velocity;
	    public FsmFloat gravityNegative;
	    public FsmFloat timeAhead;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmVector3 futurePosition;
	    
	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {
		    
		    currentPosition =  null;
		    timeAhead = null;
		    futurePosition = null;
			velocity = null;
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
		    futurePosition.Value = ProjectileHelper.ComputePositionAtTimeAhead(currentPosition.Value, velocity.Value, gravityNegative.Value, timeAhead.Value);
		    
        }

    }
}
