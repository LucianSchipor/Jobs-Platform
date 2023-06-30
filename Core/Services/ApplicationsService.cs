using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{


    public class ApplicationsService
    {
        private readonly UnitOfWork _unitOfWork;

        public ApplicationsService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Application CreateApplication(Application payload)
        {
            if (payload == null) { return null; }

            Application app = new Application
            {
                JobId = payload.JobId,
                Studies = payload.Studies,
                Industry = payload.Industry,
                Experience = payload.Experience,
                MessageForEmployer = payload.MessageForEmployer,
                Email = payload.Email,
            };

            _unitOfWork.Applications.AddAplication(app);

            return app;
        }

        public List<Application> ViewJobApplications(int jobId)
        {
            var result = _unitOfWork.Applications.GetJobApplications(jobId);
            return result;
        }
    }
}
