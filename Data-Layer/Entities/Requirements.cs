namespace Data_Layer.Entities
{
    public class Requirements
    {
        private enum ExperienceEnum
        {
            NONE = 0,
            STUDENT = 1,
            ENTRY = 2,
            MEDIUM = 3,
            EXPERIENCED = 4,
        }

        private enum StudiesEnum 
        { 
            UNQUALIFIED = 0,
            QUALIFIED = 1,
            STUDENT = 2, 
            GRADUATED = 3,
        }


        private ExperienceEnum experience;
        private StudiesEnum studies;
        
        public Requirements() {
            experience = 0;
            studies = 0;
        }

        public string GetExperience()
        {
            return this.experience.ToString();
        }

        public string GetStudies()
        {
            return this.studies.ToString();
        }
    }
}