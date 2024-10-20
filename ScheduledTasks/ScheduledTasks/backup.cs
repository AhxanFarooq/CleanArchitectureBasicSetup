using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduledTasks.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduledTasks.ScheduledTasks
{
    public class backup : IScheduledTask
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public IConfiguration Configuration { get; }

        public string Schedule => "0 1 * * *";

        public backup(IServiceScopeFactory scopeFactory, IConfiguration configuration)
        {
            _scopeFactory = scopeFactory;
            Configuration = configuration;

        }
        public async Task Invoke(CancellationToken cancellationToken)
        {
            // Get the path of the Windows directory
            string windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

            // Extract the drive letter
            string driveLetter = Path.GetPathRoot(windowsPath);
            await BackUpAsync(driveLetter + "temp");
        }
        public async System.Threading.Tasks.Task BackUpAsync(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //string filesToDelete = @"*Backup_*.bak";   // Only delete DOC files containing "DeleteMe" in their filenames
                string[] fileList = System.IO.Directory.GetFiles(path);
                foreach (string file in fileList)
                {
                    var time = File.GetCreationTime(file);
                    if (time < DateTime.Now.AddDays(-6))
                        System.IO.File.Delete(file);
                }
                var datetime = DateTime.UtcNow;

                var backupPath = Path.Combine(path,
                    "Backup_" + datetime.ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss") + ".bak");

                

                using (SqlConnection connection =
                    new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    string commandText =
                        $@"BACKUP DATABASE [{connection.Database}] TO DISK = N'{backupPath}' WITH NOFORMAT, INIT, NAME = N'{connection.Database}-Full Database Backup'"; //, SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                    connection.Open();
                    //connection.InfoMessage += Connection_InfoMessage;
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandType = CommandType.Text;
                        await command.ExecuteNonQueryAsync();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Get the path of the Windows directory
                string windowsPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);

                // Extract the drive letter
                string driveLetter = Path.GetPathRoot(windowsPath);
                await BackUpAsync(driveLetter + "temp");
            }

        }



    }
}
