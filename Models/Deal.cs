namespace Models {
    public class Deal : Base {
        public string LastActivityAt { get; set; }
        public string LastStageChangeByID { get; set; }
        public string DropboxEmail { get; set; }
        public int OrganizationID { get; set; }

        public string Value { get; set; }
        public float GetValue() => float.Parse(Value, System.Globalization.NumberFormatInfo.InvariantInfo);

        public string Name { get; set; }
        public int? ContactID { get; set; }
        public string Currency { get; set; }
        public bool Hot { get; set; }
        public int? StageID { get; set; }
        public string LastStageChangeAt { get; set; }
        public string AddedAt { get; set; }
        public int? SourceID { get; set; }
        public int? LossReasonID { get; set; }
        public int? UnqualifiedReasonID { get; set; }
        public string EstimatedCloseDate { get; set; }
        public int? CustomizedWinLikelihood { get; set; }
    }
}
