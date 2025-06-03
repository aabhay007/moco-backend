##Command for scaffolding
#dotnet ef dbcontext scaffold "Name=DefaultConnection" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --context-dir Data --context NeonDbContext --force
#dotnet ef dbcontext scaffold "Name=DefaultConnection" Npgsql.EntityFrameworkCore.PostgreSQL \
  --output-dir Domain/Entities \
  --context-dir Infrastructure/Data \
  --context NeonDbContext \
  --force
