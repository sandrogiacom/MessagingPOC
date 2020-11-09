namespace MessagingPOC.Dto
{
    public class GroupCreateDTO
    {
        public string ObjectGuid { get; set; }
        public string SamAccountName { get; set; }
        public string DistinguishedName { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public long LastAdChangeMillis { get; set; }
        public string GroupScope { get; set; }
        public string GroupType { get; set; }
    }
}
