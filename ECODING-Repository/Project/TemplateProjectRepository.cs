using ECODING_DAL;
using ECODING_WebApiProject.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ECODING_Repository.Project
{
    public class TemplateProjectRepository: ITemplateProjectRepository
    {
        
        public TemplateProjectRepository() 
        {
            
        }

        public List<TemplateProject> GetAllTemplateProject()
        {
                List<TemplateProject> listeProjects = new List<TemplateProject>();
                string StoredProcedureName = "GetAllTemplateProject";
                System.Data.CommandType type = System.Data.CommandType.StoredProcedure;
                try
                {
                    using (var reader = SqlHelper.ExecuteReader(StoredProcedureName, type, null))
                    {
                        while (reader.Read())
                        {
                            TemplateProject project = new TemplateProject();
                            project.TemplateProjectId = (int)reader["TemplateProjectId"];
                            project.TemplateProjectName = reader["TemplateProjectName"].ToString();
                            project.TemplateProjectTitle = reader["TemplateProjectTitle"].ToString();
                            project.TemplateProjectDescription = reader["TemplateProjectDescription"].ToString();
                            project.TemplateProjectVersion = reader["TemplateProjectVersion"].ToString();
                            project.TemplateProjectVersionNet = reader["TemplateProjectVersionNet"].ToString();
                            listeProjects.Add(project);
                        }
                    }
                }
                finally
                {
                    SqlHelper.CloseConnection();
                }
                return listeProjects;
        }

        public TemplateProject GetTemplateProjectById(int id)
        {
            TemplateProject project = new TemplateProject();
            string StoredProcedureName = "GetTemplateProjectById";
            CommandType type = CommandType.StoredProcedure;
            SqlParameter templateProjectId = new SqlParameter();
            templateProjectId.ParameterName = "@templateProjectId";
            templateProjectId.Direction = ParameterDirection.Input;
            templateProjectId.Value = id;
            templateProjectId.SqlDbType = SqlDbType.Int;
            try
            {
                using (var reader = SqlHelper.ExecuteReader(StoredProcedureName, type, templateProjectId))
                {
                    while (reader.Read())
                    {
                        
                        project.TemplateProjectId = (int)reader["TemplateProjectId"];
                        project.TemplateProjectName = reader["TemplateProjectName"].ToString();
                        project.TemplateProjectTitle = reader["TemplateProjectTitle"].ToString();
                        project.TemplateProjectDescription = reader["TemplateProjectDescription"].ToString();
                        project.TemplateProjectVersion = reader["TemplateProjectVersion"].ToString();
                        project.TemplateProjectVersionNet = reader["TemplateProjectVersionNet"].ToString();
                    }
                }
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
            return project;
        }
    }
}
