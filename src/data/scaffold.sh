#!/bin/bash

dotnet ef dbcontext scaffold "Server=localhost,1440;Database=librarium-real;User Id=sa;Password=SuperSecret7!;TrustServerCertificate=True;" \
  Microsoft.EntityFrameworkCore.SqlServer \
  --output-dir Entities \
  --context-dir Database \
  --context AppDbContext \
  --no-onconfiguring \
  --force