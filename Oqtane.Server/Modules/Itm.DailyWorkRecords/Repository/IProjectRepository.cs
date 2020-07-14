using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects(int ModuleId);
        Project GetProject(int ProjectId);
        Project AddProject(Project Project);
        Project UpdateProject(Project Project);
        void DeleteProject(int ProjectId);
    }
}
