using DataLayer;
using DataLayer.Entities;
using Microsoft.IdentityModel.Tokens;
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

            if (!_unitOfWork.Applications.Employer_GetApps(payload.JobId).Where(e => e.Email == payload.Email).IsNullOrEmpty())
                return null;

            Application app = new Application
            {
                Id = payload.Id,
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

        public List<Application> Employer_ViewJobApplications(int jobId)
        {
            var result = _unitOfWork.Applications.Employer_GetApps(jobId);
            return result;
        }

        public List<Application> Applier_ViewJobApplications(string Email)
        {
            var result = _unitOfWork.Applications.Applier_GetApps(Email).ToList();
            return result;
        }

        public bool DeleteApp(int AppID, string Email)
        {

            var val = _unitOfWork.Applications.GetAll().FirstOrDefault(a => a.Id == AppID);

            if (val == null)
                return false;

            var userTryingToDelete = _unitOfWork.Accounts.GetAll().FirstOrDefault(c => c.Email == Email);
            try
            {
                if (!userTryingToDelete.Role.Equals(3))
                    if (val.Email != Email)
                        return false;
            }
            catch
            {
                throw new Exception("Utilizatorul cu email-ul specificat nu exista.");
            }
            _unitOfWork.Applications.DeleteApp(AppID, Email);
            return true;
        }
    }
}
