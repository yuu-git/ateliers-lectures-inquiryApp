var builder = WebApplication.CreateBuilder(args);

var opt = new DefaultFilesOptions();
opt.DefaultFileNames.Clear();
opt.DefaultFileNames.Add("index.html");

var app = builder.Build();
app.UseDefaultFiles(opt);
app.UseStaticFiles();

app.Run();
