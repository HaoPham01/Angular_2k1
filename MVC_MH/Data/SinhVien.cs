using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_MH.Data;

public partial class SinhVien
{
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Mã sv phải có 8 ký tự")]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [Display(Name = "Mã SV")]
    public string MaSv { get; set; } = null!;

    [StringLength(200)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [Display(Name = "Họ và Tên")]
    public string HoTen { get; set; } = null!;

    [Required(ErrorMessage = "Phải nhập {0}")]
    [Display(Name = "Ngày - Tháng - Năm Sinh")]
    public DateOnly? NamSinh { get; set; }

    [StringLength(200)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [Display(Name = "Địa chỉ")]
    public string? DiaChi { get; set; }

    [StringLength(200)]
    [Required(ErrorMessage = "Phải nhập {0}")]
    [EmailAddress(ErrorMessage = "Địa chỉ email phải hợp lệ {0}")]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Phải nhập {0}")]
    [RegularExpression(@"^\d+$",
    ErrorMessage = "Phải nhập số")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại có 10 số")]
    [Display(Name = "Số điện thoại")]
    public string? Sdt { get; set; }
}
