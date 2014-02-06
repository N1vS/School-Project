using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Worker
/// </summary>
public class Worker
{

    private int workerID, centerID, phone, cityID;
    private string workerName;

	public Worker()
	{

	}

    public Worker(int WorkerID, int CenterID, int Phone, int CityID, string WorkerName)
    {
        this.workerID = WorkerID;
        this.centerID = CenterID;
        this.phone = Phone;
        this.cityID = CityID;
        this.workerName = WorkerName;
    }

    #region Properties
    public int GetWorkerID() { return this.workerID; }
    public void SetWorkerID(int CenterID) { this.workerID = CenterID; }

    public int GetCenterID() { return this.centerID; }
    public void SetCenterID(int CenterID) { this.centerID = CenterID; }

    public int GetPhoneNumber() { return this.phone; }
    public void SetPhoneNumber(int number) { this.phone = number; }

    public int GetCityID() { return this.cityID; }
    public void SetCityID(int CityID) { this.cityID = CityID; }

    public string GetWorkerName() { return this.workerName; }
    public void SetWorkerName(string Name) { this.workerName = Name; }
    #endregion

}