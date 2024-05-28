using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ateliers.Lectures.InquiryApp.Migrations
{
    public class CustomMigrationsIdGenerator : IMigrationsIdGenerator
    {
        public string GenerateId(string name)
        {
            // 日本時間に変換
            var jstNow = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time"));
            return $"{jstNow:yyyyMMddHHmmss}_{name}";
        }

        public bool IsValidId(string value)
        {
            // 日本時間形式のIDが有効かどうかを確認するロジックを実装
            if (value.Length < 15)
            {
                return false;
            }
            return DateTime.TryParseExact(value.Substring(0, 14), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out _);
        }

        public string GetName(string id)
        {
            // マイグレーションの名前部分を取得
            if (id.Length < 16)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID is too short to contain a valid name.");
            }
            return id.Substring(15);
        }
    }
}
