﻿namespace MultiShop.Catalog.Dtos.ContactDtos
{
    public class ResultContactDto
    {
        public string ContactId { get; set; }
        public string NAmeSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool İsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
