using System;

public class Disaster
{
	//Attributes
	public DateTime StartDate = new DateTime();
	public string Type;//type of disaster
	public double Scale;//Danger scale
	public int PeopleEffected;
	public double Funding;

	//Attributes - these are all % of what they need
	public double CurFood, CurWater, CurMedicine, CurPersonel;
	public double EnRouteFood, EnRouteWater, EnRouteMedicine, EnRoutePersonel;

	public Disaster(
		string inType, double inScale, int inPeopleEffected, double inFunding,
		double inCurFood, double inCurWater, double inCurMedicine, double inCurPersonel,
		double inEnRouteFood, double inEnRouteWater, double inEnRouteMedicine, double inEnRoutePersonel)
	{
        //setting values
        StartDate = DateTime.Now;
		this.Type = inType;
		this.Scale = inScale;
		this.PeopleEffected = inPeopleEffected;
		this.Funding = inFunding;
		this.CurFood = inCurFood;
		this.CurWater = inCurWater;
		this.CurMedicine = inCurMedicine;
		this.CurPersonel = inCurPersonel;
		this.EnRouteFood = inEnRouteFood;
		this.EnRoutePersonel = inEnRoutePersonel;
		this.EnRouteWater = inEnRouteWater;
		this.EnRouteMedicine = inEnRouteMedicine;

	}
}
