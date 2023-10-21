namespace AppliedProgrammingTask1.Pages
{
    public class Disaster
    {
        public int rowID;
        public string startDate;
        public string endDate;
        public string location;
        public string description;
        public string Aid;
        public string newAid;

        public Disaster()
        {

        }
        public Disaster(int row, string start, string end, string location, string description, string aid, string newAid)
        {
            this.rowID = row;
            this.startDate = start;
            this.endDate = end;
            this.location = location;
            this.description = description;
            this.Aid = aid;
            this.newAid = newAid;
        }

        public int getRow()
        {
            return rowID;
        }
        public string getStartDate()
        {
            return startDate;
        }
        public string getEndDate()
        {
            return endDate;
        }
        public string getLocation()
        {
            return location;
        }
        public string getDescription()
        {
            return description;
        }
        public string getAid()
        {
            return Aid;
        }
        public string getNewAid()
        {
            return newAid;
        }
    }
}
