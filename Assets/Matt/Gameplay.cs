using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

	AnimationController animCont;
	int bottle1Stage;
	int bottle2Stage;
	int bottle3Stage;
	int bottle4Stage;
	int bottle5Stage;
	int bottle6Stage;
	int shakerStage;

	// Use this for initialization
	void Start () {
		animCont = GameObject.FindGameObjectWithTag ("AnimationController").GetComponent <AnimationController>();
	}
	
	// Update is called once per frame
	void Update () {
		KeyboardControls ();
	}

	void KeyboardControls(){
		Bottles ();
		Shaker ();
		Glass ();

	}

	void Bottles(){
		if (animCont.Glass.GetBool ("Playing") == true) {
			if (animCont.Bottle1.GetBool ("Lifted") == true) {
				FuncBot1 ();
			} else if (animCont.Bottle2.GetBool ("Lifted") == true) {
				FuncBot2 ();
			} else if (animCont.Bottle3.GetBool ("Lifted") == true) {
				FuncBot3 ();
			} else if (animCont.Bottle4.GetBool ("Lifted") == true) {
				FuncBot4 ();
			} else if (animCont.Bottle5.GetBool ("Lifted") == true) {
				FuncBot5 ();
			} else if (animCont.Bottle6.GetBool ("Lifted") == true) {
				FuncBot6 ();
			} else {
				FuncBot1 ();
				FuncBot2 ();
				FuncBot3 ();
				FuncBot4 ();
				FuncBot5 ();
				FuncBot6 ();		
			}
		}
	}

	void FuncBot1(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (bottle1Stage == 0) { 
				bottle1Stage++;
				animCont.Bottle1.SetBool ("Lifted", true);
				animCont.Bottle1.SetInteger ("Stage", bottle1Stage);
			} else 	if (bottle1Stage == 1) { 
				bottle1Stage++;
				animCont.Bottle1.SetInteger ("Stage", bottle1Stage);
			} else 	if (bottle1Stage == 2) { 
				bottle1Stage++;
				animCont.Bottle1.SetInteger ("Stage", bottle1Stage);
			} else 	if (bottle1Stage == 3) { 
				bottle1Stage++;
				animCont.Bottle1.SetBool ("Lifted", false);
				animCont.Bottle1.SetInteger ("Stage", bottle1Stage);
			} else 	if (bottle1Stage == 4) { 
				bottle1Stage = 1;
				animCont.Bottle1.SetInteger ("Stage", bottle1Stage);
			} 
		}
	}

	void FuncBot2(){
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (bottle2Stage == 0) { 
				bottle2Stage++;
				animCont.Bottle2.SetBool ("Lifted", true);
				animCont.Bottle2.SetInteger ("Stage", bottle2Stage);
			} else 	if (bottle2Stage == 1) { 
				bottle2Stage++;
				animCont.Bottle2.SetInteger ("Stage", bottle2Stage);
			} else 	if (bottle2Stage == 2) {
				bottle2Stage++;
				animCont.Bottle2.SetInteger ("Stage", bottle2Stage);
			} else 	if (bottle2Stage == 3) { 
				bottle2Stage++;
				animCont.Bottle2.SetBool ("Lifted", false);
				animCont.Bottle2.SetInteger ("Stage", bottle2Stage);
			} else 	if (bottle2Stage == 4) { 
				bottle2Stage = 1;
				animCont.Bottle2.SetInteger ("Stage", bottle2Stage);
			} 
		}
	}

	void FuncBot3(){
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if (bottle3Stage == 0) { 
				bottle3Stage++;
				animCont.Bottle3.SetBool ("Lifted", true);
				animCont.Bottle3.SetInteger ("Stage", bottle3Stage);
			} else 	if (bottle3Stage == 1) { 
				bottle3Stage++;
				animCont.Bottle3.SetInteger ("Stage", bottle3Stage);
			} else 	if (bottle3Stage == 2) { 
				bottle3Stage++;
				animCont.Bottle3.SetInteger ("Stage", bottle3Stage);
			} else 	if (bottle3Stage == 3) { 
				bottle3Stage++;
				animCont.Bottle3.SetBool ("Lifted", false);
				animCont.Bottle3.SetInteger ("Stage", bottle3Stage);
			} else 	if (bottle3Stage == 4) { 
				bottle3Stage = 1;
				animCont.Bottle3.SetInteger ("Stage", bottle3Stage);
			} 
		}
	}

	void FuncBot4(){
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			if (bottle4Stage == 0) { 
				bottle4Stage++;
				animCont.Bottle4.SetBool ("Lifted", true);
				animCont.Bottle4.SetInteger ("Stage", bottle4Stage);
			} else 	if (bottle4Stage == 1) { 
				bottle4Stage++;
				animCont.Bottle4.SetInteger ("Stage", bottle4Stage);
			} else 	if (bottle4Stage == 2) { 
				bottle4Stage++;
				animCont.Bottle4.SetInteger ("Stage", bottle4Stage);
			} else 	if (bottle4Stage == 3) { 
				bottle4Stage++;
				animCont.Bottle4.SetBool ("Lifted", false);
				animCont.Bottle4.SetInteger ("Stage", bottle4Stage);
			} else 	if (bottle4Stage == 4) { 
				bottle4Stage = 1;
				animCont.Bottle4.SetInteger ("Stage", bottle4Stage);
			} 
		}
	}

	void FuncBot5(){
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			if (bottle5Stage == 0) { 
				bottle5Stage++;
				animCont.Bottle5.SetBool ("Lifted", true);
				animCont.Bottle5.SetInteger ("Stage", bottle5Stage);
			} else 	if (bottle5Stage == 1) { 
				bottle5Stage++;
				animCont.Bottle5.SetInteger ("Stage", bottle5Stage);
			} else 	if (bottle5Stage == 2) { 
				bottle5Stage++;
				animCont.Bottle5.SetInteger ("Stage", bottle5Stage);
			} else 	if (bottle5Stage == 3) { 
				bottle5Stage++;		
				animCont.Bottle5.SetBool ("Lifted", false);
				animCont.Bottle5.SetInteger ("Stage", bottle5Stage);
			} else 	if (bottle5Stage == 4) { 
				bottle5Stage = 1;
				animCont.Bottle5.SetInteger ("Stage", bottle5Stage);
			} 
		}
	}

	void FuncBot6(){
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			if (bottle6Stage == 0) { 
				bottle6Stage++;
				animCont.Bottle6.SetBool ("Lifted", true);
				animCont.Bottle6.SetInteger ("Stage", bottle6Stage);
			} else 	if (bottle6Stage == 1) { 
				bottle6Stage++;
				animCont.Bottle6.SetInteger ("Stage", bottle6Stage);
			} else 	if (bottle6Stage == 2) { 
				bottle6Stage++;
				animCont.Bottle6.SetInteger ("Stage", bottle6Stage);
			} else 	if (bottle6Stage == 3) { 
				bottle6Stage++;
				animCont.Bottle6.SetBool ("Lifted", false);
				animCont.Bottle6.SetInteger ("Stage", bottle6Stage);
			} else 	if (bottle6Stage == 4) { 
				bottle6Stage = 1;
				animCont.Bottle6.SetInteger ("Stage", bottle6Stage);
			} 
		}
	}

	void Shaker(){
		if (Input.GetKeyDown (KeyCode.S)) {
			if (shakerStage == 0) { 
				animCont.Shaker.SetInteger ("Stage", shakerStage);
				shakerStage++;
			} else if (shakerStage == 1) { 
				animCont.Shaker.SetInteger ("Stage", shakerStage);
				shakerStage++;
			} else if (shakerStage == 2) { 
				animCont.Shaker.SetInteger ("Stage", shakerStage);
				shakerStage++;
			} else if (shakerStage == 3) { 
				animCont.Shaker.SetInteger ("Stage", shakerStage);
				shakerStage++;
			} else if (shakerStage == 4) { 
				animCont.Shaker.SetInteger ("Stage", shakerStage);
				shakerStage = 0;
			} 
		}
	}

	void Glass(){
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			animCont.Glass.SetBool ("Playing", true);
		} else if (Input.GetKeyDown (KeyCode.RightShift)) {
			animCont.Glass.SetBool ("Playing", false);
		}
	}
}
