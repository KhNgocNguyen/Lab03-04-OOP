/**********************/
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/**********************/
using System;

public class Employee
{
    // Thuộc tính
    public string Id { get; protected set; }
    public string FullName { get; protected set; }
    public double BaseSalary { get; protected set; }

    // Constructor 1
    public Employee() : this("UNKNOWN", "Unnamed employee", 0) { }

    // Constructor 2
    public Employee(string id, string fullName) : this(id, fullName, 0) { }

    // Constructor 3
    public Employee(string id, string fullName, double baseSalary)
    {
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Mã và họ tên không được rỗng.");
        if (baseSalary < 0)
            throw new ArgumentException("Lương cơ bản không âm.");
            
        Id = id;
        FullName = fullName;
        BaseSalary = baseSalary;
    }

    // Nạp chồng phương thức tăng lương
    public void IncreaseSalary(double amount)
    {
        if (amount > 0) BaseSalary += amount;
    }

    public void IncreaseSalary(double value, bool byPercentage)
    {
        if (value <= 0) return;
        if (byPercentage)
            BaseSalary += BaseSalary * (value / 100);
        else
            BaseSalary += value;
    }

    // Phương thức virtual
    public virtual double CalculateMonthlyCost()
    {
        return BaseSalary;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {FullName}, Salary: {BaseSalary}");
    }

    // Destructor quan sát vòng đời
    ~Employee()
    {
        Console.WriteLine($"[Hủy] Employee {FullName} đã bị hủy.");
    }
}