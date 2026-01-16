using System;

public interface IBillable 
{
    int CostForDay(int hoursWorked);
}
public abstract class Employee : IBillable
{
    public int Id;
    public string Name;

    protected Employee(int id,string name)
    {
        Id = id;
        Name = name;
    }
public abstract int CostForDay(int hoursWorked);
}
public class FullTimeEmployee : Employee
{
    private const int HourlyWage = 1250;
    private const double OvertimeRate = 1.25;
    private const int RegularHours = 8;

    public FullTimeEmployee(int id, string name) : base(id, name)
    {
    }
    public override int CostForDay(int hoursWorked)
    {
        int regularHours = Math.Min(hoursWorked, RegularHours);
        int overtimeHours = Math.Max(0, hoursWorked - RegularHours);
        double cost = regularHours * HourlyWage + overtimeHours * HourlyWage * OvertimeRate;

        return (int)cost;
    }
}
public class ContractEmployee : Employee
{ 
    private const int HouryWage = 1000;

    public ContractEmployee(int id, string name) : base(id, name) 
    {
    }


    public override int CostForDay(int hoursWorked)
    {
        return hoursWorked * HouryWage;
    }
}
class Program
{
    static void Main()
    {

        int hoursWorked = 9;

        List<IBillable> employees = new List<IBillable>
        {
            new FullTimeEmployee(1, "山田太郎"),
            new ContractEmployee(2, "佐藤花子")
        };

        foreach (var item in employees)
        {
            int wage = item.CostForDay(hoursWorked);
            Console.WriteLine($"日給: {wage}円");
        }
    }
}




