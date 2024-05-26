using Godot;
using System;
using System.Collections.Generic;

public partial class base_button_scene : Node2D
{
	private static List<base_button_scene> baseList;//initialise list

	public override void _Ready()
	{
		baseList = baseListClass.GetBaseList();//get list from baseListClass
	}

	public override void _Process(double delta)
	{
	}

	private void _on_base_button_pressed()
	{
		int index = baseList.IndexOf(this);//find index of current button

		buttonIndex.SetIndex(index);//save index so can change scene

		foreach (var baseButton in baseList)//hide buttons
		{
			baseButton.Visible = false;
		}
		GetTree().ChangeSceneToFile("res://logistics_view.tscn");//change scene
	}
}



