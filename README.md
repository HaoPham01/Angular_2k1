B1: Tạo csdl
B2: Tạo MVC, Cài đặt entity framework
B3: Kết nối csdl. Tạo thư mục data chứa dbcontext
Scaffold-DbContext "Data Source=LAPTOP-AIJ005TR;Initial Catalog=QLSV;Integrated Security=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data -f
Tạo controller
B4: Thêm các validate vào model data
B5: Chỉnh sửa chuyển trang
B6: Chức năng tìm kiếm
B7: Thêm icon, Alert message
B8: pagination 
Install-Package PagedList.Mvc
