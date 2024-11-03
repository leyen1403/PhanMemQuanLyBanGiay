# Đề tài: Hệ thống quản lý cửa hàng giày

## Thành viên nhóm:
| STT | Tên thành viên   | Chức vụ      |
|-----|------------------|--------------|
| 1   | Lê Thanh Yên     | Nhóm trưởng  |
| 2   | Hoàng Đức Quân   | Thành viên   |

## Giới thiệu đề tài

Hệ thống quản lý cửa hàng giày là một giải pháp phần mềm tích hợp giúp quản lý toàn bộ quy trình hoạt động của cửa hàng giày. Mục tiêu của hệ thống là tối ưu hóa việc quản lý sản phẩm, đơn hàng, khách hàng, và báo cáo doanh thu, từ đó nâng cao hiệu quả hoạt động và phục vụ khách hàng tốt hơn.

Hệ thống bao gồm hai phần chính:

1. **Phần mềm quản lý cửa hàng (WinForms):** Đây là phần mềm dành cho nhân viên quản lý cửa hàng, giúp quản lý các chức năng như nhập hàng, quản lý kho, xử lý đơn hàng, và báo cáo doanh thu. Phần mềm này được phát triển trên nền tảng WinForms, cung cấp giao diện dễ sử dụng và khả năng tương tác trực tiếp với cơ sở dữ liệu.

2. **Website bán hàng trực tuyến:** Đây là nền tảng cho phép khách hàng duyệt sản phẩm, đặt hàng và thanh toán trực tuyến. Website cũng cung cấp các tính năng quản lý đơn hàng và báo cáo doanh thu cho quản lý cửa hàng. Phần này được phát triển với công nghệ web hiện đại, đảm bảo khả năng tương thích trên nhiều thiết bị và trình duyệt.

Hệ thống giúp cửa hàng giày duy trì quy trình hoạt động hiệu quả, quản lý hàng tồn kho chính xác, xử lý đơn hàng nhanh chóng, và cung cấp dịch vụ khách hàng tốt hơn. Với giao diện người dùng thân thiện và các chức năng quản lý toàn diện, hệ thống này là công cụ hỗ trợ đắc lực cho mọi cửa hàng giày.


## Công nghệ sử dụng

Hệ thống quản lý cửa hàng giày của chúng tôi được xây dựng trên nền tảng của các công nghệ hiện đại để đảm bảo hiệu quả hoạt động và trải nghiệm người dùng tối ưu. Các công nghệ chính được sử dụng trong dự án bao gồm:

1. **WinForms:** Được sử dụng để phát triển phần mềm quản lý cửa hàng giày dành cho nhân viên. WinForms cung cấp giao diện người dùng thân thiện và khả năng tích hợp mạnh mẽ với cơ sở dữ liệu, giúp quản lý các chức năng như nhập hàng, quản lý kho, xử lý đơn hàng, và báo cáo doanh thu.

2. **SQL Server:** Được sử dụng làm hệ quản trị cơ sở dữ liệu cho hệ thống. SQL Server cung cấp khả năng lưu trữ và quản lý dữ liệu hiệu quả, bảo mật, và hỗ trợ các truy vấn phức tạp, giúp đảm bảo tính toàn vẹn và sẵn sàng của dữ liệu trong hệ thống.

3. **ASP.NET MVC:** Được sử dụng để phát triển website bán hàng trực tuyến. ASP.NET MVC cung cấp cấu trúc mô hình-view-controller mạnh mẽ, giúp xây dựng các ứng dụng web dễ bảo trì, mở rộng, và có khả năng tương tác tốt với người dùng. Phần website cho phép khách hàng duyệt sản phẩm, đặt hàng và thanh toán trực tuyến, đồng thời hỗ trợ quản lý đơn hàng và báo cáo doanh thu cho quản lý cửa hàng.

Các công nghệ này kết hợp với nhau để cung cấp một giải pháp quản lý cửa hàng giày toàn diện, từ việc quản lý nội bộ đến cung cấp dịch vụ bán hàng trực tuyến cho khách hàng.


## Danh sách chức năng Winform

### Phân công công việc

| **Chức năng**                                    | **Hoàng Đức Quân**                               | **Lê Thanh Yên**                                |
|--------------------------------------------------|--------------------------------------------------|------------------------------------------------|
| **1. Quản lý thông tin nhân viên**               | Xem danh sách nhân viên, thêm mới, cập nhật, khóa tài khoản, reset mật khẩu |                                                |
| **2. Quản lý phân quyền cho nhân viên**          |                                                  | Thêm quyền, xóa quyền                          |
| **3. Quản lý danh mục sản phẩm**                 |                                                  | Loại sản phẩm, xuất xứ, thương hiệu, màu sắc: Xem danh sách, thêm mới, chỉnh sửa |
| **4. Quản lý nhà cung cấp**                      | Xem danh sách, thêm mới, cập nhật                |                                                |
| **5. Quản lý khách hàng**                        |                                                  | Xem danh sách khách hàng, thêm mới, cập nhật    |
| **6. Quản lý đơn hàng (hóa đơn)**                | Lập hóa đơn, báo cáo đơn hàng (theo ngày, nhân viên), tính tổng tiền, xuất hóa đơn, xem lịch sử hóa đơn (theo nhân viên, khách hàng) |                                                |
| **7. Quản lý nhập hàng**                         |                                                  | Xem danh sách đơn nhập hàng, thêm mới, xác nhận nhập hàng |
| **8. Quản lý báo cáo kiểm kê**                   | Xem danh sách báo cáo kiểm kê, thêm mới đợt kiểm kê, chỉnh sửa mẫu kiểm kê, xuất báo cáo |                                                |
| **9. Quản lý chương trình khuyến mãi**           |                                                  | Xem danh sách chương trình khuyến mãi, cập nhật chương trình, chi tiết chương trình |
| **10. Báo cáo thu/chi/lợi nhuận**                | Theo dõi thu/chi/lợi nhuận theo ngày, tuần, tháng, quý, năm, xem biểu đồ |                                                |

## AI sử dụng: Nhận dạng hình ảnh sản phẩm (Product Image Recognition)
