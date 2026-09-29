/**********************/
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/**********************/
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Hỗ trợ in tiếng Việt

        // 1. Tạo hai Employee bằng hai constructor khác nhau
        Console.WriteLine("1. Tạo Employee:");
        Employee emp1 = new Employee("E01", "Nguyễn Văn A");
        Employee emp2 = new Employee("E02", "Trần Thị B", 15000000);
        emp1.DisplayInfo();
        emp2.DisplayInfo();

        // 2. Tạo hai Software Engineer bằng hai constructor khác nhau
        Console.WriteLine("\n2. Tạo Software Engineer:");
        SoftwareEngineer se1 = new SoftwareEngineer("SE01", "Lê Văn C", "C#");
        SoftwareEngineer se2 = new SoftwareEngineer("SE02", "Phạm Thị D", 20000000, "Java", 5000000);
        se1.DisplayInfo();
        se2.DisplayInfo();

        // 3. Tăng lương một nhân sự bằng số tiền cố định
        Console.WriteLine("\n3. Tăng lương cố định cho E01 (thêm 2,000,000):");
        emp1.IncreaseSalary(2000000);
        emp1.DisplayInfo();

        // 4. Tăng lương một nhân sự khác theo phần trăm
        Console.WriteLine("\n4. Tăng lương theo 10% cho E02:");
        emp2.IncreaseSalary(10, true);
        emp2.DisplayInfo();

        // 5. Tạo nhóm dự án không có trưởng nhóm
        Console.WriteLine("\n5. Tạo nhóm dự án chưa có trưởng nhóm:");
        ProjectTeam team1 = new ProjectTeam("P01", "Dự án Alpha");
        
        // 6. Thêm một nhân sự vào nhóm bằng addMember(employee)
        Console.WriteLine("\n6. Thêm E01, E02 vào nhóm:");
        team1.AddMember(emp1);
        team1.AddMember(emp2);

        // 7. Thêm một kỹ sư bằng addMember(employee, true) để đặt làm trưởng nhóm
        Console.WriteLine("\n7. Thêm SE02 và chọn làm trưởng nhóm:");
        team1.AddMember(se2, true);

        // 8. Thử thêm lại một thành viên đã tồn tại
        Console.WriteLine("\n8. Thử thêm lại E01:");
        team1.AddMember(emp1); 

        // 9. Hiển thị danh sách bằng lời gọi đa hình
        Console.WriteLine("\n9. Hiển thị danh sách nhóm bằng lời gọi đa hình:");
        team1.DisplayTeam();

        // 10. Tính tổng chi phí nhân sự hằng tháng
        Console.WriteLine("10. Tổng chi phí nhân sự hằng tháng: " + team1.CalculateTotalMonthlyCost());

        // 11. Thử xóa trưởng nhóm hiện tại và kiểm tra thao tác bị từ chối
        Console.WriteLine("\n11. Thử xóa trưởng nhóm hiện tại (SE02):");
        team1.RemoveMember("SE02");

        // 12. Đổi trưởng nhóm rồi xóa người từng là trưởng nhóm
        Console.WriteLine("\n12. Đổi trưởng nhóm thành SE01 và xóa cựu trưởng nhóm SE02:");
        team1.ChangeLeader(se1);
        team1.RemoveMember("SE02");
        team1.DisplayTeam();

        // 13 & 14 & 15. Kiểm thử vòng đời (Destructor và liên kết không sở hữu)
        Console.WriteLine("\n--- KIỂM THỬ VÒNG ĐỜI VÀ KẾT TẬP ---");
        {
            // 13. Tạo một nhóm thứ hai và thêm nhân sự đã có ở nhóm 1
            Console.WriteLine("13. Tạo nhóm Beta trong khối lệnh cục bộ và thêm E01 vào:");
            ProjectTeam team2 = new ProjectTeam("P02", "Dự án Beta");
            team2.AddMember(emp1);
            team2.DisplayTeam();

            // 14. Hủy nhóm thứ hai bằng cách kết thúc khối lệnh cục bộ
            Console.WriteLine("14. Kết thúc khối lệnh. Đang dọn rác (Garbage Collection)...");
            team2 = null; // Gán null để chuẩn bị dọn rác
        }
        
        // Ép C# dọn rác ngay lập tức để mô phỏng giống C++
        GC.Collect();
        GC.WaitForPendingFinalizers(); 

        // 15. Chứng minh nhân sự của nhóm thứ hai vẫn tồn tại sau khi nhóm bị hủy
        Console.WriteLine("\n15. Nhóm Beta đã bị hủy. Kiểm tra xem E01 có còn tồn tại không:");
        emp1.DisplayInfo();
        
        Console.WriteLine("\n[Chương trình kết thúc. Nhấn Enter để thoát]");
        Console.ReadLine();
    }
}