// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;

// namespace PomoControl.Infraestructure.Context
// {
//     public class PomoContextFactory : IDesignTimeDbContextFactory<PomoContext>
//     {
//         public PomoContext CreateDbContext(string[] args)
//         {
//             var optionsBuilder = new DbContextOptionsBuilder<PomoContext>();
//             optionsBuilder.UseSqlServer("Data Source=HENRIQUE-NOT\\SQL2014;Initial Catalog=PomoControl;Integrated Security=False;Persist Security Info=False;User ID=SA; Password=123456;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
//             //optionsBuilder.UseSqlServer("Data Source=172.17.0.2,1433;Initial Catalog=PomoControl;Integrated Security=False;Persist Security Info=False;User ID=SA; Password=pixe2008;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
//             //optionsBuilder.UseSqlServer(@"Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=PomoControl2;Data Source=HENRIQUE-NOT\SQL2014");

//             return new PomoContext(optionsBuilder.Options);
//         }
//     }
// }