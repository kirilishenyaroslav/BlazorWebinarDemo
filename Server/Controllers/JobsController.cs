using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Jobs.Models;
using WebinarBlazorApp.Server.DbContext;

namespace BlazorApp5.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<JobModel> logger;
        private readonly StaticContext context;

        public JobsController(ILogger<JobModel> logger, StaticContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        public List<JobModel> Get()
        {
            return context.Jobs;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public JobModel Post([FromBody] JobModel jobModel)
        {
            return context.CreateJob(jobModel);
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public bool Put([FromBody]JobModel jobModel)
        {
            context.UpdateJobStatus(jobModel);
            return true;
        }
    }
}
