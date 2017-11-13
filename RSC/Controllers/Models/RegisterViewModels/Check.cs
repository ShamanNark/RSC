using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSC.Models.RegisterViewModels
{
    public class Check
    {
        public RegisterAssessorViewModel registerAssessorViewModel { get; set; }
        public RegisterStudentViewModel registerStudentViewModel { get; set; }
        public RegisterStudentCouncilViewModel registerStudentCouncilViewModel { get; set; }
        public RegisterUniversityViewModel registerUniversityViewModel { get; set; }

        public Check()
        {
            registerAssessorViewModel = new RegisterAssessorViewModel();
            registerStudentViewModel = new RegisterStudentViewModel();
            registerStudentCouncilViewModel = new RegisterStudentCouncilViewModel();
            registerUniversityViewModel = new RegisterUniversityViewModel();
        }
    }
}
