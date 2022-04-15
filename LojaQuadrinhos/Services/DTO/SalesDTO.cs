using System;

namespace LojaQuadrinhos.Services.DTO
{
    public class SalesDTO
    {
        public int Id { get; set; }

        public int ComicId { get; private set; }
        
        public string UserEmail { get; private set; }

        public int Quantity { get; private set; }

        public SalesDTO()
        {

        }

        public SalesDTO(int comicid, string useremail, int quantity)
        {
            ComicId = comicid;
            UserEmail = useremail;        
            Quantity = quantity; 
        }
    }
}
