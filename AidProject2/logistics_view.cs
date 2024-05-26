using Godot;
using System;
using System.Collections.Generic;

public partial class logistics_view : Node2D
{
	private static List<Disaster> disasterList = new List<Disaster>();//to store all disasters
	private static int indexOfButton;
	private static Disaster disasterToView;
	
	public override void _Ready()
	{
		disasterList = disasterListClass.GetDisasterList();//get disasterList
		indexOfButton = buttonIndex.GetButtonIndex();//get index

		disasterToView = disasterList[indexOfButton];

		displayData();
	}

	public override void _Process(double delta)
	{
	}

	public void displayData()
	{
		GetNode<Label>("DateLabel").Text += disasterToView.StartDate.ToString("yyyy-MM-dd");
		GetNode<Label>("TypeLabel").Text += disasterToView.Type;
		GetNode<Label>("ScaleLabel").Text += disasterToView.Scale.ToString();
		GetNode<Label>("PeopleLabel").Text += disasterToView.PeopleEffected.ToString();
		GetNode<Label>("FundingLabel").Text += disasterToView.Funding.ToString("C");
		GetNode<Label>("CurFoodLabel").Text += disasterToView.CurFood.ToString("P0");
		GetNode<Label>("CurWaterLabel").Text += disasterToView.CurWater.ToString("P0");
		GetNode<Label>("CurMedicineLabel").Text += disasterToView.CurMedicine.ToString("P0");
		GetNode<Label>("CurPersonelLabel").Text += disasterToView.CurPersonel.ToString("P0");
		GetNode<Label>("EnRouteFoodLabel").Text += disasterToView.EnRouteFood.ToString("P0");
		GetNode<Label>("EnRouteWaterLabel").Text += disasterToView.EnRouteWater.ToString("P0");
		GetNode<Label>("EnRouteMedicineLabel").Text += disasterToView.EnRouteMedicine.ToString("P0");
		GetNode<Label>("EnRoutePersonelLabel").Text += disasterToView.EnRoutePersonel.ToString("P0");
	}

	private void _on_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://main.tscn");
	}

}
