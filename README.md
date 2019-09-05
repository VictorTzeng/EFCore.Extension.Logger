# EFCore.Extension.Logger 
输出EF Core生成的SQL语句到控制台。A library outputing EFCore's SQL to the console.

# How to use

1. Install the package from nuget:

   ```
   Install-Package EFCore.Extension.Logger -Version 1.0.0
   ```

2. Override the method **OnConfiguring** in your DbContext class file:

```C#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseEFCoreLogger();
    base.OnConfiguring(optionsBuilder);
}
```
