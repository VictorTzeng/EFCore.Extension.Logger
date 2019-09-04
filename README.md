# EFCore.Extension.Logger 
## 输出EF Core生成的SQL语句到控制台。A library outputing EFCore's SQL to the console.

# How to use

Override the method **OnConfiguring** in your DbContext class file:
```C#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseEFCoreLogger();
    base.OnConfiguring(optionsBuilder);
}
```
