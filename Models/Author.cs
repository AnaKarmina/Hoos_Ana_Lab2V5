using System.ComponentModel.DataAnnotations;

namespace Hoos_Ana_Lab2V5.Models
{
    public class Author
    {
     
        public int ID { get; set; }

       
    
        public string FirstName { get; set; }

      
        
        public string LastName { get; set; }

        // Navigation property pentru Books
        public ICollection<Book>? Books { get; set; }
    }
}
