﻿namespace MultiShop.DtoLayer.CatalogDtos.ContactDtos
{
    public class CreateContactDto
    {
        public string NAmeSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool İsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
