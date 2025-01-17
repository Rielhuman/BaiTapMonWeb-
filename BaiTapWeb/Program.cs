using System;
using System.Text; // Thêm namespace để thiết lập mã hóa
using Newtonsoft.Json; // Thư viện để làm việc với JSON

namespace CircleCalculator
{
    class Program
    {
        // Hàm tính toán và trả về chuỗi JSON
        static string TinhToan(double r)
        {
            double dienTich = Math.PI * r * r;
            double chuVi = 2 * Math.PI * r;
            double duongKinh = 2 * r;

            // Tạo object để serialize thành JSON
            var ketQua = new
            {
                dien_tich = Math.Round(dienTich, 2),
                chu_vi = Math.Round(chuVi, 2),
                duong_kinh = Math.Round(duongKinh, 2)
            };

            // Chuyển object sang JSON string
            return JsonConvert.SerializeObject(ketQua);
        }

        static void Main(string[] args)
        {
            // Thiết lập mã hóa UTF-8 cho Console để hỗ trợ tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;

            double r;
            Console.WriteLine("Chương trình tính toán hình tròn");

            while (true)
            {
                Console.Write("Nhập bán kính r (số dương): ");
                string input = Console.ReadLine();

                // Kiểm tra và chuyển đổi input thành số double
                if (double.TryParse(input, out r) && r > 0)
                {
                    break; // Thoát vòng lặp khi nhập đúng
                }

                Console.WriteLine("Vui lòng nhập một số dương hợp lệ!");
            }

            // Gọi hàm và hiển thị kết quả
            string ketQuaJson = TinhToan(r);
            Console.WriteLine("Kết quả (dạng JSON):");
            Console.WriteLine(ketQuaJson);

            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
