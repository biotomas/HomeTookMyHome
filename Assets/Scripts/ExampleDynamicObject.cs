using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDynamicObject : ObjectHandler {
	
	public override void HandleAction()
	{
		print("action!!!");
	}

	public override void HandleTrigger(GameObject other)
	{
        print("example object trigger with " + other.name);
	}

	public override void HandleDrag()
	{
        //print("example object is being dragged!");
	}

	public override void HandleInvestigate()
	{
		print("example object I N V E S T I G A T E D");
	}

}
