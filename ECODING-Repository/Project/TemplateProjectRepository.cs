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
        { }

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

        public void UpdateTemplateProject(TemplateProject templateProject)
        {
            TemplateProject project = new TemplateProject();
            string StoredProcedureName = "UpdateTemplateProject";
            CommandType type = CommandType.StoredProcedure;
            List<SqlParameter> listeParameters = ListeParameter(true,templateProject);
            try
            {
                int retour = SqlHelper.ExecuteNonQuery(StoredProcedureName, type, listeParameters.ToArray());
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        public void CreateTemplateProject(TemplateProject templateProject)
        {
            TemplateProject project = new TemplateProject();
            string StoredProcedureName = "CreateTemplateProject";
            CommandType type = CommandType.StoredProcedure;
            List<SqlParameter> listeParameters = ListeParameter(false,templateProject);
            try
            {
                int retour = SqlHelper.ExecuteNonQuery(StoredProcedureName, type, listeParameters.ToArray());
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        public void DeleteTemplateProject(int id)
        {
            TemplateProject project = new TemplateProject();
            string StoredProcedureName = "DeleteTemplateProject";
            CommandType type = CommandType.StoredProcedure;
            SqlParameter templateProjectId = new SqlParameter();
            templateProjectId.ParameterName = "@templateProjectId";
            templateProjectId.Direction = ParameterDirection.Input;
            templateProjectId.Value = id;
            templateProjectId.SqlDbType = SqlDbType.Int;
            try
            {
                int retour = SqlHelper.ExecuteNonQuery(StoredProcedureName, type, templateProjectId);
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }

        public List<SqlParameter> ListeParameter(bool primaryKey,TemplateProject templateProject)
        {
            List<SqlParameter> listeParameters = new List<SqlParameter>();

            /*TemplateProjectId*/
            if(primaryKey)
            { 
                SqlParameter templateProjectId = new SqlParameter();
                templateProjectId.ParameterName = "@templateProjectId";
                templateProjectId.Direction = ParameterDirection.Input;
                templateProjectId.Value = templateProject.TemplateProjectId;
                templateProjectId.SqlDbType = SqlDbType.Int;
                listeParameters.Add(templateProjectId);
            }

            /*TemplateProjectName*/
            SqlParameter templateProjectName = new SqlParameter();
            templateProjectName.ParameterName = "@templateProjectName";
            templateProjectName.Direction = ParameterDirection.Input;
            templateProjectName.Value = templateProject.TemplateProjectName;
            templateProjectName.SqlDbType = SqlDbType.NVarChar;
            listeParameters.Add(templateProjectName);

            /*TemplateProjectTitle*/
            SqlParameter templateProjectTitle = new SqlParameter();
            templateProjectTitle.ParameterName = "@templateProjectTitle";
            templateProjectTitle.Direction = ParameterDirection.Input;
            templateProjectTitle.Value = templateProject.TemplateProjectTitle;
            templateProjectTitle.SqlDbType = SqlDbType.NVarChar;
            listeParameters.Add(templateProjectTitle);

            /*TemplateProjectDescription*/
            SqlParameter templateProjectDescription = new SqlParameter();
            templateProjectDescription.ParameterName = "@templateProjectDescription";
            templateProjectDescription.Direction = ParameterDirection.Input;
            templateProjectDescription.Value = templateProject.TemplateProjectDescription;
            templateProjectDescription.SqlDbType = SqlDbType.NVarChar;
            listeParameters.Add(templateProjectDescription);

            /*TemplateProjectVersion*/
            SqlParameter templateProjectVersion = new SqlParameter();
            templateProjectVersion.ParameterName = "@templateProjectVersion";
            templateProjectVersion.Direction = ParameterDirection.Input;
            templateProjectVersion.Value = templateProject.TemplateProjectVersion;
            templateProjectVersion.SqlDbType = SqlDbType.NVarChar;
            listeParameters.Add(templateProjectVersion);

            /*TemplateProjectVersion*/
            SqlParameter templateProjectVersionNet = new SqlParameter();
            templateProjectVersionNet.ParameterName = "@templateProjectVersionNet";
            templateProjectVersionNet.Direction = ParameterDirection.Input;
            templateProjectVersionNet.Value = templateProject.TemplateProjectVersionNet;
            templateProjectVersionNet.SqlDbType = SqlDbType.NVarChar;
            listeParameters.Add(templateProjectVersionNet);

            return listeParameters;
        }

    }
}
