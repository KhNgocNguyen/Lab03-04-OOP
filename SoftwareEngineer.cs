/**********************/
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/**********************/
using System;

public class SoftwareEngineer : Employee // Kế thừa
{
    public string PrimaryLanguage { get; private set; }
    public double TechnicalAllowance { get; private set; }

    // Constructor 1
    public SoftwareEngineer(string id, string fullName, string primaryLanguage) 
        : this(id, fullName, 0, primaryLanguage, 0) { }

    // Constructor 2
    public SoftwareEngineer(string id, string fullName, double baseSalary, string primaryLanguage, double technicalAllowance) 
        : base(id, fullName, baseSalary)
    {
        if (string.IsNullOrWhiteSpace(primaryLanguage))
            throw new ArgumentException("Ngôn ngữ chính không rỗng.");
        if (technicalAllowance < 0)
            throw new ArgumentException("Phụ cấp không âm.");

        PrimaryLanguage = primaryLanguage;
        TechnicalAllowance = technicalAllowance;
    }

    // Ghi đè
    public override double CalculateMonthlyCost()
    {
        return BaseSalary + TechnicalAllowance;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {FullName}, Language: {PrimaryLanguage}, Cost: {CalculateMonthlyCost()}");
    }

    ~SoftwareEngineer()
    {
        Console.WriteLine($"[Hủy] Software Engineer {FullName} đã bị hủy.");
    }
}