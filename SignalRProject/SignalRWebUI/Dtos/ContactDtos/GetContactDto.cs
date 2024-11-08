﻿namespace SignalRWebUI.Dtos.ContactDtos
{
	public class GetContactDto
	{
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterTitle { get; set; }
        public string FeatureDescription { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDescription { get; set; }
        public string OpenHours { get; set; }

    }
}