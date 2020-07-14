using System;
using System.Linq;
using System.Collections.Generic;
using Jobs.Models;

namespace WebinarBlazorApp.Server.DbContext
{
    public class StaticContext
    {
        public List<JobModel> Jobs;

        public StaticContext()
        {
            this.Jobs = new List<JobModel>
            {
                new JobModel { Id = 1, Description = "Wake up", Status = JobStatuses.Todo, LastUpdated = DateTime.Now },
                new JobModel { Id = 2, Description = "Go to the gym", Status = JobStatuses.Todo, LastUpdated = DateTime.Now },
                new JobModel { Id = 3, Description = "Call girl-friend", Status = JobStatuses.Todo, LastUpdated = DateTime.Now },
                new JobModel { Id = 4, Description = "Fix bike tyre", Status = JobStatuses.Todo, LastUpdated = DateTime.Now },
                new JobModel { Id = 5, Description = "Finish blog post", Status = JobStatuses.Todo, LastUpdated = DateTime.Now }
            };
        }

        public bool UpdateJobStatus(JobModel updatedJob)
        {
            if (updatedJob is null)
                return false;

            foreach(var job in Jobs)
            {
                if (job.Id == updatedJob.Id)
                {
                    job.Status = updatedJob.Status;
                    job.LastUpdated = updatedJob.LastUpdated;
                }
            }

            return true;
        }

        public JobModel CreateJob(JobModel newJob)
        {
            if (newJob is null) 
                return null;

            var newId = Jobs.Any() ? Jobs.Max(j => j.Id) + 1 : 1;
            newJob.Id = newId;

            Jobs.Add(newJob);

            return newJob;
        }
    }
}
