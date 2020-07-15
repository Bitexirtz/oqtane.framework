using System.Collections.Generic;
using System.Linq;
using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;

namespace Itm.DailyWorkRecords.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DailyWorkRecordContext _db;

        public ProjectRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public Project AddProject(Project Project)
        {
            _db.Project.Add(Project);
            _db.SaveChanges();
            return Project;
        }

        public void DeleteProject(int ProjectId)
        {
            Project Project = _db.Project.Find(ProjectId);
            _db.Project.Remove(Project);
            _db.SaveChanges();
        }

        public Project GetProject(int ProjectId)
        {
            return _db.Project.Find(ProjectId);
        }

        public IEnumerable<Project> GetProjects(int ModuleId)
        {
            return _db.Project.Where(item => item.ModuleId == ModuleId);
        }

        public Project UpdateProject(Project Project)
        {
            _db.Entry(Project).State = EntityState.Modified;
            _db.SaveChanges();
            return Project;
        }
    }
}
