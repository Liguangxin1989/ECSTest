using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _system;

	// Use this for initialization
	void Start () {
        var contexts = Contexts.sharedInstance;
        _system = new Feature("Systems")
            .Add(new TutorialSystems(contexts));
        _system.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        _system.Execute();

        _system.Cleanup();
	}
}
