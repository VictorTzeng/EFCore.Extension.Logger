[![Build Status](https://dev.azure.com/v-xiaze0473/v-xiaze/_apis/build/status/VictorTzeng.EFCore.Extension.Logger?branchName=master)](https://dev.azure.com/v-xiaze0473/v-xiaze/_build/latest?definitionId=4&branchName=master)

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
