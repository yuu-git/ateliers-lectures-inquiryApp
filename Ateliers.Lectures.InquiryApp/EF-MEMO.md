
## テーブルの作成

```
dotnet ef migrations add CreateUserTable --context ApplicationDbContext --project ./Ateliers.Lectures.InquiryApp/Ateliers.Lectures.InquiryApp.csproj
```

```
dotnet ef migrations add InitialCreate --context InquiryDbContext --project ./Ateliers.Lectures.InquiryApp/Ateliers.Lectures.InquiryApp.csproj
```

## マイグレーションの実行

```
dotnet ef database update --context ApplicationDbContext --project ./Ateliers.Lectures.InquiryApp/Ateliers.Lectures.InquiryApp.csproj
```

```
dotnet ef database update --context InquiryDbContext --project ./Ateliers.Lectures.InquiryApp/Ateliers.Lectures.InquiryApp.csproj
```
