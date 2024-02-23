using docker_sql.Models;
using Microsoft.EntityFrameworkCore;

namespace docker_sql
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
        public DbSet<KhachHangModel> tblKhachHang { get; set; }
    }
}
