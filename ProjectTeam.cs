 /**********************/
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/**********************/
using System;
using System.Collections.Generic;
using System.Linq;

public class ProjectTeam
{
    // Thuộc tính
    public string ProjectCode { get; private set; }
    public string ProjectName { get; private set; }
    
    // Liên kết không sở hữu đến trưởng nhóm và các thành viên
    public Employee Leader { get; private set; }
    private List<Employee> Members;

    // Nạp chồng constructor 1: Chưa có trưởng nhóm
    public ProjectTeam(string projectCode, string projectName)
    {
        ProjectCode = projectCode;
        ProjectName = projectName;
        Members = new List<Employee>();
    }

    // Nạp chồng constructor 2: Có trưởng nhóm
    public ProjectTeam(string projectCode, string projectName, Employee leader) 
        : this(projectCode, projectName)
    {
        AddMember(leader, true); // Tự động đưa trưởng nhóm vào danh sách
    }

    // Kiểm tra thành viên đã tồn tại chưa
    public bool Contains(string employeeId)
    {
        return Members.Any(e => e.Id == employeeId);
    }

    // Nạp chồng addMember 1: Thêm thành viên bình thường
    public bool AddMember(Employee employee)
    {
        if (Contains(employee.Id))
        {
            Console.WriteLine($"[Cảnh báo] Nhân sự {employee.Id} đã tồn tại trong nhóm.");
            return false; // Không thêm trùng nhân sự
        }
        Members.Add(employee);
        return true;
    }

    // Nạp chồng addMember 2: Thêm thành viên và xét làm trưởng nhóm
    public bool AddMember(Employee employee, bool makeLeader)
    {
        bool added = AddMember(employee);
        if (makeLeader)
        {
            // Trưởng nhóm cũ vẫn là thành viên, chỉ thay đổi liên kết Leader[cite: 1]
            Leader = employee; 
        }
        return added || (makeLeader && Contains(employee.Id));
    }

    // Xóa thành viên
    public void RemoveMember(string employeeId)
    {
        if (Leader != null && Leader.Id == employeeId)
        {
            Console.WriteLine("[Lỗi] Không được xóa trưởng nhóm khi chưa chọn trưởng nhóm thay thế.");
            return;
        }

        var emp = Members.FirstOrDefault(e => e.Id == employeeId);
        if (emp != null)
        {
            Members.Remove(emp);
            Console.WriteLine($"Đã xóa nhân sự {employeeId} khỏi nhóm.");
        }
    }

    // Đổi trưởng nhóm
    public void ChangeLeader(Employee newLeader)
    {
        if (!Contains(newLeader.Id))
        {
            AddMember(newLeader); // Thêm vào nhóm nếu chưa phải thành viên[cite: 1]
        }
        Leader = newLeader;
        Console.WriteLine($"Đã đổi trưởng nhóm thành: {newLeader.FullName}");
    }

    // Tính tổng chi phí
    public double CalculateTotalMonthlyCost()
    {
        return Members.Sum(e => e.CalculateMonthlyCost());
    }

    // Hiển thị nhóm
    public void DisplayTeam()
    {
        Console.WriteLine($"\n--- Dự án: {ProjectName} ({ProjectCode}) ---");
        Console.WriteLine($"Trưởng nhóm: {(Leader != null ? Leader.FullName : "Chưa có")}");
        Console.WriteLine($"Số lượng thành viên: {Members.Count}");
        Console.WriteLine("Danh sách thành viên:");
        foreach (var member in Members)
        {
            member.DisplayInfo(); // Lời gọi đa hình[cite: 1]
        }
        Console.WriteLine("----------------------------------\n");
    }

    // Destructor (Chỉ hủy cấu trúc danh sách liên kết, không hủy Employee)
    ~ProjectTeam()
    {
        Members.Clear();
        Console.WriteLine($"[Hủy] Cấu trúc nhóm dự án {ProjectName} đã bị dọn dẹp.");
    }
}