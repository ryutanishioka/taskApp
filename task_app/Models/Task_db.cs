using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.SqlClient;

namespace task_app.Models
{
    public class Task_db : DbContext
    {
        public Task_db()
            : base("name=task_db")
        {
        }

        public bool CreateTask(string name, string description, int priority)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@NAME", name),
                    new SqlParameter("@Description", description ?? (object)DBNull.Value),
                    new SqlParameter("@PRIORITY", priority)
                };

                // Database.ExecuteSqlCommand メソッドを使用して実行
                this.Database.ExecuteSqlCommand(@"EXEC AddTask @NAME, @Description, @PRIORITY", parameters.ToArray());

                return true; // 実行が成功した場合は true を返す
            }
            catch (Exception ex)
            {
                // エラーログを残すか適切なエラーハンドリングを行う
                Console.WriteLine(ex.Message);
                return false; // 実行が失敗した場合は false を返す
            }
        }

        public List<GetTask_Result> GetTask()
        {
            try
            { 
                return this.Database.SqlQuery<GetTask_Result>(@"EXEC GetTask").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool EditTask(int id, string taskName)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id),
                    new SqlParameter("@Description", taskName)
                };

                // Database.ExecuteSqlCommand メソッドを使用して実行
                this.Database.ExecuteSqlCommand(@"EXEC EditTask @ID, @Description", parameters.ToArray());

                return true; // 実行が成功した場合は true を返す
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool DeleteTask(int id)
        {
            try
            {
                SqlParameter parameter = new SqlParameter("@ID", id);
                this.Database.ExecuteSqlCommand(@"EXEC DeleteTask @ID", parameter);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}