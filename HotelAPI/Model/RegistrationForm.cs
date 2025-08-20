using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Model
{
	public class RegistrationForm
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int RegistrationFormId { get; set; }

		public required string FirstName { get; set; }
		public required string LastName { get; set; }

		[EmailAddress]
		public required string GmailID { get; set; }

		public required string UserName { get; set; }

		[DataType(DataType.Password)]
		public required string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		public required string ConfirmPassword { get; set; }

		[Phone]
		public required string PhoneNumber { get; set; }
	}
} 